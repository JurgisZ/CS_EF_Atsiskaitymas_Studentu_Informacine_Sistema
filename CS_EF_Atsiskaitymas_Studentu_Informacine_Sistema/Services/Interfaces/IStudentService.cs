using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces
{
    internal interface IStudentService
    {
        void AddStudentToDepartment(Student student, int departmentId);
        int Create(Student student);
        List<Student> GetAll();
        Student? GetById(int id);
    }
}