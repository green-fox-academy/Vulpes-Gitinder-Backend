using GiTinder.Models;
using GiTinder.Models.Connections;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace GiTinder.Data
{
    public class GiTinderContext : DbContext
    {
        public GiTinderContext(DbContextOptions<GiTinderContext> options)
        : base(options)
        { }
     
        public GiTinderContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<SettingsLanguage> SettingsLanguage { get; set; }
        public DbSet<Swipe> Swipe { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<UserLanguages> UserLanguages { get; set; }


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

            modelBuilder.Entity<UserLanguages>()
                 .HasKey(t => new { t.Username, t.LanguageId });

            modelBuilder.Entity<UserLanguages>()
                .HasOne(uL => uL.User)
                .WithMany(u => u.UserLanguages)
                .HasForeignKey(uL => uL.Username);

            modelBuilder.Entity<UserLanguages>()
                .HasOne(uL => uL.Language)
                .WithMany(l => l.UserLanguages)
                .HasForeignKey(uL => uL.LanguageId);

            modelBuilder.Entity<Swipe>()
<<<<<<< HEAD
                .HasKey(t => new { t.SwipingUserId, t.SwipedUserId });         
=======
                .HasKey(t => new { t.SwipingUserId, t.SwipedUserId });

            modelBuilder.Entity<Match>()
                .HasKey(t => new { t.Username_1, t.Username_2 });

>>>>>>> 146a5fe0074d44cb0ec431df062e1afa1a08c362
        }
    }
}
