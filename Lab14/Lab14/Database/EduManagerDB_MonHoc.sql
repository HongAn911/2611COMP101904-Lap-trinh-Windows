
-- 1. Tạo database nếu chưa có
IF DB_ID(N'EduManagerDB') IS NULL
BEGIN
    CREATE DATABASE EduManagerDB;
END
GO

USE EduManagerDB;
GO

-- 2. Tạo bảng MONHOC nếu chưa có
IF OBJECT_ID(N'dbo.MONHOC', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MONHOC
    (
        MaMonHoc   NVARCHAR(10)  NOT NULL,
        TenMonHoc  NVARCHAR(100) NOT NULL,
        SoTinChi   INT           NOT NULL,
        TrangThai  BIT           NOT NULL CONSTRAINT DF_MONHOC_TrangThai DEFAULT (1),

        CONSTRAINT PK_MONHOC PRIMARY KEY (MaMonHoc),
        CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi BETWEEN 1 AND 6)
    );
END
GO

-- 3. Dữ liệu mẫu (chỉ thêm khi mã chưa tồn tại)
INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai)
SELECT v.MaMonHoc, v.TenMonHoc, v.SoTinChi, v.TrangThai
FROM (VALUES
    (N'COMP1019', N'Lập trình trên Windows',          3, 1),
    (N'COMP1010', N'Lập trình hướng đối tượng',       3, 1),
    (N'COMP1013', N'Cơ sở dữ liệu',                   3, 1),
    (N'COMP1015', N'Cấu trúc dữ liệu và giải thuật',  4, 1),
    (N'COMP1017', N'Lập trình Web',                   3, 1),
    (N'COMP1020', N'Phân tích và thiết kế hệ thống',  3, 1),
    (N'COMP1022', N'Mạng máy tính',                   3, 1),
    (N'MATH1001', N'Toán rời rạc',                    2, 1),
    (N'MATH1005', N'Xác suất thống kê',               2, 1),
    (N'COMP1001', N'Tin học căn bản',                 2, 0)
) AS v (MaMonHoc, TenMonHoc, SoTinChi, TrangThai)
WHERE NOT EXISTS (SELECT 1 FROM dbo.MONHOC m WHERE m.MaMonHoc = v.MaMonHoc);
GO

-- 4. Kiểm tra
SELECT * FROM dbo.MONHOC ORDER BY MaMonHoc;
GO
