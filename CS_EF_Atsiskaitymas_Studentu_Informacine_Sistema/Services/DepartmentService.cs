using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services
{
    internal class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public int CreateDepartment(Department department)
        {
            //Check if DepartmentCode is unique
            if (_repository.GetAll().FirstOrDefault(e => e.DepartmentCode == department.DepartmentCode) != null)
                return -1;

            //Check if DepartmentName is Unique
            if (_repository.GetAll().FirstOrDefault(e => e.DepartmentName == department.DepartmentName) != null)
                return -1;

            //Check DepartmentCodeLenght == 6
            if (department.DepartmentCode.Length != 6) 
                return -1;

            //Check: first 3 chars are letters, check: chars 4-6 are numbers
            for(int i = 0; i < department.DepartmentCode.Length - 1; i++)
            {
                if (i <= 2)
                    if (!char.IsLetter(department.DepartmentCode.ElementAt(i)))
                        return -1;
                if(i > 2)
                    if (!char.IsDigit(department.DepartmentCode.ElementAt(i)))
                        return -1;
            }
            _repository.Create(department);
            return department.DepartmentId;
        }

        public Department? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Department> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Department department)
        {
            _repository.Update(department);
        }
    }
}
