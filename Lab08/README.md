# Lab08 - Simple Paint

## Thông tin sinh viên
- Họ tên: Huỳnh Thị Hồng Ân
- MSSV: 49.01.103.006
- Lớp: 49.01.SPTIN.A

## Mô tả
Ứng dụng vẽ tương tác bằng chuột trên canvas. Các nét vẽ được lưu trong `List<DrawItem>` và vẽ lại trong sự kiện `Paint`, nên không bị mất khi resize hoặc khi cửa sổ bị che rồi hiện lại.

## Cách chạy chương trình

**Yêu cầu:** Windows 10/11, Visual Studio 2022 trở lên (workload *.NET desktop development*) và .NET 8 SDK.

**Cách 1: dùng Visual Studio**
1. Clone hoặc tải repo về máy.
2. Mở file `Lab08_SimplePaint.sln` (hoặc `Lab08_SimplePaint.csproj`) bằng Visual Studio.
3. Nhấn **F5** để chạy.

**Cách 2: dùng dòng lệnh**
```bash
cd COMP1019_Lab08_SimplePaint
dotnet run
```

> Nếu máy dùng phiên bản .NET khác, sửa `TargetFramework` trong file `.csproj` cho khớp (ví dụ `net10.0-windows`).

## Cách sử dụng

1. Chọn chế độ vẽ: **Pen**, **Line**, **Rectangle** hoặc **Ellipse**.
2. Chọn độ dày nét từ 1 đến 20.
3. Nhấn **Chọn màu** để mở hộp thoại chọn màu.
4. Nhấn giữ chuột trái trên canvas rồi kéo để vẽ. Với Line, Rectangle và Ellipse, hình co giãn theo chuột và được chốt khi thả chuột.
5. **Undo** (hoặc **Ctrl+Z**) xóa nét cuối cùng, **Clear** xóa toàn bộ (có hỏi xác nhận).
6. Tọa độ chuột hiển thị ở thanh trạng thái phía dưới.

## Chức năng

**Bắt buộc:** vẽ Pen, Line, Rectangle, Ellipse (kéo theo mọi hướng); chọn màu bằng ColorDialog; chọn độ dày bằng NumericUpDown; Undo; Clear; hiển thị tọa độ chuột; nét vẽ không mất khi resize.

**Nâng cao:**

| Chức năng | Cách dùng |
|---|---|
| Lưu ra file PNG | Nút **Lưu PNG** (hoặc **Ctrl+S**) |
| Mở ảnh nền để vẽ đè | Nút **Mở ảnh nền** (hoặc **Ctrl+O**) |
| Phím tắt Ctrl+Z để Undo | Nhấn **Ctrl+Z** |
| Tô màu hình chữ nhật, ellipse | Tick ô **Tô màu** trước khi vẽ |
| Đổi màu nền canvas | Nút **Màu nền** |

## Cấu trúc project

| File | Vai trò |
|---|---|
| `Program.cs` | Điểm bắt đầu chương trình |
| `FrmPaint.cs` | Form chính: giao diện và xử lý sự kiện chuột, nút, Paint |
| `DrawMode.cs` | Enum `Pen`, `Line`, `Rectangle`, `Ellipse` |
| `DrawItem.cs` | Lưu dữ liệu một nét vẽ (chế độ, điểm đầu/cuối, màu, độ dày, danh sách điểm, tô màu) |
| `DrawSurface.cs` | `Panel` tùy chỉnh bật `DoubleBuffered` |

## Kỹ thuật chính

- Vẽ trong sự kiện `Paint` của canvas, không vẽ trực tiếp trong `MouseMove`.
- Mỗi nét vẽ là một `DrawItem` trong `List<DrawItem>`; khi dữ liệu đổi thì gọi `canvas.Invalidate()`.
- `Pen` và `SolidBrush` được giải phóng bằng `using`.
- Hình chữ nhật và ellipse được chuẩn hóa bằng `Math.Min` / `Math.Abs` để kéo chuột theo mọi hướng đều đúng.
- Canvas là `DrawSurface` (Panel bật `DoubleBuffered`) để vẽ mượt, không nhấp nháy.
- Hàm `RenderScene` dùng chung cho cả sự kiện `Paint` và chức năng lưu PNG, nên ảnh lưu giống hệt những gì hiển thị.
- Chỉ chuột trái mới tạo nét vẽ; Undo/Clear khi canvas trống chỉ báo trên thanh trạng thái, không gây lỗi.
- Có `try/catch` khi mở và lưu ảnh, và kiểm tra giá trị chế độ vẽ.

## Ảnh chụp màn hình

**1. Giao diện khi mở ứng dụng**

![Giao diện](screenshots/1_giao_dien.png)

**2. Vẽ tự do (Pen)**

![Pen](screenshots/2_pen.png)

**3. Vẽ đường thẳng (Line)**

![Line](screenshots/3_line.png)

**4. Vẽ hình chữ nhật (Rectangle), kéo theo nhiều hướng**

![Rectangle](screenshots/4_rectangle.png)

**5. Vẽ ellipse**

![Ellipse](screenshots/5_ellipse.png)

**6. Vẽ kết hợp nhiều loại hình**

![Demo](screenshots/6_demo.png)

**7. Chức năng nâng cao: mở ảnh nền và vẽ đè lên ảnh**

![Mở ảnh nền](screenshots/7_mo_anh_nen.png)
