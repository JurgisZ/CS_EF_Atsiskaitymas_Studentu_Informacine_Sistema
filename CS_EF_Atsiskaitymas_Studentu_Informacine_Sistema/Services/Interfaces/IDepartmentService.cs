using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces
{
    public interface IDepartmentService
    {
        int CreateDepartment(Department department);
        public List<Department> GetAll();
        public Department? GetById(int id);
        public string? GenerateUniqueDepartmentCode(string departmentName);
        public bool IsValidNewDepartmentName(string departmentName);
        public bool IsValidNewDepartmentCode(string? departmentCode);
        void Update(Department department);
    }
}