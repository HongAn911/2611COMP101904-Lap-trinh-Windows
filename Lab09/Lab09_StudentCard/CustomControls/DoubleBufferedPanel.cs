namespace Lab09_StudentCard.CustomControls;

/// <summary>
/// Panel bật double buffering để vẽ lại thẻ bằng GDI+ không bị nháy hình.
/// (Thuộc tính DoubleBuffered của Panel là protected nên phải kế thừa mới bật được.)
/// </summary>
public class DoubleBufferedPanel : Panel
{
    public DoubleBufferedPanel()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
    }
}
