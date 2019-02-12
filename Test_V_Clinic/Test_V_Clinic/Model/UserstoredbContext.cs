using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test_V_Clinic.Model
{
    public partial class UserstoredbContext : DbContext
    {
        public UserstoredbContext()
        {
        }

        public UserstoredbContext(DbContextOptions<UserstoredbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animals> Animals { get; set; }
        public virtual DbSet<SomeTables> SomeTables { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-EQRSOT0;Initial Catalog=userstoredb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Animals>(entity =>
            {
                entity.Property(e => e.Height).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<SomeTables>(entity =>
            {
                entity.Property(e => e.Count).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Size).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}