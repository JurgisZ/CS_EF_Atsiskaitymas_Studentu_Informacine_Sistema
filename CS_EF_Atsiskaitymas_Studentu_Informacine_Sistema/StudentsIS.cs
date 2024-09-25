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
using System.Transactions;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema
{
    public class StudentsIS
    {
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

            DisplayMainMenu();
        }

        public void DisplayMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Department options");
                Console.WriteLine("2. Lecture options");
                Console.WriteLine("3. Student options");

                Console.Write("Select option: ");
                switch (UserInputGetInt())
                {
                    case 1: //Department options
                        Console.Clear();
                        Console.WriteLine("Department options.");
                        Console.WriteLine("1. Create new department.");
                        Console.WriteLine("2. View all departments.");

                        switch (UserInputGetInt())
                        {
                            case 1:
                                //Create new department
                                Console.Clear();
                                Console.WriteLine("Creating new department");
                                Console.Write("Enter a name for new department: ");
                                string? departmentName = null;

                                //While invalid or exit
                                while (!_departmentService.IsValidNewDepartmentName(departmentName = UserInputGetString()))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Creating new department");
                                    Console.WriteLine("Invalid Department name.");
                                    Console.Write("Enter a name for new department: ");
                                }

                                //generate code
                                var departmentCode = _departmentService.GenerateUniqueDepartmentCode(departmentName);
                                var department = new Department()
                                {
                                    DepartmentName = departmentName,
                                    DepartmentCode = departmentCode
                                };

                                _departmentService.CreateDepartment(department);
                                break;


                            case 2:
                                //Display all departments
                                Console.Clear();
                                Console.WriteLine("Available departments:");
                                var departments = _departmentService.GetAll();
                                if (departments.Count > 0)
                                {
                                    for (int i = 0; i < departments.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. Name: {departments[i].DepartmentName} Code: {departments[i].DepartmentCode}");
                                    }
                                }
                                else
                                {
                                    Console.Write("No departments found. Press any key to continue.");
                                }
                                Console.ReadKey();
                                break;
                        }
                        break;

                    case 2: //Lecture options
                        Console.Clear();
                        Console.WriteLine("Lecture options.");
                        Console.WriteLine("1. Create new lecture.");
                        Console.WriteLine("2. Assign lecture to a department.");
                        switch (UserInputGetInt())
                        {
                            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            case 1: //Create new lecture //ADD TIME AND DURATION
                                Console.Clear();
                                Console.WriteLine("Creating new lecture");
                                Console.Write("Enter a name for new lecture: ");
                                string? lectureName = null;

                                while (!_lectureService.IsValidNewLectureName(lectureName = UserInputGetString()))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Creating new lecture");
                                    Console.WriteLine("Invalid lecture name.");
                                    Console.Write("Enter a name for new lecture: ");
                                }
                                Console.WriteLine("At what time does the lecture start?");
                                
                                var lecture = new Lecture()
                                {
                                    LectureName = lectureName
                                };
                                lecture.Time = UserInputGetTime();
                                _lectureService.Create(lecture);

                                break;
                            case 2: //Assign lecture to existing department
                                Console.Clear();
                                Console.WriteLine("Lectures: ");

                                var lectures = _lectureService.GetAllLectures();

                                //Select lecture
                                int lectureSelection = -1;
                                do
                                {
                                    for (int i = 0; i < lectures.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. Lecture name: {lectures[i].LectureName} Lecture time: {lectures[i].Time} (Duration: {lectures[i].Duration} )");
                                    }
                                    Console.WriteLine("Select lecture to assign: ");
                                    lectureSelection = UserInputGetInt();
                                }
                                while (lectureSelection - 1 < 0 || lectureSelection - 1 > lectures.Count);


                                var selectedLecture = lectures[lectureSelection - 1];
                                var departments = _departmentService.GetAll();
                                int departmentSelection = -1;


                                do
                                {
                                    //select department
                                    Console.Clear();
                                    Console.WriteLine($"Selected Lecture name: {selectedLecture.LectureName} Lecture time: {selectedLecture.Time} (Duration: {selectedLecture.Duration} )");
                                    Console.WriteLine("Available Departments: ");
                                    if (departments.Count > 0)
                                    {
                                        for (int i = 0; i < departments.Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. Name: {departments[i].DepartmentName} Code: {departments[i].DepartmentCode}");
                                        }
                                        Console.WriteLine("Select department to assign to: ");
                                        departmentSelection = UserInputGetInt();
                                    }
                                    else
                                    {
                                        Console.Write("No departments found. Press any key to continue.");
                                    }
                                    Console.ReadKey();
                                }
                                while (departmentSelection - 1 < 0 || departmentSelection - 1 > departments.Count);

                                var selectedDepartment = departments[departmentSelection - 1];
                                ///ADDD TIME!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                Console.WriteLine($"Lecture ID :{selectedLecture.LectureId}");
                                Console.ReadKey();
                                _lectureService.AssignLectureToDepartment(selectedLecture, selectedDepartment.DepartmentId);
                                break;
                        }
                        break;

                    case 3: //Student options
                        Console.Clear();
                        Console.WriteLine("Student options.");
                        Console.WriteLine("1. Create new student.");    //Assigns student to department that lecture belongs to
                        switch (UserInputGetInt())
                        {
                            case 1: //Create new student
                                string? studentName = null;
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("Creating new student");
                                    Console.Write("Enter student's name:");
                                }
                                while (!_studentService.IsValidStudentName(studentName = UserInputGetString()));

                                string? studentLastName = null;
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("Creating new student");
                                    Console.Write("Enter student's last name:");
                                }
                                while (!_studentService.IsValidStudentLastName(studentLastName = UserInputGetString()));

                                //select department
                                var departments = _departmentService.GetAll();
                                int departmentSelection = -1;
                                do
                                {
                                    for (int i = 0; i < departments.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. Department name: {departments[i].DepartmentName}");
                                    }
                                    Console.WriteLine("Select department to assign to: ");
                                    departmentSelection = UserInputGetInt();
                                }
                                while (departmentSelection - 1 < 0 || departmentSelection - 1 > departments.Count);

                                var selectedLecture = departments[departmentSelection - 1];

                                //Generate student code
                                int studentCode = _studentService.GenerateNewStudentCode();

                                var newStudent = new Student()
                                {
                                    Name = studentName,
                                    LastName = studentLastName,
                                    StudentCode = studentCode,
                                    DepartmentId = departments[departmentSelection - 1].DepartmentId
                                };

                                //assign all lectures in department to student
                                var departmentLectures = _lectureService
                                    .GetAllDepartmentLectures()
                                    .Where(d => d.DepartmentId == newStudent.DepartmentId);

                                foreach (var dptLect in departmentLectures)
                                {
                                    newStudent.Lectures.Add(_lectureService.GetById(dptLect.LectureId));
                                }

                                //Create student and add to Db
                                _studentService.Create(newStudent);

                                break;
                        }
                        break;
                        break;
                }
            }
        }

        public int UserInputGetInt()
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else return -1;
        }

        public string? UserInputGetString()
        {
            return Console.ReadLine();
        }

        public TimeSpan UserInputGetTime()
        {
            TimeSpan time = TimeSpan.FromSeconds(0);
            do
            {
                Console.WriteLine("Enter hours: ");
                var hours = UserInputGetInt();
                if (hours == -1) continue;
                if (!_lectureService.IsValidTime(TimeSpan.FromHours(hours)))
                {
                    Console.WriteLine("Incorrect time format. Press any key to continue.");
                    continue;
                }
                time = time.Add(TimeSpan.FromHours(hours));

                Console.WriteLine("Enter minutes: ");
                var minutes = UserInputGetInt();
                if (minutes == -1) continue;
                if (!_lectureService.IsValidTime(TimeSpan.FromMinutes(minutes)))
                {
                    Console.WriteLine("Incorrect time format. Press any key to continue.");
                    continue;
                }
                time = time.Add(TimeSpan.FromMinutes(minutes));

            }
            while (!_lectureService.IsValidTime(time));
            return time;
        }

    }
}