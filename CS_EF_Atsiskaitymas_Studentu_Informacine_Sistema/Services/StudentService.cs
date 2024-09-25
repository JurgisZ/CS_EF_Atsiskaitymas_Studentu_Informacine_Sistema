using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentLectureRepository _studentLectureRepository;
        public StudentService(IStudentRepository repository, IStudentLectureRepository studentLectureRepository)
        {
            _studentRepository = repository;
            _studentLectureRepository = studentLectureRepository;
        }

        public int Create(Student student) //-1 err
        {
            return _studentRepository.Create(student);
        }

        public Student? GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        public void AddStudentToDepartment(Student student, int departmentId)
        {
            student.DepartmentId = departmentId;
            _studentRepository.Update(student);
        }

        public void AddStudentToLecture(Student student, int lectureId)
        {
            _studentLectureRepository.Create(new StudentLecture
            {
                LectureId = lectureId,
                StudentId = student.StudentId
            });
        }

        public void AddStudentToDepartmentAndAssignExistingLectures(Student student, Department department)
        {
            student.DepartmentId = department.DepartmentId;
            _studentRepository.Update(student);

            //_context.Departments
            //.Include(l => l.Lectures)
            //.Include(s => s.Students)
            //.FirstOrDefault(e => e.DepartmentId == id);

            
        }
    }
}
