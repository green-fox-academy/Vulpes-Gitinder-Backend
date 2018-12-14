﻿// <auto-generated />
using GiTinder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GiTinder.Migrations
{
    [DbContext(typeof(GiTinderContext))]
    [Migration("20181213141248_AddedSettingsValidationRangeMin1Max3ForeignKeyAnnotation")]
    partial class AddedSettingsValidationRangeMin1Max3ForeignKeyAnnotation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("GiTinder.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("GiTinder.Models.User", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ReposCount");

                    b.Property<string>("UserToken");

                    b.HasKey("userName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GiTinder.Models.Settings", b =>
                {
                    b.HasOne("GiTinder.Models.User")
                        .WithOne("UserSettings")
                        .HasForeignKey("GiTinder.Models.Settings", "UserName");
                });
#pragma warning restore 612, 618
        }
    }
}
