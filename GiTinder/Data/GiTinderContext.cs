﻿using GiTinder.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GiTinder.Data
{
    public class GiTinderContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Language> Languages { get; set; }
               
        public GiTinderContext(DbContextOptions<GiTinderContext> options)
  : base(options)
        { }

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
