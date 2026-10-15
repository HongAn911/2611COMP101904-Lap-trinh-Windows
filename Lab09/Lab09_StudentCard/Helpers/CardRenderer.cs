using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using Lab09_StudentCard.Models;

namespace Lab09_StudentCard.Helpers;

/// <summary>
/// Vẽ thẻ sinh viên bằng GDI+.
/// Một hàm vẽ duy nhất được dùng cho CẢ HAI nơi: Panel preview (Paint) và PrintDocument (PrintPage),
/// nên bản in luôn giống bản xem trước.
///
/// Ý tưởng: thẻ được thiết kế trên một "khung thiết kế" 856 x 540 đơn vị (đúng tỉ lệ thẻ ID-1, 85,6 x 54 mm),
/// sau đó ScaleTransform để phóng/thu vào hình chữ nhật đích (pixel trên màn hình hoặc 1/100 inch khi in).
/// </summary>
public static class CardRenderer
{
    public const float DesignWidth = 856f;
    public const float DesignHeight = 540f;
    public const float AspectRatio = DesignWidth / DesignHeight;

    private const string FontFamilyName = "Segoe UI";

    private static readonly Color Primary = Color.FromArgb(31, 78, 156);   // xanh đậm
    private static readonly Color PrimaryDark = Color.FromArgb(18, 52, 124);
    private static readonly Color Teal = Color.FromArgb(0, 150, 199);      // xanh ngọc ở cuối dải tiêu đề
    private static readonly Color Gold = Color.FromArgb(255, 193, 7);      // vàng nhấn
    private static readonly Color Crimson = Color.FromArgb(198, 40, 40);   // màu nhấn cho mã sinh viên
    private static readonly Color TextDark = Color.FromArgb(33, 37, 41);
    private static readonly Color TextMuted = Color.FromArgb(90, 98, 108);

    /// <summary>Tính hình chữ nhật chứa thẻ (đúng tỉ lệ) nằm giữa vùng <paramref name="area"/>.</summary>
    public static RectangleF FitCardRectangle(RectangleF area, float margin = 0f)
    {
        var inner = RectangleF.Inflate(area, -margin, -margin);
        return ImageHelper.FitInside(new SizeF(DesignWidth, DesignHeight), inner);
    }

