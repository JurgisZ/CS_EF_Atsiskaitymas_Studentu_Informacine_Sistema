using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces
{
    internal interface IStudentLectureRepository
    {
        void Create(StudentLecture studentLecture);
        void Update(StudentLecture studentLecture);
    }
}