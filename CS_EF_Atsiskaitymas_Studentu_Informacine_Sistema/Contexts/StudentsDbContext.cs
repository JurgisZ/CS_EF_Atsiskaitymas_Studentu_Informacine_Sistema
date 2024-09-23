using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts
{
    internal class StudentsDbContext : DbContext
    {
        public bool IsSeeding { get; set; } = true;
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<DepartmentLecture> DepartmentLectures { get; set; }
        public DbSet<StudentLecture> StudentLectures { get; set; }

        public StudentsDbContext() : base() { }
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =(LocalDb)\\MSSQLLocalDB; Database = StudentsIS_Db; Trusted_Connection = true;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setting Entity configurations and realations. See Configurations
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentLectureConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentLectureConfiguration());

            if(IsSeeding)
            {
                Console.WriteLine("SEEDING");


                //load departments
                string departmentsCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "departments.csv");
                var departments = CsvHelperService.DepartmentsFromCsv(departmentsCsvPath);
                modelBuilder.Entity<Department>().HasData(departments);

                //load students
                string studentsCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "students.csv");
                var students = CsvHelperService.StudentsFromCsv(studentsCsvPath);
                Console.WriteLine($"Students lenght: {students.Count}");
                modelBuilder.Entity<Student>().HasData(students);

                //load lectures
                string lecturesCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "lectures.csv");
                var lectures = CsvHelperService.LecturesFromCsv(lecturesCsvPath);
                modelBuilder.Entity<Lecture>().HasData(lectures);

                //load departmentLectures
                string departmentLecturesCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "department_lectures.csv");
                var departmentLectures = CsvHelperService.DepartmentLecturesFromCsv(departmentLecturesCsvPath);
                modelBuilder.Entity<DepartmentLecture>().HasData(departmentLectures);

                //load studentLectures
                string studentLecturesCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "student_lectures.csv");
                var studentLectures = CsvHelperService.StudentLecturesFromCsv(studentLecturesCsvPath);
                modelBuilder.Entity<StudentLecture>().HasData(studentLectures);

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
