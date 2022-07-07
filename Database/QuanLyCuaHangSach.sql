CREATE DATABASE QuanLyCuaHangSach
GO

USE QuanLyCuaHangSach
GO



create table Khosach
(
Masach char(10) not null primary key default N'Trống',
Loaisach nvarchar(100)  not null default N'Trống',
Tensach nvarchar(100)  not null default N'Trống',
Tacgia nvarchar(100)  not null default N'Trống',
Nhaxuatban nvarchar(100) not null default N'Trống',
Soluong int not null default N'Trống',
Giatien int not null default N'Trống'

)
Go


create table Muasach
(

Loaisach nvarchar(100) not null default N'Trống',
Tensach nvarchar(100) not null default N'Trống',
Soluong int not null default N'Trống',
Giatien int not null default N'Trống',
NgayMua Date 

)
go



insert into Khosach values 

 ( 'S01',N'Thơ',N'Những chiếc nôi ru',N'Châu Tuấn',N'NXB Văn học',20,50000),
 ('S02', N'Tập truyện ngắn',N'Nghiệp rừng',N'Triệu Hoàng Giang',N'NXB Văn học',15,70000),
 ('S03', N'Sách Văn học nghệ thuật',N'Giá trị của sự tử tế',N'Piero Ferrucci',N'NXB Hồng Đức',28,120000),
 ('S04', N'Thiếu nhi',N'Hoàng Tử Bé',N'Lê Việt Dũng',N'NXB Thanh Niên',22,67000),
 ('S05', N'Thiếu nhi',N'Chuyện Nỏ Thần',N'Văn Minh',N'NXB Kim Đồng',10,43000),
 ('S06', N'Toán',N'Cùng Vui Học Toán ',N'Thanh Tùng',N'Nxb Mỹ thuật',12,25000),
 ('S07', N'Kinh tế',N'Kinh Doanh Nhỏ Thu Lợi Lớn',N'DR Rusly Abdullah PHD',N'Nxb Thế giới',16,75000),
 ('S08', N'Kinh tế',N'Digital Marketing ',N'Avery Swartz',N'Nxb Công Thương',21,54000),
 ('S09', N'Ngoại Ngữ',N'Tiếng Nhật',N'Masateru Takatsu',N'Nxb Tổng hợp TP.HCM',13,23000),
 ('S10', N'Ngoại Ngữ',N'Tiếng Hàn',N'Văn Đức',N'Nxb Hà Nội',17,45000)


 


