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
            Database.SetInitializer<FilestorageContext>(null);
        }
        public DbSet<FileStorage> FileStorages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
