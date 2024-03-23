create database Quan_Li_Xe
go
use Quan_Li_Xe
go

create table Tai_khoan
(
	ten_dang_nhap nchar(50),
	email nchar(40),
	mat_khau nchar(30)
)
go
create table Khach_Hang
(
	cccd_khach nchar(12) primary key,
	ho_ten nvarchar(45),
	sdt nchar(10),
	email nchar(30),
	gioi_tinh nchar(3),
	que_quan nvarchar(45),
	ngay_sinh date,
	
)
go
-- 0 false dang muon, 1 true da tra
create table Xe
(
	bien_so nchar(12) primary key,
	ten_xe nvarchar(20),
	trang_thai nchar(1),
	loai_xe nvarchar(20),
	mau_xe nvarchar(20),
	so_cho nchar(2),
	hang_xe nvarchar(50),
	gia_thue int,
	tien_coc int,
	ten_nha_cung_cap nvarchar(50)
	
)
go
create table Nha_Cung_Cap
(
	ten_nha_cung_cap nvarchar(50),
	sdt nchar(10) ,
	primary key(ten_nha_cung_cap),
	dia_chi nvarchar(50),
)
go

create table Nhan_Vien
(
       cccd_nv nchar(12) primary key,
	   ho_ten nvarchar(30),
	   sdt nchar(10),
	   email nchar(30),
	   gioi_tinh nchar(3),
	   que_quan nvarchar(50),
	   ngay_sinh date,

)
go

create table Bang_Thue_Xe
(
	bien_so nchar(12),
	cccd_khach nchar(12),
	cccd_nv nchar(12),
	dia_diem_trao_xe nvarchar(30),
	ngay_thue datetime,
	so_ngay_thue int,
)

go

alter table Xe
	add constraint namencc foreign key (ten_nha_cung_cap) references Nha_Cung_Cap(ten_nha_cung_cap)
go
alter table Bang_Thue_Xe
	add constraint bienxe foreign key (bien_so) references Xe(bien_so)
go
alter table Bang_Thue_Xe
	add constraint cancuoc foreign key (cccd_khach) references Khach_Hang(cccd_khach)
go
alter table Bang_Thue_Xe
	add constraint cancuoc_2 foreign key (cccd_nv) references Nhan_Vien(cccd_nv)
go


--drop database Quan_Li_Xe 


-- chen du lieu vao bang
insert into Tai_khoan values ('bugs','cuvietcodelalaibug@gmail.com','1234')


go
insert into Nhan_Vien values('001204030805',N'Phạm Đình Minh','0927125394','cuvietcodelalaibug@gmail.com','Nam',N'Mỹ Đức, Hà Nội','08/09/2004')
go
insert into Khach_Hang values('001405780403',N'Anonymous','0913135394','anonymous@gmail.com','Nam',N'Private Zone','06/09/2004')
insert into Khach_Hang values('001919191919',N'abc','0313235369','abc@gmail.com','Nam',N'TLU','09/09/2000')
go
insert into Nha_Cung_Cap values(N'Công ty TNHHMMT','0382126246',N'Hưng Yên')
insert into Nha_Cung_Cap values(N'Vinfast','0999999999',N'Hà Nội')
go
insert into Xe values('29_01',N'Suzuki Swift','1',N'Ô tô',N'Đen','4','Suzuki',1000000,10000000,'Vinfast')
insert into Xe values('26_01',N'Suzuki Ertiga','1',N'Ô tô',N'Đen','7','Suzuki',1600000,16000000,'Vinfast')
insert into Xe values('29_02',N'Mazda 3','1',N'Ô tô',N'Đen','7','Mazda',1000000,10000000,'Vinfast')
insert into Xe values('29_04',N'Toyota Camry','1',N'Ô tô',N'Trắng','5','Toyota',1400000,14000000,'Công ty TNHHMMT')
insert into Xe values('29_05',N'Toyota Innova','1',N'Ô tô',N'Trắng','7','Toyota',1000000,10000000,N'Công ty TNHHMMT')
insert into Xe values('29_99',N'Honda Super Cub C125','1',N'Xe máy',N'Trắng','2','Honda',10000000,100000000,N'Công ty TNHHMMT')
go

insert into Bang_Thue_Xe 
values ('29_04','001919191919','001204030805',N'Công ty TNHHMMT',CONVERT(datetime, '19/03/2024 22:58:58', 103),12)
go 
insert into Bang_Thue_Xe 
values ('26_01','001405780403','001204030805',N'Thanh Xuân, Hà Nội',CONVERT(datetime, '20/03/2024 23:12:58', 103),20)
go

UPDATE Xe
set trang_thai = '0'
where bien_so = '29_04'
go
Update Xe 
set trang_thai ='0'
where bien_so = '26_01'


--chen du lieu datetime vao bang
--INSERT INTO test (ngay_thue)
--VALUES (CONVERT(datetime, '19/03/2024 22:58:58', 103))
SELECT FORMAT(ngay_thue, 'dd/MM/yyyy') AS formatted_date
FROM Bang_Thue_Xe;