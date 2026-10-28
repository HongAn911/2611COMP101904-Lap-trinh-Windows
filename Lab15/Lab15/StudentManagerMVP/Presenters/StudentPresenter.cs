using System.Globalization;
using System.Text.RegularExpressions;
using StudentManagerMVP.Models;
using StudentManagerMVP.Repositories;
using StudentManagerMVP.Views;

namespace StudentManagerMVP.Presenters
{
    /// <summary>
    /// Presenter: xử lý toàn bộ nghiệp vụ Load / Thêm / Xóa / Tìm kiếm.
    /// Không dùng System.Windows.Forms, không đụng tới TextBox hay DataGridView;
    /// mọi trao đổi với giao diện đều đi qua IStudentView.
    /// </summary>
    public class StudentPresenter
    {
        private readonly IStudentView _view;
        private readonly IStudentRepository _repository;

        private static readonly Regex IdPattern = new Regex(@"^[A-Za-z0-9]{3,10}$");
        private static readonly Regex NamePattern = new Regex(@"^[\p{L}\s]{2,50}$");

        public StudentPresenter(IStudentView view, IStudentRepository repository)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // ===================== LOAD =====================
        public void LoadStudents()
        {
            List<Student> students = _repository.GetAll();
            _view.ShowStudents(students);
        }

        // ===================== THÊM =====================
        public void AddStudent()
        {
            _view.ClearErrors();

            string id = (_view.StudentId ?? string.Empty).Trim().ToUpperInvariant();
            string name = NormalizeSpaces(_view.FullName);
            string className = (_view.ClassName ?? string.Empty).Trim();
            string scoreText = (_view.ScoreText ?? string.Empty).Trim();

            // 1. Kiểm tra dữ liệu rỗng
            var emptyFields = new List<StudentField>();
            if (id.Length == 0) emptyFields.Add(StudentField.StudentId);
            if (name.Length == 0) emptyFields.Add(StudentField.FullName);
            if (className.Length == 0) emptyFields.Add(StudentField.ClassName);
            if (scoreText.Length == 0) emptyFields.Add(StudentField.Score);

            if (emptyFields.Count > 0)
            {
                foreach (StudentField field in emptyFields)
                    _view.SetFieldError(field, "Không được để trống.");
                _view.FocusField(emptyFields[0]);
                _view.ShowMessage("Vui lòng nhập đầy đủ Mã SV, Họ tên, Lớp và Điểm.", MessageType.Warning);
                return;
            }

            // 2. Kiểm tra dữ liệu sai kiểu / sai định dạng
            if (!IdPattern.IsMatch(id))
            {
                Fail(StudentField.StudentId, "Mã SV chỉ gồm chữ và số, dài 3–10 ký tự (ví dụ: SV009).");
                return;
            }

            if (!NamePattern.IsMatch(name))
            {
                Fail(StudentField.FullName, "Họ tên chỉ gồm chữ cái và khoảng trắng, dài 2–50 ký tự.");
                return;
            }

            if (!TryParseScore(scoreText, out double score))
            {
                Fail(StudentField.Score, "Điểm phải là số (ví dụ: 7.5 hoặc 7,5).");
                return;
            }

            if (score < 0 || score > 10)
            {
                Fail(StudentField.Score, "Điểm phải nằm trong khoảng 0 đến 10.");
                return;
            }

            // 3. Kiểm tra trùng mã
            if (_repository.Exists(id))
            {
                Fail(StudentField.StudentId, $"Mã SV \"{id}\" đã tồn tại. Vui lòng nhập mã khác.");
                return;
            }

            // 4. Lưu dữ liệu
            _repository.Add(new Student(id, name, className, Math.Round(score, 2)));
            LoadStudents();
            _view.ClearInputs();
            _view.FocusField(StudentField.StudentId);
            _view.ShowMessage($"Đã thêm sinh viên {id} - {name} thành công.", MessageType.Success);
        }

        // ===================== XÓA THEO MÃ =====================
        public void DeleteStudent()
        {
            _view.ClearErrors();

            string id = (_view.StudentId ?? string.Empty).Trim();
            if (id.Length == 0) id = (_view.SelectedStudentId ?? string.Empty).Trim();

            if (id.Length == 0)
            {
                Fail(StudentField.StudentId, "Nhập Mã SV cần xóa hoặc chọn một dòng trong danh sách.");
                return;
            }

            Student student = _repository.GetById(id);
            if (student == null)
            {
                Fail(StudentField.StudentId, $"Không tìm thấy sinh viên có mã \"{id.ToUpperInvariant()}\".");
                return;
            }

            if (!_view.Confirm($"Bạn có chắc muốn xóa sinh viên {student.StudentId} - {student.FullName}?"))
            {
                _view.ShowMessage("Đã hủy thao tác xóa.", MessageType.Info);
                return;
            }

            _repository.Delete(student.StudentId);
            LoadStudents();
            _view.ClearInputs();
            _view.ShowMessage($"Đã xóa sinh viên {student.StudentId} - {student.FullName}.", MessageType.Success);
        }

        // ===================== TÌM KIẾM =====================
        public void SearchStudents()
        {
            _view.ClearErrors();
            string keyword = (_view.SearchKeyword ?? string.Empty).Trim();

            if (keyword.Length == 0)
            {
                LoadStudents();
                _view.ShowMessage("Chưa nhập từ khóa nên hiển thị toàn bộ danh sách.", MessageType.Info);
                return;
            }

            List<Student> result = _repository.Search(keyword);
            _view.ShowStudents(result);

            if (result.Count == 0)
                _view.ShowMessage($"Không tìm thấy sinh viên nào khớp với \"{keyword}\".", MessageType.Warning);
            else
                _view.ShowMessage($"Tìm thấy {result.Count} sinh viên khớp với \"{keyword}\".", MessageType.Info);
        }

        // ===================== HỖ TRỢ =====================

        /// <summary>Khi người dùng chọn một dòng, đưa dữ liệu lên các ô nhập.</summary>
        public void SelectStudent(string studentId)
        {
            Student student = _repository.GetById(studentId);
            if (student == null) return;

            _view.ClearErrors();
            _view.StudentId = student.StudentId;
            _view.FullName = student.FullName;
            _view.ClassName = student.ClassName;
            _view.ScoreText = student.Score.ToString("0.##", CultureInfo.InvariantCulture);
        }

        /// <summary>Làm mới: xóa ô nhập, ô tìm kiếm và tải lại danh sách.</summary>
        public void ResetForm()
        {
            _view.ClearErrors();
            _view.ClearInputs();
            _view.SearchKeyword = string.Empty;
            LoadStudents();
            _view.FocusField(StudentField.StudentId);
            _view.ShowMessage("Đã làm mới biểu mẫu và tải lại danh sách.", MessageType.Info);
        }

        private void Fail(StudentField field, string message)
        {
            _view.SetFieldError(field, message);
            _view.FocusField(field);
            _view.ShowMessage(message, MessageType.Error);
        }

        private static bool TryParseScore(string text, out double score)
        {
            string normalized = text.Replace(',', '.');
            bool ok = double.TryParse(normalized,
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture, out score);
            return ok && !double.IsNaN(score) && !double.IsInfinity(score);
        }

        private static string NormalizeSpaces(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            return Regex.Replace(text.Trim(), @"\s+", " ");
        }
    }
}
