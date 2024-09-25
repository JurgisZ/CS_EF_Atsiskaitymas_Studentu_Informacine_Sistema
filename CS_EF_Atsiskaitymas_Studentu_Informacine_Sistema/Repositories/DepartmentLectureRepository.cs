using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories
{
    public class DepartmentLectureRepository : IDepartmentLectureRepository
    {
        private readonly StudentsDbContext _context;
        public DepartmentLectureRepository(StudentsDbContext context)
        {
            _context = context;

        }

        public void Create(DepartmentLecture departmentLecture)
        {
            _context.DepartmentLectures.Add(departmentLecture);
            _context.SaveChanges();
        }

        public List<DepartmentLecture> GetAllDepartmentLectures() 
        {
            return _context.DepartmentLectures.ToList();
        }

        public void Update(DepartmentLecture departmentLecture)
        {
            _context.DepartmentLectures.Update(departmentLecture);
            _context.SaveChanges();
        }
    }
}
