using System.Collections.Generic;
using System.Drawing;

namespace COMP1019_Lab08_SimplePaint
{
    /// <summary>
    /// Dữ liệu gốc của một nét vẽ / một hình.
    /// Danh sách DrawItem được dùng để vẽ lại canvas trong sự kiện Paint.
    /// </summary>
    public class DrawItem
    {
        public DrawMode Mode { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public Color Color { get; set; }
        public float Width { get; set; }

        /// <summary>Chỉ áp dụng cho Rectangle và Ellipse: true = tô màu bên trong.</summary>
        public bool Filled { get; set; }

        /// <summary>Danh sách điểm của nét vẽ tự do (chế độ Pen).</summary>
        public List<Point> Points { get; set; } = new List<Point>();
    }
}
