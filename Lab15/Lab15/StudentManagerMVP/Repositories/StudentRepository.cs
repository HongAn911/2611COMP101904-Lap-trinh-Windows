using System.Globalization;
using System.Text;
using StudentManagerMVP.Models;

namespace StudentManagerMVP.Repositories
{
    /// <summary>
    /// Lưu dữ liệu trong bộ nhớ bằng List&lt;Student&gt;, có sẵn dữ liệu mẫu
    /// để giảng viên kiểm tra ngay khi chạy chương trình.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students;

        public StudentRepository()
        {
            _students = new List<Student>
            {
                new Student("SV001", "Nguyễn Văn An",      "49.01.SPTIN.A", 8.5),
                new Student("SV002", "Trần Thị Bình",      "49.01.SPTIN.A", 7.2),
                new Student("SV003", "Lê Hoàng Cường",     "49.01.SPTIN.B", 6.0),
                new Student("SV004", "Phạm Ngọc Diệp",     "49.01.SPTIN.B", 9.1),
                new Student("SV005", "Võ Minh Đức",        "49.01.CNTT.A",  4.5),
                new Student("SV006", "Huỳnh Thị Hồng Ân",  "49.01.SPTIN.A", 8.8),
                new Student("SV007", "Đặng Quốc Huy",      "49.01.CNTT.A",  5.6),
                new Student("SV008", "Bùi Thanh Hương",    "49.01.CNTT.B",  7.9)
            };
        }

        public List<Student> GetAll()
        {
            return _students.OrderBy(s => s.StudentId).ToList();
        }

        public Student GetById(string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId)) return null;
            return _students.FirstOrDefault(s =>
                s.StudentId.Equals(studentId.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public bool Exists(string studentId)
        {
            return GetById(studentId) != null;
        }

        public void Add(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            _students.Add(student);
        }

        public bool Delete(string studentId)
        {
            Student student = GetById(studentId);
            if (student == null) return false;
            return _students.Remove(student);
        }

        /// <summary>
        /// Tìm theo mã hoặc một phần họ tên, không phân biệt hoa/thường và dấu tiếng Việt
        /// (gõ "huong" vẫn tìm được "Hương").
        /// </summary>
        public List<Student> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();

            string key = Normalize(keyword);
            return _students
                .Where(s => Normalize(s.StudentId).Contains(key) || Normalize(s.FullName).Contains(key))
                .OrderBy(s => s.StudentId)
                .ToList();
        }

        private static string Normalize(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            string decomposed = text.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();
            foreach (char c in decomposed)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }
            return builder.ToString().Normalize(NormalizationForm.FormC).Replace('đ', 'd');
        }
    }
}
