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
    internal class LectureRepository : ILectureRepository
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
            return _context.Lectures.ToList();
        }

        public void Update(Lecture lecture)
        {
            _context.Lectures.Update(lecture);
            _context.SaveChanges();
        }
    }
}
