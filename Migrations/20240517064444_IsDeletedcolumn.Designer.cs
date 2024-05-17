﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practice_WebApp_MVC_Venkat_TT.Models;

#nullable disable

namespace Multiple_Images_Upload_WebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240517064444_IsDeletedcolumn")]
    partial class IsDeletedcolumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Practice_WebApp_MVC_Venkat_TT.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhotoPath");

                    b.HasKey("Id");

                    b.ToTable("EmployeeTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 0,
                            Email = "poornamora123@gmai.com",
                            IsDeleted = true,
                            Name = "Poornachandar",
                            PhotoPath = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}