using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces
{
    public interface IDepartmentLectureRepository
    {
        void Create(DepartmentLecture departmentLecture);
        public List<DepartmentLecture> GetAllDepartmentLectures();
        void Update(DepartmentLecture departmentLecture);
    }
}