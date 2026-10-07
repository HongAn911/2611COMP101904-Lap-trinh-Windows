namespace Lab05
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmDangKyKhoaHoc());
        }
    }
}
