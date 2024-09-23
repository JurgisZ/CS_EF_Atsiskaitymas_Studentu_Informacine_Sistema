using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces
{
    internal interface ILectureService
    {
        int Create(Lecture lecture);
        Lecture? GetById(int id);
        List<Lecture> GetAll();
    }
}