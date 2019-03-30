using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using School.Model;

namespace School.DataAccess
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "Donau.hiof.no",
                InitialCatalog = "geire",
                UserID = "geire",
                Password = "Hrgx9fYn"
            };

            optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Attends)
                .HasForeignKey(sc => sc.StudentId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(bc => bc.CourseId);
        }
    }
}
