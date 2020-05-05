﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSchool_API.Data;

namespace ProjectSchool_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("ProjectSchool_API.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DtBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DtBirth = "01/01/2000",
                            Lastname = "McDonald",
                            Name = "Alexander",
                            TeacherId = 1
                        },
                        new
                        {
                            ID = 2,
                            DtBirth = "02/02/2000",
                            Lastname = "Bruce",
                            Name = "Glen",
                            TeacherId = 2
                        },
                        new
                        {
                            ID = 3,
                            DtBirth = "02/03/2000",
                            Lastname = "Nelson",
                            Name = "Connor",
                            TeacherId = 3
                        });
                });

            modelBuilder.Entity("ProjectSchool_API.Models.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "John"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Mary"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Steve"
                        });
                });

            modelBuilder.Entity("ProjectSchool_API.Models.Student", b =>
                {
                    b.HasOne("ProjectSchool_API.Models.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
