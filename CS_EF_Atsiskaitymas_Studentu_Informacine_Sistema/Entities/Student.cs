using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string Name { get; set; }       //string 2 - 50 symbols
        public required string LastName { get; set; }   //string 2 - 50 symbols
        public required int StudentCode { get; set; }
        public string Email { get; set; }               //valid email format
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
        public ICollection<StudentLecture> StudentLectures { get; set; }
    }

}
