﻿// <auto-generated />
using GiTinder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GiTinder.Migrations
{
    [DbContext(typeof(GiTinderContext))]
    [Migration("20190111110509_MigrationTest3")]
    partial class MigrationTest3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GiTinder.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName")
                        .IsRequired();

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("GiTinder.Models.Settings", b =>
                {
                    b.Property<int>("SettingsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EnableBackgroundSync");

                    b.Property<bool>("EnableNotification");

                    b.Property<int>("MaxDistanceInKm");

                    b.Property<string>("Username");

                    b.HasKey("SettingsId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("GiTinder.Models.SettingsLanguage", b =>
                {
                    b.Property<int>("SettingsId");

                    b.Property<int>("LanguageId");

                    b.HasKey("SettingsId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("SettingsLanguage");
                });

            modelBuilder.Entity("GiTinder.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ReposCount");

                    b.Property<string>("UserToken")
                        .IsRequired();

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GiTinder.Models.Settings", b =>
                {
                    b.HasOne("GiTinder.Models.User")
                        .WithOne("UserSettings")
                        .HasForeignKey("GiTinder.Models.Settings", "Username");
                });

            modelBuilder.Entity("GiTinder.Models.SettingsLanguage", b =>
                {
                    b.HasOne("GiTinder.Models.Language", "Language")
                        .WithMany("SettingsLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GiTinder.Models.Settings", "Settings")
                        .WithMany("SettingsLanguages")
                        .HasForeignKey("SettingsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
