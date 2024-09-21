using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts
{
    internal class StudentsDbContext : DbContext
    {
        DbSet<Department> Departments { get; set; }
        DbSet<Lecture> Lectures { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<DepartmentLecture> DepartmentLectures { get; set; }
        DbSet<StudentLecture> StudentLectures { get; set; }

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
        }
    }
}
