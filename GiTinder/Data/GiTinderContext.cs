using GiTinder.Models;
using Microsoft.EntityFrameworkCore;

namespace GiTinder.Data
{
    public class GiTinderContext : DbContext 
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
<<<<<<< HEAD
            optionsBuilder.UseMySQL("server=localhost;database=gitinder;user=root;password=1234");
=======
            optionsBuilder.UseMySQL("server=localhost;database=gitinder;user=Jonathan;password=Michel123");
>>>>>>> b8a52ca500712c4e2ec5919c74bb702fa02b19ef
            base.OnConfiguring(optionsBuilder);
        }
    }
}
