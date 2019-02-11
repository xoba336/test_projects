namespace FirstEF6App
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserstoredbModel : DbContext
    {
        public UserstoredbModel()
            : base("name=UserstoredbConnection")
        {
        }

        public virtual DbSet<Animals> Animals { get; set; }
        public virtual DbSet<SomeTables> SomeTables { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animals>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Animals>()
                .Property(e => e.Height)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Animals>()
                .Property(e => e.Weight)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Animals>()
                .Property(e => e.Nickname)
                .IsUnicode(false);

            modelBuilder.Entity<SomeTables>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SomeTables>()
                .Property(e => e.Count)
                .HasPrecision(10, 2);
        }
    }
}
