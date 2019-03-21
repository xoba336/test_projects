using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextEditor.Model
{
    public class FilestorageContext : DbContext
    {
        public FilestorageContext()
            :base("ConnectionStringSQLite")
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<FilestorageContext>(null);
        }
        public DbSet<FileStorage> FileStorages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    /*public class FilestorageDBInitializer : CreateDatabaseIfNotExists<FilestorageContext>  // CreateDatabaseIfNotExists<BookContext>
    {
        private string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
        protected override void Seed(FilestorageContext db)
        {
            string filePath = CurrentDirectory + @"\test1.xml";
            if (!File.Exists(filePath))
            {
                new XDocument(new XElement("root", new XElement("User", "Alex"))).Save("test1.xml");
            }

            // Convert file to byte[]
            FileInfo _fInfo = new FileInfo(filePath);
            long _numBytes = _fInfo.Length;
            FileStream _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read); // read file
            BinaryReader _binReader = new BinaryReader(_fileStream);
            byte[] _fileBytes = _binReader.ReadBytes((int)_numBytes);

            FileStorage fs = new FileStorage();
            fs.file_name = "123.xml";
            fs.file_format = "xml";
            fs.content = _fileBytes;

            db.FileStorages.Add(fs);

            base.Seed(db);
        }
    }*/
}
