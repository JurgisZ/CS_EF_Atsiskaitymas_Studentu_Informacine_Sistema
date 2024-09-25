using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    public class StudentLecture
    {
        public required int LectureId { get; set; }
        public Lecture Lecture { get; set; }
        public required int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
