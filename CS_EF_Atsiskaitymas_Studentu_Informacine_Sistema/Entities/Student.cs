using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    internal class Student
    {
        public required int StudentId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; } //string bus
        public Department Department { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<StudentLecture> StudentLectures { get; set; }
    }

}
