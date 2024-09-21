using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    internal class DepartmentLecture
    {
        public int DepartmentId { get; set; }   //string bus
        public Department Department { get; set; }
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}
