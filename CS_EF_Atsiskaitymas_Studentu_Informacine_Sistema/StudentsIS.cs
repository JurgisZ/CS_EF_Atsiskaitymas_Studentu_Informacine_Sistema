using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema
{
    internal class StudentsIS
    {
        //private readonly IUiServiice uiService;
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;
        public StudentsIS(IStudentService studentService, IDepartmentService departmentService, ILectureService lectureService) 
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _lectureService = lectureService;
        }
        public void Run()
        {
            using var context = new StudentsDbContext();
            //context.IsSeeding = true;
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            
            DisplayHelloMessage();
            

            //Funkcionalumai:
            //1. Create department
            //Add students to department *
            //Add lectures to department (bonus: lectures preloaded from csv?) *

            //2. Add lectures to department (existing dpt) *
            //Add students to department (existing dpt) *

            //3. Create lecture and add it to department *

            //4. Create student, add it to department and add existing lectures

            //5. Move student to another department, (bonus: students lectures are changed to those in the new dpt)

            //6. Display all students in department

            //7. Displaye all lectures in department

            //8. Display all lectures that student has
        }
        public void DisplayHelloMessage()
        {
            Console.WriteLine("Welcome to StudentIS.");
        }

        

    }
}




////load students
//string studentsCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "students.csv");
//var students = CsvHelperService.StudentsFromCsv(studentsCsvPath);

//Console.WriteLine("Students:");
//foreach (var student in students)
//{
//    Console.WriteLine($"{student.Name}, {student.LastName}, {student.StudentId}, {student.Email}, {student.DepartmentId} ");
//}
//Console.WriteLine();

////load departments
//string departmentsCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "departments.csv");
//var departments = CsvHelperService.DepartmentsFromCsv(departmentsCsvPath);

//Console.WriteLine("Departments:");
//foreach (var department in departments)
//{
//    Console.WriteLine($"{department.DepartmentId},{department.DepartmentName},{department.DepartmentCode}");
//}
//Console.WriteLine();

////load lectures
//string lecturesCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "lectures.csv");
//var lectures = CsvHelperService.LecturesFromCsv(lecturesCsvPath);

//Console.WriteLine("Lectures:");
//foreach (var lecture in lectures)
//{
//    Console.WriteLine($"{lecture.LectureId},{lecture.LectureName},{lecture.Time},{lecture.Duration}");
//}
//Console.WriteLine();

////load departmentLectures
//string departmentLecturesCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "department_lectures.csv");
//var departmentLectures = CsvHelperService.DepartmentLecturesFromCsv(departmentLecturesCsvPath);

//Console.WriteLine("DepartmentLectures:");
//foreach (var departmentLecture in departmentLectures)
//{
//    Console.WriteLine($"{departmentLecture.DepartmentId},{departmentLecture.LectureId}");
//}
//Console.WriteLine();

////load studentLectures
//Console.WriteLine("StudentLectures: ");
//string studentLecturesCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "student_lectures.csv");
//var studentLectures = CsvHelperService.StudentLecturesFromCsv(studentLecturesCsvPath);
//foreach (var studentLecture in studentLectures)
//{
//    Console.WriteLine($"{studentLecture.StudentId}, {studentLecture.LectureId}");
//}
//Console.WriteLine();