using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            var dbContext = new StudentsDbContext();

            IStudentRepository studentRepository = new StudentRepository(dbContext);
            IStudentLectureRepository studentLectureRepository = new StudentLectureRepository(dbContext);
            var studentService = new StudentService(studentRepository, studentLectureRepository);

            IDepartmentRepository departmentRepository = new DepartmentRepository(dbContext);
            var departmentService = new DepartmentService(departmentRepository);

            ILectureRepository lectureRepository = new LectureRepository(dbContext);
            IDepartmentLectureRepository departmentLectureRepository = new DepartmentLectureRepository(dbContext);
            var lectureService = new LectureService(lectureRepository, departmentLectureRepository);

            var studentIs = new StudentsIS(studentService, departmentService, lectureService);
            studentIs.Run();

        }
    }
}
