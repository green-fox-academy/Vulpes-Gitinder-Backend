using GiTinder.Models;
using Microsoft.EntityFrameworkCore;

namespace GiTinder.Models
{
    public class GiTinderContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=VGBlibrary;user=root;password=1234");
        //    base.OnConfiguring(optionsBuilder);
        //}
        //public GiTinderContext(DbContextOptions<GiTinderContext> options)
        //    : base(options)
        //{

        //}




    }
}