using GiTinder.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GiTinder.Data
{
    public class GiTinderContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=newgitinder;user=root;password=1234");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
