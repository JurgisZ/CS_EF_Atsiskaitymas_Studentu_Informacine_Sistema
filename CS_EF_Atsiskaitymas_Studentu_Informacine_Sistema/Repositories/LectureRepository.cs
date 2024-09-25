using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly StudentsDbContext _context;
        public LectureRepository(StudentsDbContext context)
        {
            _context = context;
        }

        public int Create(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            _context.SaveChanges();
            return lecture.LectureId;
        }

        public Lecture? GetById(int id)
        {
            return _context.Lectures.FirstOrDefault(e => e.LectureId == id);
        }

        public List<Lecture> GetAll()
        {
            return _context.Lectures
                .Include(d => d.Departments)
                .Include(s => s.Students)
                .ToList();
        }

        public Lecture? GetLectureByName(string lectureName) 
        {
            return _context.Lectures
                .Include(d => d.Departments)
                .Include(s => s.Students)
                .FirstOrDefault(l => l.LectureName == lectureName);
        }

        //public Department? GetDepartmentByCode(string code)
        //{
        //    return _context.Departments
        //        .Include(s => s.Students)
        //        .Include(l => l.Lectures)
        //        .FirstOrDefault(d => d.DepartmentCode == code);
        //}

        public void Update(Lecture lecture)
        {
            _context.Lectures.Update(lecture);
            _context.SaveChanges();
        }
    }
}
