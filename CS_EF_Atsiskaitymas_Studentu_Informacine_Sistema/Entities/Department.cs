namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities
{
    internal class Department
    {
        public int DepartmentId { get; set; }    
        public required string DepartmentCode { get; set; }     //string. 3 letters + 3 numbers
        public required string DepartmentName { get; set; }     //string 3 - 100 symbols
        public ICollection<Student> Students { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<DepartmentLecture> DepartmentLectures { get; set; }
    }

}
