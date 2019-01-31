﻿// <auto-generated />
using System;
using GiTinder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GiTinder.Migrations
{
    [DbContext(typeof(GiTinderContext))]
    [Migration("20190130142108_UserLanguageConnection")]
    partial class UserLanguageConnection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GiTinder.Models.Connections.UserLanguages", b =>
                {
                    b.Property<string>("Username");

                    b.Property<int>("LanguageId");

                    b.HasKey("Username", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("UserLanguages");
                });

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

            modelBuilder.Entity("GiTinder.Models.Match", b =>
                {
                    b.Property<string>("Username_1");

                    b.Property<string>("Username_2");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Username_1", "Username_2");

                    b.ToTable("Matches");
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

            modelBuilder.Entity("GiTinder.Models.Swipe", b =>
                {
                    b.Property<string>("SwipingUserId");

                    b.Property<string>("SwipedUserId");

                    b.Property<string>("Direction")
                        .IsRequired();

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("SwipingUserId", "SwipedUserId");

                    b.ToTable("Swipe");
                });

            modelBuilder.Entity("GiTinder.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("Repos");

                    b.Property<int>("ReposCount");

                    b.Property<string>("UserToken");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GiTinder.Models.Connections.UserLanguages", b =>
                {
                    b.HasOne("GiTinder.Models.Language", "Language")
                        .WithMany("UserLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GiTinder.Models.User", "User")
                        .WithMany("UserLanguages")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade);
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