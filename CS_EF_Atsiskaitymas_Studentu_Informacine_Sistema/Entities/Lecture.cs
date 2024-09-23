namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    internal class Lecture
    {
        public required int LectureId { get; set; }
        public required string LectureName { get; set; }    //unique, no less than 5 symbols
        public TimeSpan Time { get; set; }                  //correct 00:00 - 23:59 format
        public TimeSpan Duration {  get; set; }             //correct 00:00 - 23:59 format
        public ICollection<Department> Departments { get; set; }
        public ICollection<DepartmentLecture> DepartmentLectures { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<StudentLecture> StudentLectures { get; set; }
    }

}
