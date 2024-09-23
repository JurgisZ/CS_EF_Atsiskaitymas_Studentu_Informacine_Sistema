using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces
{
    internal interface IDepartmentRepository
    {
        int Create(Department department);
        List<Department> GetAll();
        Department? GetById(int id);
        void Update(Department department);
    }
}