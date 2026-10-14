# Câu hỏi nộp kèm - Lab 07

**Sinh viên:** Huỳnh Thị Hồng Ân - MSSV 49.01.103.006 - Lớp 49.01.SPTIN.A

## 1. SDI và MDI khác nhau như thế nào?

| | SDI (Single Document Interface) | MDI (Multiple Document Interface) |
|---|---|---|
| Cách tổ chức | Mỗi cửa sổ là một Form độc lập, không có Form cha chứa các Form khác | Có một Form cha (MDI Parent) chứa nhiều Form con (MDI Child) bên trong |
| Thiết lập | Dùng `Show()` hoặc `ShowDialog()` bình thường | Form cha: `IsMdiContainer = true`; Form con: `MdiParent = formCha` rồi `Show()` |
| Vị trí cửa sổ con | Nằm tự do trên màn hình | Chỉ hiển thị trong vùng làm việc của Form cha |
| Đóng, thu nhỏ | Mỗi Form độc lập | Đóng Form cha thì các Form con cũng đóng; thu nhỏ Form con nằm trong Form cha |
| Ví dụ | Notepad, Calculator | `FrmMain` chứa `FrmProduct`, `FrmCustomer`, `FrmAbout` trong bài lab này |

SDI phù hợp ứng dụng nhỏ, mỗi lần làm một việc. MDI phù hợp ứng dụng quản lý có nhiều màn hình cần mở cùng lúc.

## 2. Vì sao Form đăng nhập nên dùng ShowDialog()?

`ShowDialog()` mở Form dạng **modal**:

- Chương trình **dừng tại dòng gọi** cho đến khi Form đăng nhập đóng, người dùng không thể thao tác với phần khác của ứng dụng khi chưa đăng nhập.
- Trả về **`DialogResult`** (`OK` khi đăng nhập thành công, `Cancel` khi thoát), nên chỉ cần một câu điều kiện để quyết định có mở Form chính hay không.
- Sau khi Form đóng vẫn đọc được dữ liệu từ nó (như `LoggedInUser`) trước khi giải phóng bằng `using`.

Nếu dùng `Show()` (non-modal), code phía sau chạy tiếp ngay, Form chính có thể mở khi chưa đăng nhập và không có cách gọn để biết đăng nhập thành công hay chưa.

Trong `Program.cs`:

```csharp
using (var login = new FrmLogin())
{
    if (login.ShowDialog() != DialogResult.OK)
    {
        return; // bấm Thoát hoặc đóng form đăng nhập
    }
    currentUser = login.LoggedInUser;
}

var main = new FrmMain(currentUser);
Application.Run(main);
```

## 3. Dữ liệu user được truyền từ FrmLogin sang FrmMain bằng cách nào?

Truyền qua hai bước:

1. `FrmLogin` kiểm tra tài khoản trong danh sách tài khoản mẫu; nếu đúng thì lưu user vào property **`LoggedInUser`** rồi đặt `DialogResult.OK`.
2. `Program.cs` đọc `login.LoggedInUser` và truyền vào **constructor** `new FrmMain(currentUser)`. `FrmMain` lưu vào biến `_user` và hiển thị tên, vai trò lên StatusStrip (`lblUser`, `lblRole`).

```csharp
// FrmLogin
public User LoggedInUser { get; private set; }
...
LoggedInUser = found;
DialogResult = DialogResult.OK;

// FrmMain
public FrmMain(User user)
{
    InitializeComponent();
    _user = user;
    lblUser.Text = "Người dùng: " + _user.FullName;
    lblRole.Text = "Vai trò: " + _user.Role;
}
```

## 4. Nếu người dùng bấm menu sản phẩm nhiều lần, chương trình xử lý như thế nào để không mở trùng Form?

Hàm `OpenChild<T>()` duyệt qua danh sách `MdiChildren` của Form cha:

- Nếu đã có Form cùng kiểu (`child is T`): khôi phục nếu đang thu nhỏ, gọi `Activate()` để đưa lên trước rồi `return`, không tạo Form mới.
- Nếu chưa có: tạo Form mới, gán `MdiParent = this` và `Show()`.

```csharp
private void OpenChild<T>(Func<T> factory) where T : Form
{
    foreach (Form child in MdiChildren)
    {
        if (child is T)
        {
            if (child.WindowState == FormWindowState.Minimized)
                child.WindowState = FormWindowState.Normal;
            child.Activate();
            return;
        }
    }

    T form = factory();
    form.MdiParent = this;
    form.Show();
}

private void mnuProduct_Click(object sender, EventArgs e)
{
    OpenChild(() => new FrmProduct(_products));
}
```

Khi đóng Form con rồi bấm menu lần nữa thì Form mới được tạo lại, vì lúc đó nó không còn trong `MdiChildren`. Danh sách sản phẩm được giữ ở `FrmMain` (`_products`) nên dữ liệu không mất khi đóng rồi mở lại Form.

## 5. Khi nào nên dùng constructor, khi nào nên dùng property để truyền dữ liệu giữa các Form?

| | Constructor | Property |
|---|---|---|
| Dùng khi | Dữ liệu **bắt buộc** để Form hoạt động và đã biết ngay lúc tạo Form | Dữ liệu **tùy chọn**, hoặc gán/đọc **sau khi** Form đã tạo, hoặc cần **lấy kết quả trả về** |
| Ưu điểm | Không thể quên truyền dữ liệu; Form luôn ở trạng thái hợp lệ | Linh hoạt, gán từng phần, đọc lại kết quả sau `ShowDialog()` |
| Lưu ý | Form có constructor tham số thì phải tạo bằng `new FrmX(...)` (vì vậy `OpenChild` nhận `Func<T>`); Designer cần constructor không tham số để hiển thị | Có thể quên gán nên cần kiểm tra giá trị |
| Trong bài lab | `FrmMain(User user)`, `FrmProduct(BindingList<Product>)`, `FrmCustomer(BindingList<Customer>)`: cần dữ liệu ngay từ đầu | `FrmLogin.LoggedInUser`: lấy kết quả sau khi đăng nhập xong |
