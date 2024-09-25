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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public int CreateDepartment(Department department)
        {
            //Sukurti departameneto validacijas atskiruose metoduose

            //Check if DepartmentCode is unique
            if (_repository.GetAll().FirstOrDefault(e => e.DepartmentCode == department.DepartmentCode) != null)
                return -1;

            //Check if DepartmentName is Unique
            if (_repository.GetAll().FirstOrDefault(e => e.DepartmentName == department.DepartmentName) != null)
                return -1;

            //Check DepartmentCodeLenght == 6
            if (department.DepartmentCode.Length != 6)
                return -1;

            //Check: first 3 chars are letters, check: chars 4 - 6 are numbers
            for (int i = 0; i < department.DepartmentCode.Length - 1; i++)
            {
                if (i <= 2)
                    if (!char.IsLetter(department.DepartmentCode.ElementAt(i)))
                        return -1;
                if (i > 2)
                    if (!char.IsDigit(department.DepartmentCode.ElementAt(i)))
                        return -1;
            }
            _repository.Create(department);
            return department.DepartmentId;
        }

        public string? GenerateUniqueDepartmentCode(string departmentName)
        {
            //Imam departamento pavadinimo 3 raides pirmas
            //Generuojam skaičiu 001 - 999, Jei < 10 pridedam du nulius priekyje, jei < 100 pridedam viena nuli priekyje
            
            if (departmentName.Length < 3) return null;
            string departmentCode = departmentName.Substring(0, 3);

            while (true)
            {
                Random rand = new Random();
                int numberPart = rand.Next(1, 1000); // 1-999

                //galima imt visus is db ir surusiuot, verst skaiciu dali is string i int ir pasalint 0 is priekio ir ++

                string numberPartAsString = numberPart.ToString();
                if (numberPartAsString.Length == 2) numberPartAsString = '0' + numberPartAsString;
                if (numberPartAsString.Length == 1) numberPartAsString = "00" + numberPartAsString;
                departmentCode += numberPartAsString;

                if (IsValidNewDepartmentCode(departmentCode))
                {
                    return departmentCode;
                }
                
            }

        }

        //Department name validator
        public bool IsValidNewDepartmentName(string? departmentName)
        {
            if (string.IsNullOrEmpty(departmentName))
                return false;

            if (departmentName.Length < 3)
                return false;

            //Already exists?
            if (_repository.GetDepartmentByName(departmentName) != null)
                return false;

            return true;     
        }

        public bool IsValidNewDepartmentCode(string? departmentCode)
        {
            if (string.IsNullOrEmpty(departmentCode))
                return false;

            if(departmentCode.Length != 6 )
                return false;

            if(_repository.GetDepartmentByCode(departmentCode) != null)
                return false;

            return true;
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
