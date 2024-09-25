using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        int Create(Student student);
        public Student? GetById(int id);
        public Student? GetByCode(int studentCode);
        public List<Student> GetAll();
        public void Update(Student student);
    }
}