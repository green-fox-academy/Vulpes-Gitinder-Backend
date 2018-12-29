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
        //Do I need the following DbSet for the join entity here?  
        //public DbSet<SettingsLanguage> SettingsLanguages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=newgitinder;user=root;password=1234");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SettingsLanguage>()
                .HasKey(t => new { t.SettingsId, t.LanguageId });

            modelBuilder.Entity<SettingsLanguage>()
                .HasOne(pt => pt.Settings)
                .WithMany(p => p.SettingsLanguages)
                .HasForeignKey(pt => pt.SettingsId);

            modelBuilder.Entity<SettingsLanguage>()
                .HasOne(pt => pt.Language)
                .WithMany(t => t.SettingsLanguages)
                .HasForeignKey(pt => pt.LanguageId);
        }
    }
}