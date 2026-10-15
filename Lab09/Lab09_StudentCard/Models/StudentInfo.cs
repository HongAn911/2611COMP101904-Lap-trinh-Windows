namespace Lab09_StudentCard.Models;

/// <summary>
/// Dữ liệu một thẻ sinh viên (lấy từ các control trên Form).
/// Dùng record để tạo "bản chụp" bất biến: Preview và Print đọc cùng một đối tượng.
/// </summary>
public sealed record StudentInfo(
    string StudentId,
    string FullName,
    string ClassName,
    string Faculty,
    string Course,
    DateTime BirthDate,
    string Gender);
