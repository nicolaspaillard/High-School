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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Missing> Missings { get; set; }
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=HighSchool;Integrated Security=true");
                //optionsBuilder.UseSqlServer(@"Server=tcp:itschool.database.windows.net,1433;Initial Catalog=itschooldatabase;Persist Security Info=False;User ID=admin34;Password=azerty!34;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classroom>().ToTable("Classrooms");
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Grade>().ToTable("Grades");
            modelBuilder.Entity<Group>().ToTable("Groups");
            modelBuilder.Entity<Missing>().ToTable("Missings");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            foreach (SubjectMatter val in Enum.GetValues(typeof(SubjectMatter)))
            {
                modelBuilder.Entity<Subject>().HasData(new Subject { SubjectID = val });
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
