create table tblKhachhang(
	PK_iKhachhang int identity(1,1) primary key ,
 	sHoTen	nvarchar(100)  not null,
	sSoDienThoai varchar(15) unique not null,
	sCCCD varchar(12) ,
	sEmail nvarchar(100),
	sDiaChi nvarchar(200),
	dNgayTao datetime default getdate()
)
alter table tblKhachHang add Fk_iTaiKhoan int foreign key references TblTaiKhoan(PK_iTaiKhoan)

create table tblNhanvien(
	PK_iNhanvien int identity(1,1) primary key ,
 	sHoTen	nvarchar(100)  not null,
	sSoDienThoai varchar(15) unique not null,
	sMatKhau varchar(255) not null ,
	sVaiTro nvarchar(20) Default 'staff',
	dNgayTao datetime default getdate()
)
alter table tblNhanvien add Fk_iTaiKhoan int foreign key references TblTaiKhoan(PK_iTaiKhoan)
create table tblXe(
	PK_iXe Int identity(1,1) primary key,
	sBienSo varchar(20) unique not null,
	sThuongHieu nvarchar(50) not null ,
	sLoaiXe nvarchar(50) not null,
	fGiaNgay decimal(10,2) not null,
	fGiaGio decimal(10,2) not null,
	sTrangThai nvarchar(20) Default 'available',
	sAnhURL varchar(255) not null,
	sMoTa ntext
)

create table tblLoaiHuHong(
	PK_iLoaiHuHong int identity(1,1) primary key,
	sTenHuHong nvarchar(100) not null,
	fPhiPhat decimal(10,2)not null
)
create table tblDonDatXe(
	PK_iDonDat Int identity(1,1) primary key,
	FK_iKhachhang int not null ,
	FK_iXe int not null,
	dThoiGianBatDau datetime not null,
	dThoiGianKetThuc datetime not null,
	fGiaTamTinh decimal(10,2) not null,
	fTienCoc Decimal(10,2) not null,
	bTrangThai bit not null,
	dNgayTao datetime default getdate() ,
	dNgayHuy datetime,
	constraint FK_iKhachHang_tbDonDatXe foreign key(FK_iKhachhang) references tblKhachhang(PK_iKhachhang),
	constraint FK_iXe_tbDonDatXe foreign key(FK_iXe) references tblXe(PK_iXe),
	
)
create table tblHopDong(
	PK_iHopDong int identity(1,1) primary key,
	FK_iDonDat int ,
	FK_iKhachhang int not null ,
	FK_iNhanvien int not null,
	FK_iXe int not null,
	dGiaoThucTe datetime default getdate() ,
	dTraDuKien datetime not null,
	dTraThucTe datetime not null,
	fTienCocDaNhan Decimal(10,2) not null,
	constraint FK_iKhachHang_tbHopDong foreign key(FK_iKhachhang) references tblKhachhang(PK_iKhachhang),
	constraint FK_iXe_tbHopDong foreign key(FK_iXe) references tblXe(PK_iXe),
	constraint FK_iDonDat_tbHopDong foreign key(FK_iDonDat) references tblDonDatXe(PK_iDonDat),
	constraint FK_iNhanvien_tbHopDong foreign key(FK_iNhanvien) references tblNhanvien(PK_iNhanvien),


)
create table tblHoaDon(
	PK_iHoaDon int identity(1,1) primary key,
	FK_iHopDong int not null ,
	dNgayLap datetime default getdate() ,
	FK_iLoaiHuHong int , 
	sPhuongThucThanhToan nvarchar(20) not null,
	sTrangThaiThanhToan nvarchar(20) not null,
	constraint FK_iHopDong_tblHoaDon foreign key(FK_iHopDong) references tblHopDong(PK_iHopDong),
	constraint FK_iLoaiHuHong_tblHoaDon foreign key(Fk_iLoaiHuHong) references tblLoaiHuHong(PK_iLoaiHuHong)
)

create table tblTaiKhoan(
	PK_iTaiKhoan int identity(1,1) primary key,
	sMatKhau nvarchar(255) not null,
	sSoDienThoai varchar (15) not null,
	sVaiTro nvarchar(50) not null,
)


drop table tblDonDatXe,tblHoaDon,tblHopDong,tblKhachhang,tblLoaiHuHong,tblNhanvien,tblXe

select * from tblKhachHang

select * from tblTaiKhoan
select * from tblXe
select * from tblDonDatXe

