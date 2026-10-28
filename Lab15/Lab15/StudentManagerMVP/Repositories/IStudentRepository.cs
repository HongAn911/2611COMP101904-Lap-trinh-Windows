using StudentManagerMVP.Models;

namespace StudentManagerMVP.Repositories
{
    /// <summary>
    /// Hợp đồng truy xuất dữ liệu sinh viên. Presenter chỉ làm việc với interface này,
    /// nên sau này có thể đổi sang SQL Server mà không phải sửa Presenter.
    /// </summary>
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(string studentId);
        bool Exists(string studentId);
        void Add(Student student);
        bool Delete(string studentId);
        List<Student> Search(string keyword);
    }
}
