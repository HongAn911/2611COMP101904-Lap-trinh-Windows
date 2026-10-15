using System.Drawing.Drawing2D;

namespace Lab09_StudentCard.Helpers;

public static class ImageHelper
{
    /// <summary>Cạnh dài tối đa của ảnh sau khi nạp (đủ nét cho thẻ, đỡ tốn RAM).</summary>
    private const int MaxSide = 1200;

    private const int ExifOrientationId = 0x0112;

    /// <summary>
    /// Nạp ảnh từ đĩa nhưng KHÔNG giữ khóa file:
    /// đọc bằng FileStream rồi sao chép sang Bitmap độc lập, sau đó đóng stream ngay.
    /// (Image.FromFile giữ file bị khóa cho tới khi Dispose ảnh.)
    /// Có xoay ảnh đúng chiều theo EXIF (ảnh chụp từ điện thoại).
    /// </summary>
    public static Bitmap LoadWithoutLock(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var source = Image.FromStream(stream, useEmbeddedColorManagement: false, validateImageData: true);

        // Tính kích thước đích (giữ nguyên tỉ lệ, chỉ thu nhỏ khi ảnh quá lớn)
        double scale = Math.Min(1.0, (double)MaxSide / Math.Max(source.Width, source.Height));
        int w = Math.Max(1, (int)Math.Round(source.Width * scale));
        int h = Math.Max(1, (int)Math.Round(source.Height * scale));

        var copy = new Bitmap(w, h);
        using (var g = Graphics.FromImage(copy))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(source, new Rectangle(0, 0, w, h));
        }

        ApplyExifOrientation(source, copy);
        return copy;
    }

    private static void ApplyExifOrientation(Image source, Bitmap target)
    {
        if (!source.PropertyIdList.Contains(ExifOrientationId)) return;

        var item = source.GetPropertyItem(ExifOrientationId);
        if (item?.Value is null || item.Value.Length == 0) return;

        RotateFlipType flip = item.Value[0] switch
        {
            2 => RotateFlipType.RotateNoneFlipX,
            3 => RotateFlipType.Rotate180FlipNone,
            4 => RotateFlipType.Rotate180FlipX,
            5 => RotateFlipType.Rotate90FlipX,
            6 => RotateFlipType.Rotate90FlipNone,
            7 => RotateFlipType.Rotate270FlipX,
            8 => RotateFlipType.Rotate270FlipNone,
            _ => RotateFlipType.RotateNoneFlipNone
        };

        if (flip != RotateFlipType.RotateNoneFlipNone)
            target.RotateFlip(flip);
    }

    /// <summary>
    /// Tìm hình chữ nhật lớn nhất có cùng tỉ lệ với ảnh nằm lọt trong khung <paramref name="box"/>
    /// và căn giữa. Đây là cốt lõi để ảnh KHÔNG bị méo khi vẽ / in.
    /// </summary>
    public static RectangleF FitInside(SizeF imageSize, RectangleF box)
    {
        float scale = Math.Min(box.Width / imageSize.Width, box.Height / imageSize.Height);
        float w = imageSize.Width * scale;
        float h = imageSize.Height * scale;
        return new RectangleF(box.X + (box.Width - w) / 2f, box.Y + (box.Height - h) / 2f, w, h);
    }
}
