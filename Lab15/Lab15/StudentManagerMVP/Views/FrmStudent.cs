using StudentManagerMVP.Models;
using StudentManagerMVP.Presenters;
using StudentManagerMVP.Repositories;

namespace StudentManagerMVP.Views
{
    /// <summary>
    /// View: Form chỉ hiển thị và chuyển sự kiện cho Presenter.
    /// Mọi Button Click chỉ gọi đúng một phương thức của _presenter.
    /// </summary>
    public partial class FrmStudent : Form, IStudentView
    {
        private static readonly Color NormalInputColor = Color.White;
        private static readonly Color ErrorInputColor = Color.FromArgb(254, 226, 226);

        private readonly StudentPresenter _presenter;

        public FrmStudent(IStudentRepository repository)
        {
            InitializeComponent();
            _presenter = new StudentPresenter(this, repository);
        }

        #region IStudentView - dữ liệu nhập

        public string StudentId
        {
            get => txtStudentId.Text;
            set => txtStudentId.Text = value;
        }

        public string FullName
        {
            get => txtFullName.Text;
            set => txtFullName.Text = value;
        }

        public string ClassName
        {
            get => txtClassName.Text;
            set => txtClassName.Text = value;
        }

        public string ScoreText
        {
            get => txtScore.Text;
            set => txtScore.Text = value;
        }

        public string SearchKeyword
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public string SelectedStudentId
        {
            get
            {
                if (dgvStudents.CurrentRow != null && dgvStudents.CurrentRow.Selected
                    && dgvStudents.CurrentRow.DataBoundItem is Student student)
                {
                    return student.StudentId;
                }
                return string.Empty;
            }
        }

        #endregion

        #region IStudentView - hiển thị

        public void ShowStudents(List<Student> students)
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = new List<Student>(students);
            dgvStudents.ClearSelection();
            lblCount.Text = $"Tổng: {students.Count} sinh viên";
        }

        public void ShowMessage(string message, MessageType type)
        {
            lblStatus.Text = message;

            MessageBoxIcon icon;
            string caption;
            switch (type)
            {
                case MessageType.Success:
                    lblStatus.ForeColor = Color.FromArgb(21, 128, 61);
                    icon = MessageBoxIcon.Information;
                    caption = "Thành công";
                    break;
                case MessageType.Warning:
                    lblStatus.ForeColor = Color.FromArgb(180, 83, 9);
                    icon = MessageBoxIcon.Warning;
                    caption = "Lưu ý";
                    break;
                case MessageType.Error:
                    lblStatus.ForeColor = Color.FromArgb(185, 28, 28);
                    icon = MessageBoxIcon.Error;
                    caption = "Lỗi dữ liệu";
                    break;
                default:
                    lblStatus.ForeColor = Color.FromArgb(30, 58, 138);
                    icon = MessageBoxIcon.Information;
                    caption = "Thông báo";
                    break;
            }

            // Thông báo thông tin chỉ hiện ở thanh trạng thái để không làm phiền người dùng;
            // thành công / cảnh báo / lỗi thì hiện thêm hộp thoại.
            if (type != MessageType.Info)
            {
                MessageBox.Show(this, message, caption, MessageBoxButtons.OK, icon);
            }
        }

        public bool Confirm(string message)
        {
            return MessageBox.Show(this, message, "Xác nhận",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        #endregion

        #region IStudentView - kiểm tra dữ liệu

        public void SetFieldError(StudentField field, string message)
        {
            TextBox box = GetTextBox(field);
            errorProvider.SetError(box, message);
            box.BackColor = ErrorInputColor;
        }

        public void ClearErrors()
        {
            foreach (TextBox box in new[] { txtStudentId, txtFullName, txtClassName, txtScore })
            {
                errorProvider.SetError(box, string.Empty);
                box.BackColor = NormalInputColor;
            }
        }

        public void FocusField(StudentField field)
        {
            TextBox box = GetTextBox(field);
            box.Focus();
            box.SelectAll();
        }

        public void ClearInputs()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtClassName.Clear();
            txtScore.Clear();
            dgvStudents.ClearSelection();
        }

        private TextBox GetTextBox(StudentField field)
        {
            switch (field)
            {
                case StudentField.FullName: return txtFullName;
                case StudentField.ClassName: return txtClassName;
                case StudentField.Score: return txtScore;
                default: return txtStudentId;
            }
        }

        #endregion

        #region Sự kiện - chỉ gọi Presenter

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            _presenter.LoadStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _presenter.AddStudent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _presenter.DeleteStudent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.SearchStudents();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _presenter.LoadStudents();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _presenter.ResetForm();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _presenter.SearchStudents();
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _presenter.SelectStudent(SelectedStudentId);
            }
        }

        #endregion

        #region Trang trí hiển thị (chỉ là giao diện, không phải nghiệp vụ)

        private void dgvStudents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string columnName = dgvStudents.Columns[e.ColumnIndex].Name;

            if (columnName == colRank.Name)
            {
                switch (e.Value.ToString())
                {
                    case "Giỏi":
                        e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                        break;
                    case "Khá":
                        e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                        break;
                    case "Trung bình":
                        e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                        break;
                    default:
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                        break;
                }
            }
            else if (columnName == colScore.Name && e.Value is double score && score < 5.0)
            {
                e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        #endregion
    }
}
