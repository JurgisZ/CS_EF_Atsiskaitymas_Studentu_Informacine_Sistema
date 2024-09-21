namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    internal class Department
    {
        public int DepartmentId { get; set; }    //string 3 sk 3 raides
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<DepartmentLecture> DepartmentLectures { get; set; }
    }

}