    /// <summary>Vẽ thẻ vào hình chữ nhật <paramref name="bounds"/> (đơn vị của Graphics đang dùng).</summary>
    public static void Draw(Graphics g, RectangleF bounds, StudentInfo info, Image? photo)
    {
        GraphicsState state = g.Save();
        try
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Đưa hệ tọa độ thiết kế (856x540) vào đúng vị trí / kích thước đích
            g.TranslateTransform(bounds.X, bounds.Y);
            g.ScaleTransform(bounds.Width / DesignWidth, bounds.Height / DesignHeight);

            DrawBackground(g);
            DrawHeader(g);
            DrawPhoto(g, photo);
            DrawInfo(g, info);
            DrawFooter(g);
        }
        finally
        {
            g.Restore(state);
        }
    }

    // ---------------------------------------------------------------- nền + khung ngoài
    private static void DrawBackground(Graphics g)
    {
        var card = new RectangleF(3, 3, DesignWidth - 6, DesignHeight - 6);
        using GraphicsPath path = RoundedRectangle(card, 36f);

        // Nền gradient nhẹ (xanh nhạt -> trắng)
        using (var bg = new LinearGradientBrush(card, Color.FromArgb(222, 238, 255), Color.White, 60f))
            g.FillPath(bg, path);

        g.SetClip(path);

        // Dải tiêu đề: gradient xanh đậm -> xanh ngọc
        var headerRect = new RectangleF(0, 0, DesignWidth, 124);
        using (var header = new LinearGradientBrush(headerRect, PrimaryDark, Teal, 0f))
            g.FillRectangle(header, headerRect);

        // Vài hình tròn mờ trang trí
        using (var soft = new SolidBrush(Color.FromArgb(34, 255, 255, 255)))
        {
            g.FillEllipse(soft, 690, -70, 230, 230);
            g.FillEllipse(soft, 760, 30, 150, 150);
            g.FillEllipse(soft, -50, 40, 130, 130);
        }

        // Vạch vàng - cam dưới tiêu đề
        using (var accent = new LinearGradientBrush(new RectangleF(0, 124, DesignWidth, 8),
                   Gold, Color.FromArgb(255, 112, 67), 0f))
            g.FillRectangle(accent, 0, 124, DesignWidth, 8);

        // Dải chân thẻ
        using (var footer = new LinearGradientBrush(new RectangleF(0, 488, DesignWidth, 52),
                   Color.FromArgb(232, 241, 255), Color.FromArgb(205, 225, 250), 0f))
            g.FillRectangle(footer, 0, 488, DesignWidth, 52);

        g.ResetClip();

        // Khung ngoài
        using var border = new Pen(Primary, 6f);
        g.DrawPath(border, path);
    }

    // ---------------------------------------------------------------- tiêu đề
    private static void DrawHeader(Graphics g)
    {
        using var school = new Font(FontFamilyName, 25f, FontStyle.Bold, GraphicsUnit.World);
        using var title = new Font(FontFamilyName, 42f, FontStyle.Bold, GraphicsUnit.World);
        using var white = new SolidBrush(Color.White);
        using var gold = new SolidBrush(Gold);

        DrawText(g, "TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH", school, white,
            new RectangleF(10, 12, DesignWidth - 20, 40), StringAlignment.Center);
        DrawText(g, "THẺ SINH VIÊN", title, gold,
            new RectangleF(10, 54, DesignWidth - 20, 62), StringAlignment.Center);
    }

    // ---------------------------------------------------------------- ảnh sinh viên (bên trái)
    private static void DrawPhoto(Graphics g, Image? photo)
    {
        // Khung ảnh 3x4
        var frame = new RectangleF(40, 152, 225, 300);

        // Bóng đổ nhẹ phía sau khung ảnh
        using (var shadow = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            g.FillRectangle(shadow, frame.X + 6, frame.Y + 6, frame.Width, frame.Height);

        using (var white = new SolidBrush(Color.White))
            g.FillRectangle(white, frame);

        if (photo is not null)
        {
            // Giữ đúng tỉ lệ ảnh -> không méo
            RectangleF dest = ImageHelper.FitInside(photo.Size, RectangleF.Inflate(frame, -4, -4));
            var destPoints = new[]
            {
                new PointF(dest.Left, dest.Top),      // góc trên trái
                new PointF(dest.Right, dest.Top),     // góc trên phải
                new PointF(dest.Left, dest.Bottom)    // góc dưới trái
            };

            using var attrs = new ImageAttributes();
            attrs.SetWrapMode(WrapMode.TileFlipXY); // tránh viền mờ ở mép ảnh
            g.DrawImage(photo, destPoints,
                new RectangleF(0, 0, photo.Width, photo.Height), GraphicsUnit.Pixel, attrs);
        }
        else
        {
            using var f = new Font(FontFamilyName, 28f, FontStyle.Bold, GraphicsUnit.World);
            using var b = new SolidBrush(TextMuted);
            DrawText(g, "ẢNH 3x4", f, b, frame, StringAlignment.Center, StringAlignment.Center);
        }

        using var pen = new Pen(Primary, 3f);
        g.DrawRectangle(pen, frame.X, frame.Y, frame.Width, frame.Height);
        using var goldPen = new Pen(Gold, 3f);
        g.DrawRectangle(goldPen, frame.X - 5, frame.Y - 5, frame.Width + 10, frame.Height + 10);
    }

    // ---------------------------------------------------------------- thông tin (bên phải)
    private static void DrawInfo(Graphics g, StudentInfo info)
    {
        const float labelX = 300f;
        const float valueX = 450f;
        const float valueWidth = DesignWidth - valueX - 28f;
        const float top = 150f;
        const float rowHeight = 47f;

        var rows = new (string Label, string Value, bool Strong)[]
        {
            ("Họ và tên", info.FullName.ToUpper(CultureInfo.CurrentCulture), true),
            ("Mã SV",      info.StudentId, true),
            ("Ngày sinh",  info.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), false),
            ("Giới tính",  info.Gender, false),
            ("Lớp",        info.ClassName, false),
            ("Khoa",       info.Faculty, false),
            ("Khóa học",   info.Course, false),
        };

        using var labelFont = new Font(FontFamilyName, 22f, FontStyle.Regular, GraphicsUnit.World);
        using var labelBrush = new SolidBrush(Primary);
        using var valueBrush = new SolidBrush(TextDark);
        using var idBrush = new SolidBrush(Crimson);
        using var stripe = new SolidBrush(Color.FromArgb(26, 31, 78, 156));

        for (int i = 0; i < rows.Length; i++)
        {
            float y = top + i * rowHeight;
            var (label, value, strong) = rows[i];

            // Kẻ sọc xen kẽ cho dễ đọc
            if (i % 2 == 0)
                g.FillRectangle(stripe, labelX - 10, y + 3, DesignWidth - labelX - 14, rowHeight - 6);

            DrawText(g, label + ":", labelFont, labelBrush,
                new RectangleF(labelX, y, valueX - labelX, rowHeight), StringAlignment.Near, StringAlignment.Center);

            // Chữ quá dài thì tự thu nhỏ cho vừa 1 dòng
            using Font valueFont = FitFont(g, value, strong ? FontStyle.Bold : FontStyle.Regular,
                strong ? 26f : 24f, 14f, valueWidth);
            DrawText(g, value, valueFont, label == "Mã SV" ? idBrush : valueBrush,
                new RectangleF(valueX, y, valueWidth, rowHeight), StringAlignment.Near, StringAlignment.Center);
        }
    }

    // ---------------------------------------------------------------- chân thẻ
    private static void DrawFooter(Graphics g)
    {
        using var f = new Font(FontFamilyName, 17f, FontStyle.Italic, GraphicsUnit.World);
        using var b = new SolidBrush(Primary);
        DrawText(g, "Thẻ chỉ có giá trị khi sử dụng trong thời gian học tập tại trường",
            f, b, new RectangleF(40, 494, DesignWidth - 80, 36), StringAlignment.Center, StringAlignment.Center);
    }

    // ---------------------------------------------------------------- tiện ích
    private static void DrawText(Graphics g, string text, Font font, Brush brush, RectangleF rect,
        StringAlignment horizontal = StringAlignment.Near, StringAlignment vertical = StringAlignment.Near)
    {
        using var format = new StringFormat
        {
            Alignment = horizontal,
            LineAlignment = vertical,
            Trimming = StringTrimming.EllipsisCharacter,
            FormatFlags = StringFormatFlags.NoWrap
        };
        g.DrawString(text, font, brush, rect, format);
    }

    /// <summary>Giảm dần cỡ chữ cho tới khi chuỗi vừa chiều rộng cho phép.</summary>
    private static Font FitFont(Graphics g, string text, FontStyle style, float maxSize, float minSize, float maxWidth)
    {
        float size = maxSize;
        while (size > minSize)
        {
            using var test = new Font(FontFamilyName, size, style, GraphicsUnit.World);
            if (g.MeasureString(text, test).Width <= maxWidth) break;
            size -= 1f;
        }
        return new Font(FontFamilyName, size, style, GraphicsUnit.World);
    }

    private static GraphicsPath RoundedRectangle(RectangleF r, float radius)
    {
        float d = radius * 2f;
        var path = new GraphicsPath();
        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }
}
