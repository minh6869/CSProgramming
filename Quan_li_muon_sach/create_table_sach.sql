CREATE TABLE SACH
(
	ma_sach NVARCHAR(30) PRIMARY KEY,
	ten_sach NVARCHAR (30),
	trang_thai char(7)
)
CREATE TABLE BANG_MUON_TRA
(
	ho_ten_sinh_vien nvarchar(30),
	ten_sach nvarchar(30),
	ma_sach nvarchar(30) foreign key references SACH(ma_sach),
	ngay_muon date,
	ngay_tra date,
	ngay_tra_thuc_te date,
	so_ngay_muon int,
	thanh_tien int


)
INSERT INTO BANG_MUON_TRA VALUES(N'ABC',N'OOP',N'11','07/03/2024','09/03/2024',0)
INSERT INTO BANG_MUON_TRA VALUES(N'test',N'Kĩ năng làm giàu',N'02','03/28/2024','03/30/2024',0)
INSERT INTO BANG_MUON_TRA VALUES(N'bugs',N'Nhập môn lập trình',N'06','03/13/2024','09/30/2024',0)
INSERT INTO BANG_MUON_TRA VALUES(N'zhishu',N'An ninh mạng',N'09','03/12/2024','09/08/2024',0)


INSERT INTO SACH (ma_sach, ten_sach, trang_thai) VALUES (N'01',N'Đắc Nhân Tâm','enable')
select * from BANG_MUON_TRA
Select * from SACH

select GETDATE()
SELECT SACH.trang_thai FROM BANG_MUON_TRA INNER JOIN SACH
ON SACH.ma_sach = BANG_MUON_TRA.ma_sach 
WHERE N'Kĩ năng làm giàu' = SACH.ten_sach
AND  '02' = SACH.ma_sach 

SELECT SACH.trang_thai FROM SACH
WHERE N'OOP' = SACH.ten_sach
AND N'08' = SACH.ma_sach

UPDATE SACH
SET trang_thai = 'disable'
WHERE ma_sach = '09'
select ho_ten_sinh_vien from BANG_MUON_TRA