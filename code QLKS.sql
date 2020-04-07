create table tblPhong
(
MaPhong nvarchar(10) primary key,
TenPhong nvarchar(50),
Dongia float,
)
insert into tblPhong(MaPhong,TenPhong,Dongia) 
values ('P01', 'Phong 1', 1000000)
insert into tblPhong(MaPhong,TenPhong,Dongia) 
values ('P02', 'Phong 2', 500000)
insert into tblPhong(MaPhong,TenPhong,Dongia) 
values ('P03', 'Phong 3', 500000)