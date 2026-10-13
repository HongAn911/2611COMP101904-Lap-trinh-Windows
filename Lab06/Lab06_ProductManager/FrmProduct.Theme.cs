using System.Drawing.Drawing2D;

namespace ProductManager;

/// <summary>
/// Phần giao diện màu sắc (theme) của FrmProduct: header, nút màu, DataGridView,
/// menu/toolbar/status bar. Tách riêng khỏi logic để code dễ đọc.
/// </summary>
public partial class FrmProduct
{
    // Bảng màu
    private static readonly Color ColPrimary = Color.FromArgb(15, 76, 117);     // xanh navy
    private static readonly Color ColAccent = Color.FromArgb(50, 130, 184);     // xanh dương
    private static readonly Color ColLight = Color.FromArgb(187, 225, 250);     // xanh nhạt
    private static readonly Color ColBackground = Color.FromArgb(243, 247, 251);
    private static readonly Color ColText = Color.FromArgb(38, 50, 66);
    private static readonly Color ColMuted = Color.FromArgb(138, 148, 166);
    private static readonly Color ColSuccess = Color.FromArgb(46, 158, 107);    // xanh lá
    private static readonly Color ColDanger = Color.FromArgb(214, 69, 69);      // đỏ
    private static readonly Color ColWarning = Color.FromArgb(242, 153, 74);    // cam
    private static readonly Color ColTeal = Color.FromArgb(23, 162, 184);

    private Panel pnlHeader = null!;
    private Font gridBoldFont = null!;

    private void ApplyTheme()
    {
        BackColor = ColBackground;
        ForeColor = ColText;

        BuildHeader();
        ApplyMenuAndToolbarTheme();
        ApplyGroupTheme();
        ApplyGridTheme();

        pnlTimKiem.BackColor = ColBackground;
        lblTimKiem.ForeColor = ColPrimary;
        lblTimKiem.Font = new Font(Font, FontStyle.Bold);
        StyleButton(btnTimKiem, ColWarning);
    }

