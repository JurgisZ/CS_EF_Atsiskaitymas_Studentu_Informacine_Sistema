using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentsDbContext _context;
        public DepartmentRepository(StudentsDbContext context)
        {
            _context = context;

        }

        //CREATE - patikrinti ar dpt name yra unikalus
        public int Create(Department department)
        {
            _context.Add(department);
            _context.SaveChanges();
            return department.DepartmentId;
        }

        public Department? GetById(int id)
        {
            return _context.Departments
                .Include(l => l.Lectures)
                .Include(s => s.Students)
                .FirstOrDefault(e => e.DepartmentId == id);
        }

        public List<Department>? GetAll()
        {
            return _context.Departments.ToList();
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }


    }

}
