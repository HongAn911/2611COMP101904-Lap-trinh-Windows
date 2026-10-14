namespace ShopManagerMini.Forms
{
    /// <summary>
    /// Form giới thiệu ứng dụng (thông tin ứng dụng, tên sinh viên, lớp).
    /// </summary>
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
