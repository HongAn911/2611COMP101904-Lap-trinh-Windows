# Lab 04 - Quản lý sản phẩm bằng Console (C# Exception, Event, Func, Generic)

## Thông tin sinh viên
- Họ tên: Huỳnh Thị Hồng Ân
- MSSV: 49.01.103.006
- Lớp: 49.01.SPTIN.A

## Mô tả
Chương trình Console C# quản lý danh sách sản phẩm. Dữ liệu được lưu trong bộ nhớ bằng `Repository<T>` generic. Chương trình hiển thị menu để người dùng lựa chọn chức năng, thực hiện xong sẽ quay lại menu cho đến khi người dùng chọn thoát. Lỗi nhập liệu, mã sản phẩm trùng và sản phẩm không tồn tại được xử lý bằng exception; khi thêm hoặc xóa sản phẩm thành công, chương trình phát event để thông báo.

## Công nghệ sử dụng
- C# Console App
- .NET 8 (Visual Studio)
- Exception: `try-catch`, `throw`, exception tự tạo
- Event: `event Action<Product>`
- `Func<Product, bool>` (tìm kiếm, lọc)
- Generic class có ràng buộc `where T : IEntity`
- LINQ (`Where`, `FirstOrDefault`, `Sum`)

## Yêu cầu class
- `IEntity`: interface có `string Id { get; }`, dùng làm ràng buộc generic cho `Repository<T>`.
- `Product`: kế thừa `IEntity`, gồm `MaSP`, `TenSP`, `Price`, `Quantity`, có constructor và `ToString()`. Mã và tên không được rỗng; `Price` và `Quantity` không được âm, nếu sai sẽ ném `ArgumentException`.
- `DuplicateProductException`: exception tự tạo, phát sinh khi thêm sản phẩm có mã bị trùng.
- `ProductNotFoundException`: exception tự tạo, phát sinh khi tìm hoặc xóa sản phẩm không tồn tại.
- `Repository<T>`: generic class (`where T : IEntity`) lưu `List<T>`, gồm Add, Remove, FindById, Find(`Func<T, bool>`), GetAll.
- `ProductService`: kiểm tra nghiệp vụ, gọi Repository, phát event `ProductAdded` và `ProductRemoved`; gồm AddProduct, RemoveProduct, GetProductById, Search, Filter(`Func<Product, bool>`), GetAllProducts, CalculateTotalValue.
- `Program`: chứa Main, menu và các hàm nhập dữ liệu, đăng ký event, bắt exception, gọi service xử lý.

## Chức năng
- Thêm sản phẩm (nhập mã, tên, đơn giá, số lượng; mã không được rỗng và không được trùng), phát event khi thêm thành công
- Xuất danh sách sản phẩm (mã, tên, đơn giá, số lượng); danh sách rỗng thì thông báo phù hợp
- Tìm sản phẩm theo mã
- Tìm sản phẩm theo tên (chứa từ khóa, không phân biệt hoa thường)
- Lọc sản phẩm theo khoảng giá (dùng `Func<Product, bool>`)
- Xóa sản phẩm theo mã, phát event khi xóa thành công
- Tính tổng giá trị kho (tổng đơn giá * số lượng của tất cả sản phẩm)
- Thoát chương trình

## Cách chạy
1. Mở file `.sln`/`.csproj` bằng Visual Studio
2. Build solution
3. Chạy project (F5 hoặc Ctrl+F5)
4. Chọn chức năng theo menu hiển thị trên màn hình Console

## Xử lý dữ liệu nhập
- Nhập sai kiểu dữ liệu (ví dụ chữ vào ô đơn giá hoặc số lượng) không làm chương trình dừng bất thường; chương trình sẽ báo lỗi và yêu cầu nhập lại.
- Mã sản phẩm hoặc tên sản phẩm để trống sẽ bị từ chối và yêu cầu nhập lại.
- Đơn giá hoặc số lượng âm bị `Product` từ chối bằng `ArgumentException`; chương trình báo dữ liệu không hợp lệ rồi quay về menu.
- Thêm sản phẩm với mã đã tồn tại (không phân biệt hoa thường) sẽ ném `DuplicateProductException` và báo lỗi trùng mã.
- Tìm theo mã hoặc xóa sản phẩm với mã không tồn tại sẽ ném `ProductNotFoundException` và báo không tìm thấy.
- Lọc theo khoảng giá mà giá nhỏ nhất lớn hơn giá lớn nhất sẽ được thông báo, không thực hiện lọc.
- Tìm theo tên hoặc lọc theo giá không có kết quả sẽ có thông báo phù hợp.
- Mọi exception đều được bắt trong `Main`, chương trình luôn quay lại menu.

## Hình ảnh màn hình

### Menu chương trình
![Menu](screenshots/menu.png)

### Thêm sản phẩm (kèm event thông báo)
![Them san pham](screenshots/them_san_pham.png)

### Xuất danh sách
![Xuat danh sach](screenshots/xuat_danh_sach.png)

### Tìm theo mã
![Tim theo ma](screenshots/tim_theo_ma.png)

### Tìm theo tên
![Tim theo ten](screenshots/tim_theo_ten.png)

### Lọc theo khoảng giá
![Loc theo khoang gia](screenshots/loc_theo_khoang_gia.png)

### Xóa sản phẩm (kèm event thông báo)
![Xoa san pham](screenshots/xoa_san_pham.png)

### Tính tổng giá trị kho
![Tinh tong gia tri kho](screenshots/tinh_tong_gia_tri_kho.png)

### Xử lý nhập sai (mã trùng, đơn giá/số lượng âm, mã không tồn tại)
![Xu ly loi](screenshots/xu_ly_loi_nhap_lieu.png)