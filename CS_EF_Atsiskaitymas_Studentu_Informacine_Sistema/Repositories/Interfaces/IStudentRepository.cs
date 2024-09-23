using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces
{
    internal interface IStudentRepository
    {
        int Create(Student student);
        public Student? GetById(int id);
        public List<Student> GetAll();
        public void Update(Student student);
    }
}