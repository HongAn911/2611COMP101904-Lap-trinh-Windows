using StudentManagerMVP.Repositories;
using StudentManagerMVP.Views;

namespace StudentManagerMVP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Tạo Repository rồi đưa vào View; View tự tạo Presenter với chính nó và Repository này.
            IStudentRepository repository = new StudentRepository();
            Application.Run(new FrmStudent(repository));
        }
    }
}
