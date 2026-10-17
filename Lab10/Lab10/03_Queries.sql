
USE EduManagerDB;
GO

/* ============ PHẦN A. SELECT / UPDATE / DELETE ============ */

-- Câu 1. Liệt kê toàn bộ sinh viên
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;
GO

-- Câu 2. Liệt kê sinh viên kèm tên lớp và tên khoa (JOIN 3 bảng)
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP  l ON sv.MaLop  = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa  = k.MaKhoa;
GO

-- Câu 3. Tìm sinh viên theo một phần họ tên bằng LIKE
-- % đại diện cho chuỗi ký tự bất kỳ; ở đây tìm tên có chữ "An"
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%An%'
ORDER BY HoTen ASC;
GO

-- Câu 4. Liệt kê sinh viên theo mã lớp
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';
GO

-- Câu 5. Cập nhật họ tên của một sinh viên (luôn có WHERE!)
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An (đã sửa)'
WHERE MaSV = 'SV001';
GO
-- Xem lại kết quả sau khi cập nhật
SELECT MaSV, HoTen FROM SINHVIEN WHERE MaSV = 'SV001';
GO
-- (Có thể đổi lớp: UPDATE SINHVIEN SET MaLop = 'CNTT02' WHERE MaSV = 'SV001';)

-- Câu 6. Xóa một sinh viên CHƯA có dữ liệu điểm (SV007)
-- NOT EXISTS đảm bảo chỉ xóa khi không có dòng nào trong KETQUA
DELETE FROM SINHVIEN
WHERE MaSV = 'SV007'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV007');
GO
-- Xem lại: SV007 không còn
SELECT MaSV, HoTen FROM SINHVIEN;
GO

/* ============ PHẦN B. JOIN VÀ THỐNG KÊ ============ */

-- Câu 7. Điểm của từng sinh viên theo từng môn
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC  mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;
GO

-- Câu 8. Điểm trung bình của từng sinh viên (làm tròn 2 chữ số)
SELECT sv.MaSV, sv.HoTen, ROUND(AVG(kq.Diem), 2) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen;
GO

-- Câu 9. Thống kê số sinh viên theo từng lớp
-- LEFT JOIN để lớp chưa có sinh viên vẫn hiện (SoSinhVien = 0)
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop;
GO

-- Câu 10. Các lớp có từ 2 sinh viên trở lên
-- HAVING lọc SAU khi gom nhóm (WHERE không dùng được với COUNT)
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2;
GO

/* ============ PHẦN C. KIỂM THỬ RÀNG BUỘC (PHẢI BÁO LỖI) ============ */

-- Câu 11. Thêm sinh viên vào lớp không tồn tại
-- Mong đợi: lỗi FOREIGN KEY constraint "FK_SINHVIEN_LOP"
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
GO

-- Câu 12. Nhập điểm ngoài khoảng 0..10 (điểm 12)
-- Dùng cặp (SV003, COMP1020) CHƯA tồn tại để lỗi đến từ CHECK, không phải khóa chính
-- Mong đợi: lỗi CHECK constraint "CK_KETQUA_Diem"
INSERT INTO KETQUA (MaSV, MaMH, Diem)
VALUES ('SV003', 'COMP1020', 12);
GO

-- Câu 13 (bổ sung). Giới tính sai (không thuộc Nam/Nữ)
-- Mong đợi: lỗi CHECK constraint "CK_SINHVIEN_GioiTinh"
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV998', N'Sinh viên giới tính lỗi', '2005-01-01', N'Khác', 'CNTT01');
GO

-- Câu 14 (bổ sung). Trùng khóa chính (SV001 đã tồn tại)
-- Mong đợi: lỗi PRIMARY KEY constraint (Violation of PRIMARY KEY)
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV001', N'Trùng mã', '2005-01-01', N'Nam', 'CNTT01');
GO
