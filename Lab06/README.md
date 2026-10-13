# Lab 06 - ProductManager

## Thông tin sinh viên
- Họ tên: Huỳnh Thị Hồng Ân
- MSSV: 49.01.103.006
- Lớp: 49.01.SPTIN.A

## Mô tả
Ứng dụng WinForms (C#, .NET 8) quản lý danh sách sản phẩm của một cửa hàng bằng `DataGridView`.
Dữ liệu lưu trong bộ nhớ (`BindingList<Product>` + `BindingSource`), không dùng database.

## Chức năng
- Thêm sản phẩm (kiểm tra rỗng, trùng mã, đơn giá, ngày nhập bằng `ErrorProvider`)
- Sửa sản phẩm
- Xóa sản phẩm (có hộp thoại xác nhận)
- Tìm kiếm theo mã hoặc tên (không phân biệt hoa/thường)
- Làm mới dữ liệu
- Chọn ảnh sản phẩm bằng `OpenFileDialog`
- Menu chuột phải: Sửa, Xóa, Xem chi tiết
- `StatusStrip` hiển thị trạng thái, số lượng sản phẩm và tổng giá trị tồn kho
- Phím tắt: Ctrl+N (Thêm), Ctrl+E (Sửa), Ctrl+D (Xóa), Ctrl+F (Tìm kiếm), F5 (Làm mới)

## Công nghệ sử dụng
- C# WinForms, .NET 8
- Visual Studio 2022

## Cách chạy
1. Mở file `ProductManager.csproj` bằng Visual Studio 2022
2. Build solution (`Ctrl+Shift+B`)
3. Chạy project (`F5`)

## Hình ảnh minh họa

### 1. Màn hình chính
![Màn hình chính](screenshots/1_Menu_chinh.png)

### 2. MenuStrip và ToolStrip
![Menu và toolbar](screenshots/2_Menu_va_thanh_cong_cu.png)

### 3. Thêm sản phẩm thành công
![Thêm thành công](screenshots/3_Them_sp_thanh_cong.png)

### 4. Kiểm tra dữ liệu (ErrorProvider)

Mã sản phẩm rỗng:

![Mã rỗng](screenshots/4.1_Kiem_tra_loi_ma_sp_rong.png)

Mã sản phẩm trùng:

![Mã trùng](screenshots/4.2_Kiem_tra_loi_trung_ma_sp.png)

Đơn giá bằng 0:

![Đơn giá](screenshots/4.3_Kiem_tra_loi_don_gia.png)

Tên sản phẩm rỗng:

![Tên rỗng](screenshots/4.4_Kiem_tra_loi_de_trong_ten_sp.png)

### 5. Sửa sản phẩm
![Sửa sản phẩm](screenshots/5_Sua_sp.png)

### 6. Xóa sản phẩm

Hộp thoại xác nhận:

![Xác nhận xóa](screenshots/6.1_Xoa_sp.png)

Sau khi xóa:

![Xóa thành công](screenshots/6.2_Sau_khi_xoa_sp.png)

### 7. Tìm kiếm
![Tìm kiếm](screenshots/7_Tim_kiem.png)

### 8. Menu chuột phải
![Menu chuột phải](screenshots/8_Menu_chuot_phai.png)

### 9. Xem chi tiết
![Xem chi tiết](screenshots/9_Xem_chi_tiet_sp.png)
