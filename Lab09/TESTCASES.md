# Test case – Lab 09 (Thẻ sinh viên)

Cách dùng: chạy chương trình, thực hiện từng bước, ghi kết quả vào cột cuối (Đạt / Không đạt).
Ảnh thử nghiệm gợi ý: `anh_3x4.jpg` (dọc), `anh_ngang.png` (ngang), `anh_vuong.bmp`, `ghi_chu.txt` (đổi đuôi thành .jpg để thử file hỏng).

| TC | Chức năng | Các bước thực hiện / Dữ liệu vào | Kết quả mong đợi | Kết quả thực tế |
|---|---|---|---|---|
| TC01 | Trạng thái ban đầu | Mở chương trình | Form `FrmStudentCard` hiện hai vùng trái/phải; ô Mã SV, Họ tên trống; chưa có ảnh; Panel preview hiện khung nét đứt "Nhập Mã sinh viên, Họ tên và chọn ảnh…"; dòng trạng thái báo "Còn thiếu: Mã sinh viên, Họ tên, Ảnh đại diện" | ☐ Đạt ☐ Không đạt |
| TC02 | F1 – Chọn ảnh JPG | Bấm **Chọn ảnh…**, chọn `anh_3x4.jpg` | Ảnh hiện trong `PictureBox` đúng tỉ lệ (không méo); hộp thoại chỉ liệt kê file JPG/JPEG/PNG/BMP | ☐ Đạt ☐ Không đạt |
| TC03 | F1 – Ảnh ngang/vuông | Chọn `anh_ngang.png`, sau đó `anh_vuong.bmp` | Ảnh luôn giữ đúng tỉ lệ, có dải trống hai bên/trên dưới, không bị kéo giãn | ☐ Đạt ☐ Không đạt |
| TC04 | F1 – Đổi ảnh không khóa file | Chọn ảnh A → chọn ảnh B → trong File Explorer đổi tên/xóa ảnh A khi chương trình vẫn mở | Không lỗi khi đổi ảnh; file A đổi tên/xóa được (không báo "file đang được sử dụng") | ☐ Đạt ☐ Không đạt |
| TC05 | F1 – File không hợp lệ | Chọn `ghi_chu.jpg` (thực chất là file văn bản đổi đuôi) | Hiện thông báo "Không thể mở tệp đã chọn…", chương trình không dừng, ảnh cũ (nếu có) giữ nguyên | ☐ Đạt ☐ Không đạt |
| TC06 | F1 – Hủy chọn ảnh | Bấm **Chọn ảnh…** rồi **Cancel** | Không thay đổi gì | ☐ Đạt ☐ Không đạt |
| TC07 | F2 – Preview theo dữ liệu | Nhập Mã SV `49.01.103.006`, Họ tên `Huỳnh Thị Hồng Ân`, chọn ảnh, chọn lớp/khoa/khóa K49, giới tính Nữ | Thẻ hiện ở Panel bên phải: tiêu đề THẺ SINH VIÊN, tên trường, ảnh bên trái, thông tin bên phải; họ tên in HOA | ☐ Đạt ☐ Không đạt |
| TC08 | F2 – Cập nhật tức thì | Sau TC07, sửa Họ tên, đổi ngày sinh, đổi giới tính, đổi khóa | Thẻ vẽ lại ngay sau mỗi thay đổi, không nháy hình | ☐ Đạt ☐ Không đạt |
| TC09 | F2 – Họ tên rất dài | Nhập họ tên 50+ ký tự | Chữ trên thẻ tự thu nhỏ/cắt "…" vừa một dòng, không tràn khỏi thẻ | ☐ Đạt ☐ Không đạt |
| TC10 | F3 – Thiếu Mã SV | Để trống Mã SV (đã có họ tên + ảnh), bấm **Xem trước in** | Hiện cảnh báo, biểu tượng lỗi ở ô Mã SV, con trỏ về ô Mã SV, **không** mở Print Preview | ☐ Đạt ☐ Không đạt |
| TC11 | F3 – Thiếu họ tên (chỉ khoảng trắng) | Nhập Họ tên là `"   "` (toàn dấu cách), bấm **In thẻ** | Coi như rỗng: cảnh báo, không mở hộp thoại in | ☐ Đạt ☐ Không đạt |
| TC12 | F3 – Thiếu ảnh | Nhập đủ Mã SV + Họ tên nhưng chưa chọn ảnh, bấm **Xem trước in** | Cảnh báo "Chưa chọn ảnh đại diện", biểu tượng lỗi cạnh ảnh, không xem trước/in | ☐ Đạt ☐ Không đạt |
| TC13 | F3 – Hết lỗi khi sửa | Sau TC10, nhập Mã SV | Biểu tượng lỗi ở ô Mã SV biến mất ngay | ☐ Đạt ☐ Không đạt |
| TC14 | F4 – Print Preview | Nhập đủ dữ liệu, bấm **Xem trước in** | Mở `PrintPreviewDialog`, thẻ có khung, tiêu đề, ảnh, thông tin, giống bản preview; ảnh không méo | ☐ Đạt ☐ Không đạt |
| TC15 | F5 – In thẻ | Nhập đủ dữ liệu, bấm **In thẻ**, chọn *Microsoft Print to PDF*, OK | Mở `PrintDialog`; file PDF tạo ra có thẻ kích thước thực ~85,6×54 mm, ảnh không méo | ☐ Đạt ☐ Không đạt |
| TC16 | F5 – Hủy in | Bấm **In thẻ** rồi **Cancel** trong `PrintDialog` | Không in, không lỗi | ☐ Đạt ☐ Không đạt |
| TC17 | F6 – Làm mới | Nhập đủ dữ liệu + ảnh, bấm **Làm mới** | Ô nhập trống, combobox về giá trị đầu, `PictureBox` trống, Panel về khung nhắc nhập, trạng thái "Còn thiếu…" | ☐ Đạt ☐ Không đạt |
| TC18 | Thoát | Bấm **Thoát** | Chương trình đóng | ☐ Đạt ☐ Không đạt |

> Yêu cầu nộp tối thiểu 8 test case; bộ trên có 18 test case. Chỉ ghi "Đạt" sau khi tự chạy và thấy đúng.
