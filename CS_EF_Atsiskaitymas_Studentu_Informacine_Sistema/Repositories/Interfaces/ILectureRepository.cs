using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces
{
    public interface ILectureRepository
    {
        int Create(Lecture lecture);
        List<Lecture> GetAll();
        Lecture? GetById(int id);
        public Lecture? GetLectureByName(string lectureName);
        void Update(Lecture lecture);
    }
}