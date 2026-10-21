namespace Lab05
{
    /// <summary>
    /// Một khóa học gồm tên và học phí mỗi tháng (VNĐ).
    /// </summary>
    public record KhoaHocInfo(string Ten, int HocPhiMoiThang)
    {
        // ComboBox dùng ToString() để hiển thị tên khóa học
        public override string ToString() => Ten;
    }
}
