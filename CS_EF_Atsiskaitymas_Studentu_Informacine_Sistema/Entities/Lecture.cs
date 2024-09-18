namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    internal class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<DepartmentLecture> DepartmentLectures { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<StudentLecture> StudentLectures { get; set; }
    }

}
