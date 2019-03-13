using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data;
using System.Xml;
using System.Threading;
using System.Windows.Forms;

namespace TextEditor.Helper
{
    class DatabaseHelper
    {
        public static void CreteDatabase()
        {
            string dbPath = System.IO.Directory.GetCurrentDirectory()+@"\mydatabase.db";
            if(!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);

                

            }
            CreteTable();
        }

        private static void CreteTable()
        {

            SQLiteConnection conn = GetConnection();

            using (conn) {
                // create table if not exist
                string commandText = "CREATE TABLE IF NOT EXISTS [files] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [file] BINARY, [file_format] VARCHAR(10), [file_name] NVARCHAR(128))";

                SQLiteCommand command = new SQLiteCommand(commandText, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }

            string qq = "dsf";
        }

        public static void AddFileToDB()
        {
            //Create test file
            string filePath = System.IO.Directory.GetCurrentDirectory() + @"\test1.xml";
            if (!File.Exists(filePath))
            {
                new XDocument( new XElement("root", new XElement("User", "Alex")) ).Save("test1.xml");
            }

            // Convert file to byte[]
            FileInfo _fInfo = new FileInfo(filePath);
            long _numBytes = _fInfo.Length;
            FileStream _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read); // read file
            BinaryReader _binReader = new BinaryReader(_fileStream);
            byte[] _fileBytes = _binReader.ReadBytes((int)_numBytes); // file in bytes

            //Get file format
            string fFormat = Path.GetExtension(filePath).Replace(".", "").ToLower();

            //Get file name
            string fName = Path.GetFileName(filePath).Replace(Path.GetExtension(filePath), "");

            SQLiteConnection conn = GetConnection();
            using (conn)
            {
                string commandText = "INSERT INTO [files] ([file], [file_format], [file_name]) VALUES(@file, @format, @name)";
                SQLiteCommand command = new SQLiteCommand(commandText, conn);
                command.Parameters.AddWithValue("@file", _fileBytes);
                command.Parameters.AddWithValue("@format", fFormat);
                command.Parameters.AddWithValue("@name", fName);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Clone();
            }

        }

        public static DataTable ReadFilesFromDB()
        {
            MessageBox.Show("Before sleep: "+ DateTime.Now);
            Thread.Sleep(10000);
            MessageBox.Show("After sleep: " + DateTime.Now);
            List<string> fileNames = new List<string>();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("file_name", typeof(string));
            dt.Columns.Add("file_format", typeof(string));
            dt.Columns.Add("file", typeof(string));

            SQLiteConnection conn = GetConnection();

            using (conn)
            {
                string commandText = @" SELECT * FROM [files]";
                SQLiteCommand command = new SQLiteCommand(commandText, conn);

                conn.Open();
                SQLiteDataReader readedFiles =  command.ExecuteReader();
                while(readedFiles.Read())
                {
                    byte[] fileBytes = (byte[])readedFiles["file"];

                    System.Text.Encoding enc = System.Text.Encoding.UTF8;
                    string myFile = enc.GetString(fileBytes);

                    dt.Rows.Add(readedFiles["id"].ToString(), readedFiles["file_name"].ToString(), readedFiles["file_format"].ToString(), myFile);

                }
                conn.Close();
                
            }
            return dt;
        }

        private static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQLite"].ToString());
        }
    }
}
