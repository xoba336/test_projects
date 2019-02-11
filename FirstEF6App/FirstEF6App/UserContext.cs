using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FirstEF6App
{
    class UserContext : DbContext
    {
        public UserContext() 
            : base("UserstoredbConnection")
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Animals> Animals { get; set; }
        public DbSet<SomeTables> Sometables { get; set; }
        //public DbSet<t_User> t_User { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }*/

    }
    /*
    class SecurityContext : DbContext
    {
        public SecurityContext()
            : base("DbConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Model
    {
        public string Name23 { get; set; }
    }

    public class ModelConfiguration : EntityTypeConfiguration<Model>
    {
        public ModelConfiguration()
        {
            this.ToTable("Users");
            this.Property(p => p.Name23).HasColumnName("Name");
        }
    }*/
}
