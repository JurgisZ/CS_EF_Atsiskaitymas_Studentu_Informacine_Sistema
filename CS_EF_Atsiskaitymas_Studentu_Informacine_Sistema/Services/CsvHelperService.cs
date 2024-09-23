using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services
{
    internal static class CsvHelperService  //Helper service for DB seeding
    {
        public static List<Student> StudentsFromCsv(string filePath)
        {
            var students = new List<Student>();
            try
            {
                using var reader = new StreamReader(filePath);
                string csvLine = null;
                while (null != (csvLine = reader.ReadLine()))
                {
                    var csvValues = csvLine.Split(',');
                    var student = new Student()
                    {
                        //VALIDATIONS!!!!!!!!!!!!!!
                        StudentId = int.Parse(csvValues[0]),
                        Name = csvValues[1],
                        LastName = csvValues[2],
                        StudentCode = csvValues[3],
                        Email = csvValues[4],
                        DepartmentId = int.Parse(csvValues[5])
                    };
                    students.Add(student);
                }
            }
            catch (Exception ex)
            {
                //NO CW!
                Console.WriteLine(ex.Message);
            }

            return students;
        }

        public static List<Department> DepartmentsFromCsv(string filePath)
        {
            var departments = new List<Department>();
            try
            {
                using var reader = new StreamReader(filePath);
                string csvLine = null;
                while (null != (csvLine = reader.ReadLine()))
                {
                    var csvValues = csvLine.Split(',');
                    var department = new Department()
                    {
                        DepartmentId = int.Parse(csvValues[0]),
                        DepartmentCode = csvValues[1],
                        DepartmentName = csvValues[2]
                    };
                    departments.Add(department);
                }

            }
            catch(Exception ex)
            {
                //NO CW!
                Console.WriteLine(ex.Message);
            }
            return departments;
        }

        public static List<Lecture> LecturesFromCsv(string filePath)
        {
            var lectures = new List<Lecture>();
            try
            {
                using var reader = new StreamReader(filePath);
                string csvLine = null;
                while (null != (csvLine = reader.ReadLine()))
                {
                    var csvValues = csvLine.Split(',');
                    var lecture = new Lecture()
                    {
                        LectureId = int.Parse(csvValues[0]),
                        LectureName = csvValues[1],
                        Time = TimeSpan.Parse(csvValues[2]),
                        Duration = TimeSpan.Parse(csvValues[3])
                    };
                    lectures.Add(lecture);
                }

            }
            catch (Exception ex)
            {
                //NO CW!
                Console.WriteLine(ex.Message);
            }
            return lectures;
        }

        public static List<DepartmentLecture> DepartmentLecturesFromCsv(string filePath)
        {
            var departmentLectures = new List<DepartmentLecture>();
            try
            {
                using var reader = new StreamReader(filePath);
                string csvLine = null;
                while (null != (csvLine = reader.ReadLine()))
                {
                    var csvValues = csvLine.Split(',');
                    var departmentLecture = new DepartmentLecture()
                    {
                        DepartmentId = int.Parse(csvValues[0]),
                        LectureId = int.Parse(csvValues[1]),
                    };
                    departmentLectures.Add(departmentLecture);
                }

            }
            catch (Exception ex)
            {
                //NO CW!
                Console.WriteLine(ex.Message);
            }
            return departmentLectures;
        }


        public static List<StudentLecture> StudentLecturesFromCsv(string filePath)
        {
            var studentLectures = new List<StudentLecture>();
            try
            {
                using var reader = new StreamReader(filePath);
                string csvLine = null;
                while (null != (csvLine = reader.ReadLine()))
                {
                    var csvValues = csvLine.Split(',');
                    var studentLecture = new StudentLecture()
                    {
                        StudentId = int.Parse(csvValues[0]),
                        LectureId = int.Parse(csvValues[1]),
                    };
                    studentLectures.Add(studentLecture);
                }

            }
            catch (Exception ex)
            {
                //NO CW!
                Console.WriteLine(ex.Message);  
            }
            return studentLectures;
        }

    }
}
