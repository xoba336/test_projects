using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Configuration;
using System.Xml.Linq;
using System.Data;
using System.Windows.Forms;
using TextEditor.Model;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading;
using Ionic.Zip;

namespace TextEditor.Helper
{
    class DatabaseHelper
    {
        private static string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

        public static void CreteDatabase() //Create DB if file of database not exist
        {
            string dbName = DatabaseHelper.GetConnection().ConnectionString.Replace("Data Source=", "").ToString();
            string dbPath = System.IO.Directory.GetCurrentDirectory()+ @"\" + dbName;

            if(!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            CreateTable();
        }

        private static void CreateTable() //Create Table in database file (used script) if table not exist
        {
            SQLiteConnection conn = GetConnection();
            using (conn)
            {
                // create table if not exist
                string commandText = File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + @"\Scripts\sql_create.sqlite");
                SQLiteCommand command = new SQLiteCommand(commandText, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static string ReadFileContentByID(int clickedFile) //GetFile from database by ID, unzip content
        {
            using (var db = new FilestorageContext())
            {
                List<FileStorage> selectedFileRow = db.FileStorages.Where(x => x.Id == clickedFile).ToList();
                byte[] content = selectedFileRow.FirstOrDefault().content;

                //Unzip content if it zipped
                Stream checkedZipStream = new MemoryStream(content);
                if (ZipFile.IsZipFile(checkedZipStream, false))
                {
                    content = UnzipContent(content);
                }

                System.Text.Encoding enc = System.Text.Encoding.UTF8;
                string selectedFile = enc.GetString(content);

                return selectedFile;
            }
        }

        private static byte[] UnzipContent(byte[] content) //Unzip content
        {
            MemoryStream unzipResult = new MemoryStream();
            Stream zipStream = new MemoryStream(content);

            using (ZipFile zip = ZipFile.Read(zipStream))
            {
                zip.FirstOrDefault().Extract(unzipResult);
                return unzipResult.ToArray();
            }
        }

        public static void SaveFileToDatabase(string content, string fileName, string fileType, InfoLabel lbInfo) //Zip and Save file to DB
        {
            //Zip file before write to DB
            byte[] _fileToSave_bytes = ZipContent(content, fileName);

            using (var db = new FilestorageContext())
            {
                FileStorage f1 = new FileStorage();
                f1.file_name = fileName;
                f1.file_format = fileType;
                f1.content = _fileToSave_bytes;
                db.FileStorages.Add(f1);
                db.SaveChanges();
            }
            lbInfo.Print(fileName+ " saved. Storage: Database");
        }

        private static byte[] ZipContent(string content, string fileName) //Zip content
        {
            MemoryStream zippedMs = new MemoryStream();
            using (ZipFile zip = new ZipFile())
            {
                zip.AddEntry(fileName, content, Encoding.UTF8);
                zip.Save(zippedMs);
                return zippedMs.ToArray();
            }
        }

        public static DataTable SelectAllFiles() //Read all files from database with context
        {
            //Create DataTable and columns from FileStorageView
            DataTable dt = new DataTable();

            Type FileStorage = typeof(FileStorageView);
            var modelFields = FileStorage.GetProperties().ToList();
            foreach (var item in modelFields)
            {
                dt.Columns.Add(item.Name, item.PropertyType);
            }

            //Get table FileStorage from database and fill datatable
            using (var db = new FilestorageContext())
            {
                var list = db.FileStorages.Select(fs => new FileStorageView
                {
                    Id = fs.Id,
                    file_name = fs.file_name,
                    file_format = fs.file_format
                }).ToList();

                foreach (var item in list)
                {
                    DataRow row = dt.NewRow();
                    row["Id"] = item.Id;
                    row["file_name"] = item.file_name;
                    row["file_format"] = item.file_format;
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        public static DataTable ReadFilesFromDB() //Read all files from database with script NOT USE
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("file_name", typeof(string));
            dt.Columns.Add("file_format", typeof(string));

            SQLiteConnection conn = GetConnection();

            using (conn)
            {
                string commandText = File.ReadAllText(CurrentDirectory + @"\Scripts\sql_selectAll.sqlite");
                SQLiteCommand command = new SQLiteCommand(commandText, conn);

                conn.Open();
                SQLiteDataReader readedFiles = command.ExecuteReader();
                while (readedFiles.Read())
                {
                    dt.Rows.Add(readedFiles["id"].ToString(), readedFiles["file_name"].ToString(), readedFiles["file_format"].ToString()); //, myFile
                }
                conn.Close();
            }
            return dt;
        }

        private static SQLiteConnection GetConnection() //Get Connection string from config file
        {
            try
            {
                return new SQLiteConnection(ConfigurationManager.ConnectionStrings[0].ToString());
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("connectionStrings not exist in App.config: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
