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
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IDepartmentLectureRepository _departmentLectureRepository;

        public LectureService(ILectureRepository repository, IDepartmentLectureRepository departmentLectureRepository)
        {
            _lectureRepository = repository;
            _departmentLectureRepository = departmentLectureRepository;
        }

        public int Create(Lecture lecture)
        {
            return _lectureRepository.Create(lecture);
        }

        public Lecture? GetById(int id)
        {
            return _lectureRepository.GetById(id);
        }
        public List<Lecture> GetAllLectures()
        {
            return _lectureRepository.GetAll();
        }

        public List<DepartmentLecture> GetAllDepartmentLectures()
        {
            return _departmentLectureRepository.GetAllDepartmentLectures();
        }

        public bool IsValidNewLectureName(string? lectureName) //string 5 or more symbols
        { 
            if(string.IsNullOrEmpty(lectureName)) 
                return false;

            if(lectureName.Length < 5 || lectureName.Length > 255) 
                return false;

            if (_lectureRepository.GetLectureByName(lectureName) != null)
                return false;

            return true;
        }

        public void AssignLectureToDepartment(Lecture lecture, int departmentId)
        {
            //VALIDATE LECTURE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _departmentLectureRepository.Create(
                new DepartmentLecture()
                { 
                    DepartmentId = departmentId,
                    LectureId = lecture.LectureId
                });
        }

        public bool IsValidTime(TimeSpan time)
        {

            return time.Hours >= 0 && time.Hours < 24 &&
                   time.Minutes >= 0 && time.Minutes < 60 &&
                   time.Seconds == 0;
        }
    }
}
