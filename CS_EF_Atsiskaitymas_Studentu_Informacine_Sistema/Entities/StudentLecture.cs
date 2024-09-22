using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    internal class StudentLecture
    {
        public string LectureName { get; set; }
        public Lecture Lecture { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
