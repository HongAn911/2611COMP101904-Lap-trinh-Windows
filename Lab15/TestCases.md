# Test case – Lab 15 Quản lý sinh viên (MVP)

Người kiểm thử: Huỳnh Thị Hồng Ân – MSSV 49.01.103.006
Môi trường: Windows 11, Visual Studio 2022, .NET 8
Ngày kiểm thử: 28/10/2026

| ID | Chức năng | Thao tác / Dữ liệu | Kết quả mong đợi | Kết quả thực tế | Đạt? | Ảnh |
|---|---|---|---|---|---|---|
| TC01 | Load danh sách | Mở Form | Hiển thị 8 sinh viên mẫu SV001–SV008 | Đúng như mong đợi, "Tổng: 8 sinh viên" | ✔ | [01](screenshots/01_load.png) |
| TC02 | Thêm hợp lệ | `SV009` / Trần Văn Nam / 49.01.SPTIN.A / 8.9 → **Thêm** | Thêm thành công, bảng có 9 dòng | Đúng như mong đợi, "Tổng: 9 sinh viên" | ✔ | [02](screenshots/02_them_thanh_cong.png) |
| TC03 | Dữ liệu rỗng | Chỉ nhập `SV001`, bỏ trống Họ tên, Lớp, Điểm → **Thêm** | Cảnh báo nhập đầy đủ, ô trống tô đỏ | Đúng như mong đợi | ✔ | [03](screenshots/03_du_lieu_rong.png) |
| TC04 | Trùng mã | `SV001` / Lê Thi Nhí / 48.01.CNNT.A / 7.5 → **Thêm** | Báo lỗi mã đã tồn tại, không thêm | Đúng như mong đợi | ✔ | [04](screenshots/04_trung_ma.png) |
| TC05 | Xác nhận xóa | Chọn dòng `SV005` → **Xóa theo mã** | Hiện hộp xác nhận Yes/No | Đúng như mong đợi | ✔ | [05](screenshots/05_xac_nhan_xoa.png) |
| TC06 | Xóa dữ liệu | Chọn **Yes** | Xóa SV005, bảng còn 8 dòng | Đúng như mong đợi | ✔ | [06](screenshots/06_xoa_thanh_cong.png) |
| TC07 | Tìm kiếm | `Huỳnh Thị Hồng Ân` → **Tìm kiếm** | Hiển thị SV006 | Đúng như mong đợi, "Tìm thấy 1 sinh viên" | ✔ | [07](screenshots/07_tim_kiem.png) |
| TC08 | Điểm ngoài khoảng | Điểm `11` → **Thêm** | Báo lỗi khoảng 0–10 | Đúng như mong đợi | ✔ | [08](screenshots/08_diem_ngoai_khoang.png) |
| TC09 | Họ tên sai kiểu | Họ tên `Trần Văn Nam123` → **Thêm** | Báo lỗi họ tên | Đúng như mong đợi | ✔ | [09](screenshots/09_ho_ten_sai.png) |
| TC10 | Tìm mã không tồn tại | `SV999` → **Tìm kiếm** | Bảng trống, cảnh báo không tìm thấy | Đúng như mong đợi | ✔ | [10](screenshots/10_tim_SV999.png) |
| TC11 | Tìm không có kết quả | `XZY` → **Tìm kiếm** | Bảng trống, cảnh báo không tìm thấy | Đúng như mong đợi | ✔ | [11](screenshots/11_tim_XZY.png) |

**Tổng kết:** 11/11 test case đạt.
