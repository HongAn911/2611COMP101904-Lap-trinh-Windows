using StudentReportDemo.Forms;

namespace StudentReportDemo
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi động của ứng dụng.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmBaoCaoSinhVien());
        }
    }
}
