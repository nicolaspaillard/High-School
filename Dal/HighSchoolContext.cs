using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dal
{
    public class HighSchoolContext : DbContext
    {
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ClassStudents> ClassStudents { get; set; }
        public DbSet<MissingStudent> MissingStudents { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public HighSchoolContext() : base()
        {

        }
        public HighSchoolContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=HighSchool;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classroom>().ToTable("Classrooms");
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Grade>().ToTable("Grades");
            modelBuilder.Entity<ClassStudents>().ToTable("ClassStudents");
            modelBuilder.Entity<MissingStudent>().ToTable("MissingStudents");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            base.OnModelCreating(modelBuilder);
        }
    }
}
