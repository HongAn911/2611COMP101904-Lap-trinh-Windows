# Checklist bàn giao – Lab 15

Sinh viên: Huỳnh Thị Hồng Ân – MSSV 49.01.103.006 – Lớp 49.01.SPTIN.A

## 1. Kiến trúc MVP
- [ ] Thư mục `Models` có `Student.cs`
- [ ] Thư mục `Views` có `IStudentView.cs` và `FrmStudent` implements `IStudentView`
- [ ] Thư mục `Presenters` có `StudentPresenter.cs` xử lý nghiệp vụ
- [ ] Thư mục `Repositories` có `IStudentRepository.cs` và `StudentRepository.cs`
- [ ] Button Click chỉ gọi phương thức của Presenter (ví dụ `_presenter.AddStudent()`)
- [ ] Presenter không dùng `System.Windows.Forms`, không truy cập TextBox/DataGridView

## 2. Chức năng
- [ ] Form có ≥ 3 ô nhập liệu (Mã SV, Họ tên, Lớp, Điểm) và 1 DataGridView
- [ ] Load danh sách – dữ liệu mẫu hiện ngay khi chạy
- [ ] Thêm dữ liệu
- [ ] Xóa dữ liệu theo mã (có xác nhận)
- [ ] Tìm kiếm theo tên hoặc mã
- [ ] Kiểm tra dữ liệu rỗng, sai kiểu, trùng mã
- [ ] Có thông báo kết quả thao tác

## 3. Kiểm thử
- [ ] Đã chạy đủ test case trong `TestCases.md` (≥ 5 trường hợp)
- [ ] Đã điền cột *Kết quả thực tế* và *Đạt?*

## 4. Hồ sơ nộp
- [ ] Project build không lỗi (Build → Rebuild Solution)
- [ ] `README.md` (cho GitHub) và `README.txt` (cách chạy, phiên bản VS/.NET, tài khoản demo)
- [ ] Ảnh chụp màn hình trong thư mục `screenshots/` (01–05)
- [ ] File test case `TestCases.md`
- [ ] File checklist này
- [ ] Đã xóa thư mục `bin/`, `obj/`, `.vs/` trước khi nén (đã có `.gitignore`)
- [ ] Đã push lên GitHub cá nhân và kiểm tra repository hiển thị đúng README

## 5. Thông tin nộp bài
- Link GitHub: ............................................................
- Ngày nộp: ....../....../2026
