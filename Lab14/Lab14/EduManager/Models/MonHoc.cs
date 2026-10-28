using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduManager.Models
{
    /// <summary>
    /// Entity ánh xạ tới bảng MONHOC trong database EduManagerDB.
    /// </summary>
    [Table("MONHOC")]
    public class MonHoc
    {
        [Key]
        [StringLength(10)]
        public string MaMonHoc { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string TenMonHoc { get; set; } = string.Empty;

        /// <summary>Số tín chỉ, hợp lệ từ 1 đến 6 (có CHECK constraint trong DB).</summary>
        public int SoTinChi { get; set; }

        /// <summary>true = còn sử dụng, false = ngừng sử dụng.</summary>
        public bool TrangThai { get; set; } = true;
    }
}
