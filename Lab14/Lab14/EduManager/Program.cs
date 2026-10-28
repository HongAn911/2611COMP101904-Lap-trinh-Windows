using EduManager.GUI;

namespace EduManager
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi động của ứng dụng: mở form Quản lý môn học.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMonHoc());
        }
    }
}
