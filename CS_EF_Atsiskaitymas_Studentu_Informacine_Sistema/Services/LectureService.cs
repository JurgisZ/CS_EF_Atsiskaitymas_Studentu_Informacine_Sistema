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
    internal class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IDepartmentLectureRepository _departmentLectureRepository;

        public LectureService(ILectureRepository repository, IDepartmentLectureRepository departmentLectureRepository)
        {
            _lectureRepository = repository;
        }

        public int Create(Lecture lecture)
        {
            return _lectureRepository.Create(lecture);
        }

        public Lecture? GetById(int id)
        {
            return _lectureRepository.GetById(id);
        }
        public List<Lecture> GetAll()
        {
            return _lectureRepository.GetAll();
        }

        public void AddLectureToDepartment(Lecture lecture, int departmentId)
        {
            _lectureRepository.Create(lecture);
            _departmentLectureRepository.Create(
                new DepartmentLecture()
                { 
                    DepartmentId = departmentId,
                    LectureId = lecture.LectureId
                });
        }
    }
}
