using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        public int Create(Department department);
        public List<Department> GetAll();
        public Department? GetById(int id);
        public Department? GetDepartmentByName(string departmentName);
        public Department? GetDepartmentByCode(string code);
        public void Update(Department department);
    }
}