    // ---------- Header (banner có gradient) ----------
    private void BuildHeader()
    {
        pnlHeader = new Panel { Dock = DockStyle.Top, Height = 64, Name = "pnlHeader" };

        var lblTitle = new Label
        {
            Text = "QUẢN LÝ SẢN PHẨM",
            AutoSize = true,
            BackColor = Color.Transparent,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 17F, FontStyle.Bold),
            Location = new Point(18, 6)
        };
        var lblSub = new Label
        {
            Text = "Quản lý danh sách sản phẩm của cửa hàng",
            AutoSize = true,
            BackColor = Color.Transparent,
            ForeColor = ColLight,
            Font = new Font("Segoe UI", 9F),
            Location = new Point(21, 40)
        };
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);

        pnlHeader.Paint += (s, e) =>
        {
            if (pnlHeader.Width <= 0 || pnlHeader.Height <= 0) return;
            using var brush = new LinearGradientBrush(pnlHeader.ClientRectangle,
                ColPrimary, ColAccent, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, pnlHeader.ClientRectangle);
        };
        pnlHeader.Resize += (s, e) => pnlHeader.Invalidate();

        // Header phải nằm dưới ToolStrip và trên GroupBox khi dock (index 3 trong Controls).
        Controls.Add(pnlHeader);
        Controls.SetChildIndex(pnlHeader, 3);
    }

    // ---------- Menu / Toolbar / StatusBar / ContextMenu ----------
    private void ApplyMenuAndToolbarTheme()
    {
        var renderer = new ToolStripProfessionalRenderer(new ThemeColorTable()) { RoundedEdges = false };
        menuStrip1.Renderer = renderer;
        toolStrip1.Renderer = renderer;
        statusStrip1.Renderer = renderer;
        cmsProducts.Renderer = renderer;

        menuStrip1.BackColor = Color.White;
        menuStrip1.ForeColor = ColText;
        menuStrip1.Padding = new Padding(6, 3, 6, 3);

        toolStrip1.BackColor = Color.White;
        toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
        toolStrip1.Padding = new Padding(8, 4, 8, 4);

        var bold = new Font(Font, FontStyle.Bold);
        void StyleTool(ToolStripButton b, Color c)
        {
            b.ForeColor = c;
            b.Font = bold;
            b.Padding = new Padding(8, 4, 8, 4);
        }
        StyleTool(tsbThem, ColSuccess);
        StyleTool(tsbSua, ColAccent);
        StyleTool(tsbXoa, ColDanger);
        StyleTool(tsbLamMoi, ColMuted);
        StyleTool(tsbTimKiem, ColWarning);

        statusStrip1.BackColor = ColPrimary;
        statusStrip1.SizingGrip = false;
        lblStatus.ForeColor = Color.White;
        lblStatus.Font = bold;

        cmsProducts.BackColor = Color.White;
        cmsProducts.ForeColor = ColText;
        cmsXoa.ForeColor = ColDanger;
    }

    // ---------- GroupBox nhập liệu ----------
    private void ApplyGroupTheme()
    {
        grpThongTin.BackColor = Color.White;
        grpThongTin.Padding = new Padding(10);

        Font regular = Font;
        foreach (Control c in grpThongTin.Controls)
        {
            c.Font = regular;
            c.ForeColor = ColText;
        }
        // Đặt font đậm cho tiêu đề group sau khi các control con đã có font riêng.
        grpThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpThongTin.ForeColor = ColPrimary;

        foreach (Label lbl in grpThongTin.Controls.OfType<Label>())
            lbl.ForeColor = ColPrimary;

        picSanPham.BackColor = ColBackground;

        StyleButton(btnThem, ColSuccess);
        StyleButton(btnSua, ColAccent);
        StyleButton(btnXoa, ColDanger);
        StyleButton(btnLamMoi, Color.FromArgb(108, 124, 147));
        StyleButton(btnChonAnh, ColTeal);
    }

    private static void StyleButton(Button btn, Color color)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.BackColor = color;
        btn.ForeColor = Color.White;
        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btn.Cursor = Cursors.Hand;
        btn.UseVisualStyleBackColor = false;
        btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(color, 0.2f);
        btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(color, 0.1f);
    }

    // ---------- DataGridView ----------
    private void ApplyGridTheme()
    {
        gridBoldFont = new Font(dgvProducts.Font, FontStyle.Bold);

        dgvProducts.BackgroundColor = Color.White;
        dgvProducts.BorderStyle = BorderStyle.None;
        dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvProducts.GridColor = Color.FromArgb(227, 233, 240);
        dgvProducts.EnableHeadersVisualStyles = false;
        dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvProducts.ColumnHeadersHeight = 36;
        dgvProducts.RowTemplate.Height = 30;

        var header = dgvProducts.ColumnHeadersDefaultCellStyle;
        header.BackColor = ColPrimary;
        header.ForeColor = Color.White;
        header.Font = new Font(dgvProducts.Font, FontStyle.Bold);
        header.Alignment = DataGridViewContentAlignment.MiddleLeft;
        header.SelectionBackColor = ColPrimary;
        header.SelectionForeColor = Color.White;
        header.Padding = new Padding(4, 0, 0, 0);

        var cell = dgvProducts.DefaultCellStyle;
        cell.BackColor = Color.White;
        cell.ForeColor = ColText;
        cell.SelectionBackColor = ColLight;
        cell.SelectionForeColor = ColPrimary;
        cell.Padding = new Padding(4, 0, 4, 0);

        var alt = dgvProducts.AlternatingRowsDefaultCellStyle;
        alt.BackColor = Color.FromArgb(246, 250, 253);
        alt.SelectionBackColor = ColLight;
        alt.SelectionForeColor = ColPrimary;

        dgvProducts.CellFormatting += dgvProducts_CellFormatting;
    }

    /// <summary>Sản phẩm ngừng kinh doanh: chữ xám; số lượng dưới 10: chữ đỏ đậm.</summary>
    private void dgvProducts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (dgvProducts.Rows[e.RowIndex].DataBoundItem is not Product p) return;

        if (!p.ConKinhDoanh)
        {
            e.CellStyle.ForeColor = ColMuted;
        }
        else if (dgvProducts.Columns[e.ColumnIndex].Name == "colSoLuong" && p.SoLuong < 10)
        {
            e.CellStyle.ForeColor = ColDanger;
            e.CellStyle.Font = gridBoldFont;
        }
    }

    // ---------- Bảng màu cho menu/toolbar/status ----------
    private sealed class ThemeColorTable : ProfessionalColorTable
    {
        public ThemeColorTable() { UseSystemColors = false; }

        public override Color MenuItemSelected => ColLight;
        public override Color MenuItemBorder => ColAccent;
        public override Color MenuBorder => Color.FromArgb(200, 210, 224);
        public override Color MenuItemSelectedGradientBegin => ColLight;
        public override Color MenuItemSelectedGradientEnd => ColLight;
        public override Color MenuItemPressedGradientBegin => ColLight;
        public override Color MenuItemPressedGradientMiddle => ColLight;
        public override Color MenuItemPressedGradientEnd => ColLight;
        public override Color ToolStripDropDownBackground => Color.White;
        public override Color ImageMarginGradientBegin => Color.White;
        public override Color ImageMarginGradientMiddle => Color.White;
        public override Color ImageMarginGradientEnd => Color.White;
        public override Color SeparatorDark => Color.FromArgb(220, 227, 236);
        public override Color SeparatorLight => Color.White;

        public override Color MenuStripGradientBegin => Color.White;
        public override Color MenuStripGradientEnd => Color.White;
        public override Color ToolStripGradientBegin => Color.White;
        public override Color ToolStripGradientMiddle => Color.White;
        public override Color ToolStripGradientEnd => Color.White;
        public override Color ToolStripBorder => Color.FromArgb(227, 233, 240);

        public override Color ButtonSelectedHighlight => ColLight;
        public override Color ButtonSelectedGradientBegin => ColLight;
        public override Color ButtonSelectedGradientMiddle => ColLight;
        public override Color ButtonSelectedGradientEnd => ColLight;
        public override Color ButtonSelectedBorder => ColAccent;
        public override Color ButtonPressedGradientBegin => Color.FromArgb(160, 205, 235);
        public override Color ButtonPressedGradientMiddle => Color.FromArgb(160, 205, 235);
        public override Color ButtonPressedGradientEnd => Color.FromArgb(160, 205, 235);
        public override Color ButtonPressedBorder => ColAccent;

        public override Color StatusStripGradientBegin => ColPrimary;
        public override Color StatusStripGradientEnd => ColPrimary;
    }
}
