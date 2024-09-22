using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    internal class DepartmentLecture
    {
        public required string DepartmentId { get; set; }
        public Department Department { get; set; }
        public string LectureName { get; set; }
        public Lecture Lecture { get; set; }
    }
}
