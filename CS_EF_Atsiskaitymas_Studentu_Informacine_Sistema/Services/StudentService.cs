using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services
{
    public class StudentService : IStudentService
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
        }

        public int GenerateNewStudentCode() //neuztikrina unikalumo
        {
            Random rnd = new Random();
            return rnd.Next(10000000, 99999999);
        }

        public bool IsValidStudentName(string? name)
        {
            if(string.IsNullOrEmpty(name))
                return false;

            if (name.Length < 2 || name.Length > 50)
                return false;

            return true;
        }

        public bool IsValidStudentLastName(string? name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (name.Length < 2 || name.Length > 50)
                return false;

            return true;
        }

        public bool IsValidNewStudentCode(int studentCode)
        {
            string codeStr = studentCode.ToString();
            if(codeStr.Length != 8)
                return false;

            if(_studentRepository.GetByCode(studentCode) != null)
                return false;

            return true;
        }
        public bool IsValidEmail(string email)
        {
            // Regex email validavimui
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }


    }
}
