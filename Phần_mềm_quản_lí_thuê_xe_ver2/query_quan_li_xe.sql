select * from Xe
select * from Nha_Cung_Cap
select * from Nhan_Vien
select * from Bang_Thue_Xe

select Xe.ten_xe, 
	   Xe.so_cho, 
	   Xe.bien_so, 
	   Khach_Hang.ho_ten as ho_ten_khach, 
	   Khach_Hang.sdt as sdt_khach,
	   Nhan_Vien.ho_ten as ho_ten_nv
FROM  Xe, Khach_Hang, Nhan_Vien where
Xe.bien_so = '29_04' and cccd_khach = '001919191919' and cccd_nv = '001204030805'



SELECT ten_dang_nhap, mat_khau FROM Tai_Khoan
WHERE ten_dang_nhap = ''Or 1=1--' and mat_khau = '123'