using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces
{
    internal interface IDepartmentRepository
    {
        public int Create(Department department);
        public List<Department> GetAll();
        public Department? GetById(int id);
        public Department? GetByName(string departmentName);
        public void Update(Department department);
    }
}