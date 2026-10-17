

-- Bước 1: Xóa database cũ (nếu có) để chạy lại từ đầu
USE master;
GO
-- Đóng mọi kết nối đang mở tới database cũ để DROP không bị lỗi "đang được sử dụng"
IF DB_ID('EduManagerDB') IS NOT NULL
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE IF EXISTS EduManagerDB;
GO

-- Bước 2: Tạo database mới và chuyển sang dùng nó
CREATE DATABASE EduManagerDB;
GO
USE EduManagerDB;
GO

-- Bước 3: Tạo bảng. Thứ tự: bảng "cha" trước, bảng "con" (có khóa ngoại) sau

-- ---------------------------------------------------------------------
-- Bảng KHOA: thông tin khoa (khóa chính MaKhoa)
-- ---------------------------------------------------------------------
CREATE TABLE KHOA (
    MaKhoa    VARCHAR(20)   NOT NULL PRIMARY KEY,
    TenKhoa   NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15)   NULL
);
GO

-- ---------------------------------------------------------------------
-- Bảng LOP: mỗi lớp thuộc một khoa (FK MaKhoa -> KHOA)
-- ---------------------------------------------------------------------
CREATE TABLE LOP (
    MaLop  VARCHAR(20)   NOT NULL PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(20)   NOT NULL,
    CONSTRAINT FK_LOP_KHOA
        FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
);
GO

-- ---------------------------------------------------------------------
-- Bảng SINHVIEN: mỗi sinh viên thuộc một lớp (FK MaLop -> LOP)
-- Giới tính chỉ nhận 'Nam' hoặc 'Nữ' (CHECK)
-- ---------------------------------------------------------------------
CREATE TABLE SINHVIEN (
    MaSV     VARCHAR(20)   NOT NULL PRIMARY KEY,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    GioiTinh NVARCHAR(10)  NOT NULL,
    MaLop    VARCHAR(20)   NOT NULL,
    CONSTRAINT CK_SINHVIEN_GioiTinh
        CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SINHVIEN_LOP
        FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

-- ---------------------------------------------------------------------
-- Bảng MONHOC: số tín chỉ phải > 0 (CHECK)
-- ---------------------------------------------------------------------
CREATE TABLE MONHOC (
    MaMH     VARCHAR(20)   NOT NULL PRIMARY KEY,
    TenMH    NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL,
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

-- ---------------------------------------------------------------------
-- Bảng KETQUA: điểm của sinh viên theo môn
-- Khóa chính ghép (MaSV, MaMH): một sinh viên chỉ có 1 điểm cho 1 môn
-- Điểm từ 0 đến 10 (CHECK); 2 khóa ngoại tới SINHVIEN và MONHOC
-- ---------------------------------------------------------------------
CREATE TABLE KETQUA (
    MaSV VARCHAR(20)  NOT NULL,
    MaMH VARCHAR(20)  NOT NULL,
    Diem DECIMAL(4,2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),
    CONSTRAINT FK_KETQUA_SINHVIEN
        FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC
        FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);
GO

-- ---------------------------------------------------------------------
-- Bảng TAIKHOAN: tài khoản đăng nhập demo (khóa chính TenDangNhap)
-- ---------------------------------------------------------------------
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50)   NOT NULL PRIMARY KEY,
    MatKhau     VARCHAR(100)  NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL DEFAULT 'User',
    TrangThai   BIT           NOT NULL DEFAULT 1
);
GO

-- Kiểm tra nhanh: phải thấy đủ 6 bảng
SELECT name AS TenBang FROM sys.tables ORDER BY name;
GO
