﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("DataAccess.Entities.SettingsEntity", b =>
                {
                    b.Property<string>("ConnectionString")
                        .HasColumnType("TEXT");

                    b.HasKey("ConnectionString");

                    b.ToTable("Settings");
                });
#pragma warning restore 612, 618
        }
    }
}
