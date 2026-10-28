using StudentManagerMVP.Models;

namespace StudentManagerMVP.Views
{
    /// <summary>Các ô nhập liệu mà Presenter có thể báo lỗi.</summary>
    public enum StudentField
    {
        StudentId,
        FullName,
        ClassName,
        Score
    }

    /// <summary>Loại thông báo để View chọn màu và biểu tượng phù hợp.</summary>
    public enum MessageType
    {
        Info,
        Success,
        Warning,
        Error
    }

    /// <summary>
    /// View interface: Presenter chỉ giao tiếp với Form qua interface này,
    /// không truy cập trực tiếp TextBox hay DataGridView.
    /// </summary>
    public interface IStudentView
    {
        // Dữ liệu nhập
        string StudentId { get; set; }
        string FullName { get; set; }
        string ClassName { get; set; }
        string ScoreText { get; set; }
        string SearchKeyword { get; set; }
        string SelectedStudentId { get; }

        // Hiển thị
        void ShowStudents(List<Student> students);
        void ShowMessage(string message, MessageType type);
        bool Confirm(string message);

        // Kiểm tra dữ liệu
        void SetFieldError(StudentField field, string message);
        void ClearErrors();
        void FocusField(StudentField field);

        void ClearInputs();
    }
}
