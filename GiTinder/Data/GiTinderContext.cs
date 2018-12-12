using GiTinder.Models;
using Microsoft.EntityFrameworkCore;


namespace GiTinder.Data
{
    public class GiTinderContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; }
        public DbSet<User> Users { get; set; }

        //this.Configuration.AutoDetectChangesEnabled = false; 

        public void SaveSettings(Settings settings)
        {
            if (settings.IsValid)
            {
                GiTinderContext context = new GiTinderContext();
                context.Settings.Add(settings);
                context.SaveChanges();

            }


        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=gitinder;user=root;password=1234");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

