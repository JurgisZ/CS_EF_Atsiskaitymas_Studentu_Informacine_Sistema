using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly StudentsDbContext _context;
        public StudentRepository(StudentsDbContext context)
        {
            _context = context;

        }

        public int Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.StudentId;

        }
        public Student? GetById(int id) 
        { 
            return _context.Students.FirstOrDefault(e => e.StudentId == id);
        }
        public List<Student> GetAll() 
        {
            return _context.Students.ToList();
        }


        public void Update(Student student) 
        { 
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        //public List<Lecture> GetLecturesByDepartment(Department department)
        //{
        
        //}
    }
}
