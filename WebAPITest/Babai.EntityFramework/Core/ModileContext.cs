using Babai.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Babai.EntityFramework.Core
{
    public class MobileContext : DbContext 
    {
        public DbSet<Phone> Phones { get; set; }

        public MobileContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
