using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces
{
    internal interface IDepartmentService
    {
        int CreateDepartment(Department department);
        List<Department> GetAll();
        Department? GetById(int id);
        public string? GenerateUniqueDepartmentCode(string departmentName);
        void Update(Department department);
    }
}