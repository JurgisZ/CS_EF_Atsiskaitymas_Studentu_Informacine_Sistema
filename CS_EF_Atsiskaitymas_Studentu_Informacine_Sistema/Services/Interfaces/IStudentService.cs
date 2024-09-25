using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces
{
    public interface IStudentService
    {
        public void AddStudentToDepartment(Student student, int departmentId);
        public int Create(Student student);
        public List<Student> GetAll();
        public Student? GetById(int id);
        public bool IsValidStudentName(string? name);
        public bool IsValidStudentLastName(string? name);
        public int GenerateNewStudentCode();
    }
}