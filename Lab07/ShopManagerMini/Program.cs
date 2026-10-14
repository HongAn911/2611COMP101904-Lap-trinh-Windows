using ShopManagerMini.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini
{
    internal static class Program
    {
        /// <summary>
        /// Điểm vào của ứng dụng.
        /// Luồng chạy: FrmLogin (ShowDialog) -> FrmMain (MDI Parent).
        /// Khi người dùng chọn "Đăng xuất", vòng lặp quay lại hiển thị FrmLogin.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                User currentUser;

                // Hiển thị form đăng nhập dạng modal
                using (var login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        return; // Người dùng bấm Thoát hoặc đóng form đăng nhập
                    }
                    currentUser = login.LoggedInUser;
                }

                // Mở form chính và truyền thông tin người dùng qua constructor
                var main = new FrmMain(currentUser);
                Application.Run(main);

                // Nếu không phải đăng xuất thì kết thúc chương trình
                if (!main.IsLoggedOut)
                {
                    return;
                }
            }
        }
    }
}
