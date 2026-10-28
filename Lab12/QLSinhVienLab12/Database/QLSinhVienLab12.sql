USE master;
GO
IF DB_ID(N'QLSinhVienLab12') IS NOT NULL
BEGIN
    ALTER DATABASE QLSinhVienLab12 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSinhVienLab12;
END
GO
CREATE DATABASE QLSinhVienLab12;
GO
USE QLSinhVienLab12;
GO

/* ---------------------------- BẢNG ---------------------------- */
CREATE TABLE LOP (
    MaLop   NVARCHAR(20)  NOT NULL CONSTRAINT PK_LOP PRIMARY KEY,
    TenLop  NVARCHAR(100) NOT NULL
);

CREATE TABLE SINHVIEN (
    MaSV     NVARCHAR(20)  NOT NULL CONSTRAINT PK_SINHVIEN PRIMARY KEY,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    MaLop    NVARCHAR(20)  NOT NULL,
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);

CREATE TABLE MONHOC (
    MaMon    NVARCHAR(20)  NOT NULL CONSTRAINT PK_MONHOC PRIMARY KEY,
    TenMon   NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL CONSTRAINT CK_MONHOC_TinChi CHECK (SoTinChi > 0)
);

CREATE TABLE KETQUA (
    MaSV   NVARCHAR(20)  NOT NULL,
    MaMon  NVARCHAR(20)  NOT NULL,
    Diem   FLOAT         NOT NULL CONSTRAINT CK_KETQUA_Diem CHECK (Diem >= 0 AND Diem <= 10),
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMon),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV)  REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC   FOREIGN KEY (MaMon) REFERENCES MONHOC(MaMon)
);
GO

/* ------------------------- DỮ LIỆU MẪU ------------------------- */
INSERT INTO LOP (MaLop, TenLop) VALUES
(N'CTK47A', N'Công nghệ thông tin K47A'),
(N'CTK47B', N'Công nghệ thông tin K47B');

INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, MaLop) VALUES
(N'SV001', N'Nguyễn Văn An',     '2005-01-15', N'CTK47A'),
(N'SV002', N'Trần Thị Bình',     '2005-05-20', N'CTK47A'),
(N'SV003', N'Lê Minh Cường',     '2005-03-11', N'CTK47A'),
(N'SV004', N'Phạm Thanh Dung',   '2005-07-09', N'CTK47A'),
(N'SV005', N'Hoàng Quốc Em',     '2005-09-02', N'CTK47A'),
(N'SV006', N'Võ Thị Phương',     '2005-11-23', N'CTK47B'),
(N'SV007', N'Đặng Gia Huy',      '2005-02-18', N'CTK47B'),
(N'SV008', N'Bùi Ngọc Khánh',    '2005-12-30', N'CTK47B');

INSERT INTO MONHOC (MaMon, TenMon, SoTinChi) VALUES
(N'COMP1019', N'Lập trình trên Windows', 3),
(N'COMP1017', N'Cơ sở lập trình',        3);

-- Một vài điểm có sẵn để thấy rõ cơ chế UPDATE (đã có) và INSERT (chưa có)
INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) VALUES
(N'SV001', N'COMP1019', 8.5, N'Khá tốt'),
(N'SV002', N'COMP1019', 7.0, N'');
GO

/* ------------------------ STORED PROCEDURE ------------------------ */
CREATE OR ALTER PROCEDURE sp_Lop_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLop, TenLop
    FROM LOP
    ORDER BY TenLop;
END;
GO

CREATE OR ALTER PROCEDURE sp_MonHoc_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaMon, TenMon, SoTinChi
    FROM MONHOC
    ORDER BY TenMon;
END;
GO

-- Sinh viên chưa có điểm sẽ trả Diem = NULL (để Form bắt buộc người dùng nhập)
CREATE OR ALTER PROCEDURE sp_KetQua_GetByLopMon
    @MaLop NVARCHAR(20),
    @MaMon NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV,
           sv.HoTen,
           CAST(kq.Diem AS FLOAT)      AS Diem,
           ISNULL(kq.GhiChu, N'')      AS GhiChu
    FROM SINHVIEN sv
    LEFT JOIN KETQUA kq
           ON kq.MaSV = sv.MaSV AND kq.MaMon = @MaMon
    WHERE sv.MaLop = @MaLop
    ORDER BY sv.MaSV;
END;
GO

-- Upsert: đã có thì UPDATE, chưa có thì INSERT
CREATE OR ALTER PROCEDURE sp_KetQua_Save
    @MaSV   NVARCHAR(20),
    @MaMon  NVARCHAR(20),
    @Diem   FLOAT,
    @GhiChu NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = @MaSV AND MaMon = @MaMon)
    BEGIN
        UPDATE KETQUA
        SET Diem = @Diem, GhiChu = @GhiChu
        WHERE MaSV = @MaSV AND MaMon = @MaMon;
    END
    ELSE
    BEGIN
        INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu)
        VALUES (@MaSV, @MaMon, @Diem, @GhiChu);
    END
END;
GO

/* Kiểm tra nhanh:
EXEC sp_Lop_GetAll;
EXEC sp_MonHoc_GetAll;
EXEC sp_KetQua_GetByLopMon N'CTK47A', N'COMP1019';
SELECT * FROM KETQUA;
*/
