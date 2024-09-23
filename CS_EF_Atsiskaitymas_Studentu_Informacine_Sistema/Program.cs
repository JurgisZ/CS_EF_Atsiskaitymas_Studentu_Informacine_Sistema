using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentIs = new StudentsIS();
            studentIs.Run();

        }
    }
}
