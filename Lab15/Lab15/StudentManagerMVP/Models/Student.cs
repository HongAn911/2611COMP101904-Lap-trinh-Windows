namespace StudentManagerMVP.Models
{
    /// <summary>
    /// Model: chỉ chứa dữ liệu của một sinh viên, không biết gì về giao diện.
    /// </summary>
    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string ClassName { get; set; }
        public double Score { get; set; }

        /// <summary>Xếp loại tính từ điểm trung bình.</summary>
        public string Rank
        {
            get
            {
                if (Score >= 8.0) return "Giỏi";
                if (Score >= 6.5) return "Khá";
                if (Score >= 5.0) return "Trung bình";
                return "Yếu";
            }
        }

        public Student() { }

        public Student(string studentId, string fullName, string className, double score)
        {
            StudentId = studentId;
            FullName = fullName;
            ClassName = className;
            Score = score;
        }
    }
}
