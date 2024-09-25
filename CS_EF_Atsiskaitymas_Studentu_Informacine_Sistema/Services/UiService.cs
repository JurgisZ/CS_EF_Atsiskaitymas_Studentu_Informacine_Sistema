using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services
{
    internal class UiService
    {
        private readonly IDepartmentService _departmentService;

        public UiService(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public void DisplayHelloMessage()
        {
            Console.WriteLine("Welcome to StudentIS.");
        }

        public void DisplayMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Department options");
                //Create new department
                //Add students to existing department
                //Add lectures to department (from existing in DB)

                Console.WriteLine("2. Lecture options");
                //Add new lecture
                //Assign lecture to a department

                Console.WriteLine("3. Student options");
                //Add new student
                //Assign student to department (add lectures from department to student)

                Console.Write("Select option: ");
                switch(UserInputGetInt())
                {
                    case 1:
                        //Create new department
                        Console.Write("Enter a name for new department: ");
                        var departmentName = UserInputGetString();


                        var newDepartment = new Department()
                        {
                            DepartmentCode = _departmentService
                        };
                        _departmentService.CreateDepartment(newDepartment);
                        break;
                }

            }
        }

        public int UserInputGetInt()
        {
            if(int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else return -1;
        }

        public string? UserInputGetString()
        {
            return Console.ReadLine();
        }
        
    }
}
