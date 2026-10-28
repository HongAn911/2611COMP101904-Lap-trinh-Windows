using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.Data
{
    /// <summary>
    /// DbContext của hệ thống EduManager, quản lý kết nối tới SQL Server.
    /// </summary>
    public class EduManagerContext : DbContext
    {
        /// <summary>
        /// Chuỗi kết nối. Sửa lại "Server=" cho đúng tên SQL Server trên máy:
        ///   - SQL Server mặc định : Server=.
        ///   - SQL Express         : Server=.\SQLEXPRESS
        ///   - LocalDB             : Server=(localdb)\MSSQLLocalDB
        /// </summary>
        public const string ConnectionString =
               @"Server=(localdb)\MSSQLLocalDB;Database=EduManagerDB;Trusted_Connection=True;TrustServerCertificate=True";

        public DbSet<MonHoc> MonHocs => Set<MonHoc>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.ToTable("MONHOC", t =>
                    t.HasCheckConstraint("CK_MONHOC_SoTinChi", "[SoTinChi] BETWEEN 1 AND 6"));

                entity.HasKey(e => e.MaMonHoc);

                entity.Property(e => e.MaMonHoc)
                      .HasMaxLength(10)
                      .IsRequired();

                entity.Property(e => e.TenMonHoc)
                      .HasMaxLength(100)
                      .IsRequired();

                // Lưu ý: DEFAULT 1 của cột TrangThai được tạo trong script SQL.
                // Không khai báo HasDefaultValue(true) ở đây vì EF sẽ bỏ qua giá trị
                // false khi INSERT (false là giá trị mặc định của bool) -> DB lại ghi 1.
                entity.Property(e => e.TrangThai).IsRequired();
            });
        }
    }
}
