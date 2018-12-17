using GiTinder.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GiTinder.Data
{
    public class GiTinderContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; }
        public DbSet<User> Users { get; set; }

        //this.Configuration.AutoDetectChangesEnabled = false;

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=gitinder;user=root;password=1234");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

//List<string> list = new List<string>();
//User user1 = new User();
//User user2 = new User();

//user1.UserName = "Filip Teply";
//    user2.UserName = "Jonathan Bonnin";

//    GiTinderContext context = new GiTinderContext();
//context.Users.Add(user1);
//    context.Users.Add(user2);
//    context.SaveChanges();

//    list.Add(item: user1.UserName);
//    list.Add(item: user2.UserName);



//public void SaveSettings(Settings settings)
//{
//    if (settings.IsValid)
//    {
//        GiTinderContext context = new GiTinderContext();
//        context.Settings.Add(settings);
//        context.SaveChanges();
//    }


//}