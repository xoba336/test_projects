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

namespace TextEditor.Helper
{
    class DatabaseHelper
    {
        private static string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
        public static void CreteDatabase()
        {
            string dbName = DatabaseHelper.GetConnection().ConnectionString.Replace("Data Source=", "").ToString();
            string dbPath = System.IO.Directory.GetCurrentDirectory()+ @"\" + dbName;
            if(!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }
            CreateTable();
        }

        private static void CreateTable()
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

        public static string ReadFileContentByID(int clickedFile)
        {
            using (var db = new FilestorageContext())
            {
                List<FileStorage> selectedFileRow = db.FileStorages.Where(x => x.Id == clickedFile).ToList();
                byte[] fileBytes = (byte[])selectedFileRow[0].content;
                System.Text.Encoding enc = System.Text.Encoding.UTF8;
                string selectedFile = enc.GetString(fileBytes);
                return selectedFile;
            }
        }

        internal static void SaveFileToDatabase(string content, string fileName, string fileType)
        {
            byte[] _fileToSave_bytes = Encoding.UTF8.GetBytes(content);
            //string fileFormat = fileName.First()
            using (var db = new FilestorageContext())
            {
                FileStorage f1 = new FileStorage();
                f1.file_name = fileName;
                f1.file_format = fileType;
                f1.content = _fileToSave_bytes;
                db.FileStorages.Add(f1);
                db.SaveChanges();
            }
        }

        public static DataTable ReadFilesFromDB()
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
                SQLiteDataReader readedFiles =  command.ExecuteReader();
                while(readedFiles.Read())
                {
                    /*byte[] fileBytes = (byte[])readedFiles["content"];
                    System.Text.Encoding enc = System.Text.Encoding.UTF8;
                    string myFile = enc.GetString(fileBytes);*/
                    dt.Rows.Add(readedFiles["id"].ToString(), readedFiles["file_name"].ToString(), readedFiles["file_format"].ToString()); //, myFile
                }
                conn.Close();
            }
            return dt;
        }

        private static SQLiteConnection GetConnection()
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
