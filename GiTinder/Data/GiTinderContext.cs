using GiTinder.Models;
using Microsoft.EntityFrameworkCore;

namespace GiTinder.Data
{
    public class GiTinderContext : DbContext 
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=gitinder;user=Jonathan;password=Michel123");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
