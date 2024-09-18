using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Studentu informacine sistema");

            using var context = new StudentsDbContext();
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
        }
    }
}
