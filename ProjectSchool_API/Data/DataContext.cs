
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>()
            .HasData(
                new List<Teacher>(){
                    new Teacher(){
                        ID = 1,
                        Name = "John"
                    },
                    new Teacher(){
                        ID = 2,
                        Name = "Mary"
                    },
                    new Teacher(){
                        ID = 3,
                        Name = "Steve"
                    },
                }
            );

            
            builder.Entity<Student>()
            .HasData(
                new List<Student>(){
                    new Student(){
                        ID = 1,
                        Name = "Alexander",
                        Lastname = "McDonald",
                        DtBirth = "01/01/2000",
                        TeacherId = 1
                    },
                    new Student(){
                        ID = 2,
                        Name = "Glen",
                        Lastname = "Bruce",
                        DtBirth = "02/02/2000",
                        TeacherId = 2
                    },
                    new Student(){
                        ID = 3,
                        Name = "Connor",
                        Lastname = "Nelson",
                        DtBirth = "02/03/2000",
                        TeacherId = 3
                    },
                }
            );
        }
    }
}