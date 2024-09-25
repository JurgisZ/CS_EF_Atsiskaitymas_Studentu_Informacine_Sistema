using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces
{
    public interface ILectureService
    {
        int Create(Lecture lecture);
        Lecture? GetById(int id);
        public bool IsValidNewLectureName(string? lectureName);
        public void AssignLectureToDepartment(Lecture lecture, int departmentId);
        public List<DepartmentLecture> GetAllDepartmentLectures();
        List<Lecture> GetAllLectures();
        public bool IsValidTime(TimeSpan time);
    }
}