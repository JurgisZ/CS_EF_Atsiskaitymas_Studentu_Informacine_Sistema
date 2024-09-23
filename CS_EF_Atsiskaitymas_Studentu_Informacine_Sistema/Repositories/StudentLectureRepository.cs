using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories
{
    internal class StudentLectureRepository : IStudentLectureRepository
    {
        private readonly StudentsDbContext _context;
        public StudentLectureRepository(StudentsDbContext context)
        {
            _context = context;

        }
        //public StudentLecture GetStudentLecturesByDepartment(Department department)
        //{
        //    _context.StudentLectures.Include(e => e.Department)

        ////public void AddStudentToDepartmentAndAssignExistingLectures(Student student, Department department)
        ////    {
        ////        student.DepartmentId = department.DepartmentId;
        ////        _studentRepository.Update(student);

        ////        _context.Departments
        ////        .Include(l => l.Lectures)
        ////        .Include(s => s.Students)
        ////        .FirstOrDefault(e => e.DepartmentId == id);

        ////        _studentLectureRepository
        ////}
        //}

        public void Create(StudentLecture studentLecture)
        {
            _context.StudentLectures.Add(studentLecture);
            _context.SaveChanges();
        }

        public void Update(StudentLecture studentLecture)
        {
            _context.StudentLectures.Update(studentLecture);
            _context.SaveChanges();
        }
    }
}
