using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces
{
    internal interface IDepartmentLectureRepository
    {
        void Create(DepartmentLecture departmentLecture);
        void Update(DepartmentLecture departmentLecture);
    }
}