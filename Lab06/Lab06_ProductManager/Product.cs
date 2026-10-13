namespace ProductManager;

/// <summary>
/// Lưu dữ liệu của một sản phẩm. Class này chỉ chứa dữ liệu,
/// không chứa xử lý giao diện.
/// </summary>
public class Product
{
    public string MaSP { get; set; } = string.Empty;
    public string TenSP { get; set; } = string.Empty;
    public string LoaiSP { get; set; } = string.Empty;
    public decimal DonGia { get; set; }
    public int SoLuong { get; set; }
    public DateTime NgayNhap { get; set; }
    public bool ConKinhDoanh { get; set; }
    public string DuongDanAnh { get; set; } = string.Empty;

    /// <summary>Thuộc tính tính toán: thành tiền = đơn giá x số lượng.</summary>
    public decimal ThanhTien
    {
        get { return DonGia * SoLuong; }
    }
}
