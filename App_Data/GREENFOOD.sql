use master

IF EXISTS(SELECT * FROM master.sys.sysdatabases WHERE name='GREENFOOD')
	drop Database GREENFOOD
GO
CREATE DATABASE GREENFOOD
GO
USE GREENFOOD
GO
CREATE TABLE PHANQUYEN
(
	MaPQ int not null primary key,
	TenPQ nvarchar(10)
)
GO
INSERT INTO PHANQUYEN
VALUES
(1,'Admin'),
(2,N'Thành viên'),
(3,N'Shipper')
GO
--CREATE TABLE QUANTRI-------------------------------------DELETE-----------------------------------
--(
--	UserName varchar(50) primary key not null,
--	Pw varchar(50) not null,
--	MaPQ int foreign key references PHANQUYEN(MaPQ)
--)
--GO
--INSERT INTO QuanTri
--VALUES
--('Nhon','123',1),
--('Cuong','456',1),
--('Thao','789',1),
--('Nam','001',2)

--GO
CREATE TABLE NHANVIEN
(
	MaNV int identity not null,
	HoTenNV nvarchar(50) not null,
	ChucVu nvarchar(50),
	DienThoai char(12),
	GioiTinh  nvarchar(6) check (GioiTinh in('Male','Female','Unk')) not null,
	DiaChi nvarchar(50),
	Email nvarchar(50),
	UserName varchar(50) not null, ------------------EDIT-----------------
	Pw varchar(50) not null,--NEW
	MaPQ int foreign key references PHANQUYEN(MaPQ),--NEW
	Facebook varchar(255),
	primary key(MaNV, UserName)
)
GO
INSERT INTO NHANVIEN
VALUES
( N'Mai Chấn Cường','Manager','09475538266','Male',N'55/7 Phan Tứ','cuong123@gmail.com','cuong','123', 1,''),
( N'Cao Thành Nhơn','Manager','08455379368','Male',N'55/7 Phan Tứ','nhon123@gmail.com','Nhon','123', 1,''),
( N'Lã Thị Phương Thảo','Manager','09485534372','Female',N'82/7 Lê Hồng Phong','pt456@gmail.com','Thao','123', 1,'')
GO
CREATE TABLE KHACHHANG
(	
	MaKH int identity primary key not null,
	HoTenKH nvarchar(50) not null,
	DienThoai char(12),
	DiaChi nvarchar(50),
	Email nvarchar(50)
)
GO
INSERT INTO KHACHHANG
VALUES
(N'Trần Quang Phú','01227893217',N'45 Cao Thắng','tranquangphu1997@gmail.com'),
(N'Trần Đình Khanh','0913456411',N'47 Hàm Nghi','khanhtrandinh@gmail.com'),
(N'Nguyễn Như Quỳnh','0977156485',N'56 Nguyễn Văn Linh','nhuquynh@gmail.com'),
(N'Nguyễn Tiến Linh','098454436',N'78/22 Quang Trung','linhnguyen@gmail.com')
GO
CREATE TABLE THANHVIEN
(
	MaTV int identity primary key not null,
	UserName varchar(50),
	Pw varchar(50),
	HoTenTV nvarchar(50) not null,
	DienThoai char(12),
	GioiTinh  nvarchar(6) check (GioiTinh in('Male','Female','Unk')) not null,
	DiaChi nvarchar(50),
	Email nvarchar(50),
	NgayDK date default getdate()
)
GO
INSERT INTO THANHVIEN
VALUES
('phithien','123',N'Võ Hữu Phi Thiên','0932428759',N'Male',N'52 Nguyễn Văn Linh','phithienvo@gmail.com','04-12-2021'),
('linhnguyen','456',N'Nguyễn Tiến Linh','098454436',N'Male',N'78/22 Quang Trung','linhnguyen@gmail.com', '03-25-2021')
GO
CREATE TABLE LOAITHUCPHAM
(
	MaLoaiThucPham int identity primary key not null,
	TenLoaiThucPham nvarchar(50) not null,
)
GO
INSERT INTO LOAITHUCPHAM
VALUES
(N'Thịt tươi'),
(N'Trái cây'),
(N'Rau củ'),
(N'Hải sản tươi'),
(N'Dầu ăn thực vật'),
(N'Các loại sản phẩm từ trứng')
GO
CREATE TABLE THUCPHAM
(	
	MaThucPham int identity primary key not null,
	TenThucPham nvarchar(30) not null,
	MaLoaiThucPham int foreign key references LOAITHUCPHAM(MaLoaiThucPham),
	UserName nvarchar(50),--foreign key references NHANVIEN(UserName),
	NgayDang date default getdate(),
	Duyet int check (Duyet in (1,0)) default 0,
	CheckSale int default 0, --NEW
	TrungBinhDanhGia float default 0,
	GiamGia int   --NEW
)
GO
INSERT INTO THUCPHAM
VALUES
(N'Bắp cải',3,N'Thao', '09-12-2021',1,0,0,0),
(N'Bắp mỹ',3,N'Thao','09-12-2021',1,0,0,0),
(N'Bầu',3,N'Thao','09-03-2021',1,0,0,0),
(N'Bí đỏ',3,N'Thao','09-08-2021',1,0,0,0),
(N'Bí xanh',3,N'Thao','09-08-2021',1,0,0,0),
(N'Bông súng',3,N'Thao','09-10-2021',1,0,0,0),
(N'cà chua bi',3,N'Thao','09-09-2021',1,0,0,0),
(N'Cải bó xôi',3,N'Thao','09-15-2021',1,0,0,0),
(N'Cải ngọt',3,N'Thao','09-14-2021',1,0,0,0),
(N'Cải thìa',3,N'Thao','09-14-2021',1,0,0,0),
(N'Cần tây',3,N'Thao','09-14-2021',1,0,0,0),
(N'Cà rốt',3,N'Thao','09-14-2021',1,0,0,0),
(N'Cà tím',3,N'Thao','09-14-2021',1,0,0,0),
(N'Củ cải đỏ',3,N'Thao','09-14-2021',1,0,0,0),
(N'Củ cải trắng',3,N'Thao','09-14-2021',1,0,0,0),
(N'Củ dền',3,N'Thao','09-14-2021',1,0,0,0),
(N'Đậu bắp',3,N'Thao','09-14-2021',1,0,0,0),
(N'Dưa leo',3,N'Thao','09-14-2021',1,0,0,0),
(N'Giá',3,N'Thao','09-14-2021',1,0,0,0),
(N'Gừng',3,N'Thao','09-14-2021',1,0,0,0),
(N'Me',3,N'Thao','09-14-2021',1,0,0,0),
(N'Hành lá',3,N'Thao','09-14-2021',1,0,0,0),
(N'Hành tây',3,N'Thao','09-14-2021',1,0,0,0),
(N'Khoai lang',3,N'Thao','09-14-2021',1,0,0,0),
(N'Khoai mỡ',3,N'Thao','09-14-2021',1,0,0,0),
(N'Khoai môn',3,N'Thao','09-14-2021',1,0,0,0),
(N'Khoai tây',3,N'Thao','09-14-2021',1,0,0,0),
(N'Nấm bào ngư',3,N'Thao','09-14-2021',1,0,0,0),
(N'Nấm đùi gà',3,N'Thao','09-14-2021',1,0,0,0),
(N'Nấm hải sản',3,N'Thao','09-14-2021',1,0,0,0),
(N'Nấm kim châm',3,N'Thao','09-14-2021',1,0,0,0),
(N'Ngò nhí',3,N'Thao','09-14-2021',1,0,0,0),
(N'Ớt hiểm',3,N'Thao','09-14-2021',1,0,0,0),
(N'Rau dền',3,N'Thao','09-14-2021',1,0,0,0),
(N'Rau muống',3,N'Thao','09-14-2021',1,0,0,0),
(N'Su hào',3,N'Thao','09-14-2021',1,0,0,0),
(N'Su su',3,N'Thao','09-14-2021',1,0,0,0),
(N'Tắc',3,N'Thao','09-14-2021',1,0,0,0),
(N'Rau tần ô',3,N'Thao','09-14-2021',1,0,0,0),
(N'Xà lách lô lô',3,N'Thao','09-14-2021',1,0,0,0),
(N'Xà lách búp',3,N'Thao','09-14-2021',1,0,0,0),
(N'Cam Valencia',2,N'Thao','09-14-2021',1,0,0,0),
(N'Chanh dây',2,N'Thao','09-14-2021',1,0,0,0),
(N'Dâu tây New Zealand',2,N'Thao','09-14-2021',1,0,0,0),
(N'Lê Nam Phi',2,N'Thao','09-14-2021',1,0,0,0),
(N'Ổi nữ hoàng',2,N'Thao','09-14-2021',1,0,0,0),
(N'Xoài',2,N'Thao','09-14-2021',1,0,0,0),
(N'Táo mỹ',2,N'Thao','09-14-2021',1,0,0,0),
(N'Thịt heo ba rọi',1,N'Thao','09-14-2021',1,0,0,0),
(N'Chân giò',1,N'Thao','09-14-2021',1,0,0,0),
(N'Móng giò',1,N'Thao','09-14-2021',1,0,0,0),
(N'Thịt sườn cốt',1,N'Thao','09-14-2021',1,0,0,0),
(N'Thịt nạc dăm',1,N'Thao','09-14-2021',1,0,0,0),
(N'Thịt sườn non',1,N'Thao','09-14-2021',1,0,0,0),
(N'Ức gà',1,N'Thao','09-14-2021',1,0,0,0),
(N'Cánh gà',1,N'Thao','09-14-2021',1,0,0,0),
(N'Chân gà',1,N'Thao','09-14-2021',1,0,0,0),
(N'Đùi gà',1,N'Thao','09-14-2021',1,0,0,0),
(N'Gà nguyên con',1,N'Thao','09-14-2021',1,0,0,0),
(N'Trứng gà',6,N'Thao','09-14-2021',1,0,0,0),
(N'Trứng vịt',6,N'Thao','09-14-2021',1,0,0,0),
(N'Cá nục',4,N'Thao','09-14-2021',1,0,0,0),
(N'Cá Basa',4,N'Thao','09-14-2021',1,0,0,0),
(N'Cá trứng',4,N'Thao','09-14-2021',1,0,0,0),
(N'Chả cá thác lác',4,N'Thao','09-14-2021',1,0,0,0),
(N'Lườn cá hồi',4,N'Thao','09-14-2021',1,0,0,0),
(N'Dầu ăn đậu nành',5,N'Thao','09-14-2021',1,0,0,0),
(N'Dầu ăn Cái Lân',5,N'Thao','09-14-2021',1,0,0,0),
(N'Dầu ăn Tường An',5,N'Thao','09-14-2021',1,0,0,0),
(N'Dầu ăn Simply',5,N'Thao','09-14-2021',1,0,0,0)
GO
---drop table THUCPHAM
CREATE TABLE CHITIETTHUCPHAM
(
	STT int identity primary key not null,
	MaThucPham int foreign key references THUCPHAM(MaThucPham),
	MaLoaiThucPham int foreign key references LOAITHUCPHAM(MaLoaiThucPham),
	TenThucPham nvarchar(30),
	Gia money,
	Mota nvarchar(4000),
	TrongLuong int not null,
	AnhBia nvarchar(500),
	HanSuDung date default getdate(),
	SoLuongBan int,
	SoLuongDaBan int default 0,
)
GO

--drop table CHITIETTHUCPHAM
INSERT INTO CHITIETTHUCPHAM
VALUES
(1,3,N'Bắp cải',12500,N'Là một loại thực phẩm vô cùng quen thuộc, rất dễ mua và chế biến thành nhiều món ăn đa dạng khác nhau trong bữa cơm hằng ngày. Bắp cải trắng đặc biệt mang đến lợi ích trong việc hỗ trợ phòng chống ung thư, giúp cơ thể khỏe mạnh toàn diện. &nbsp;
Các món có thể chế biến từ Bắp Cải: &nbsp;
-Ăn sáng với trứng chiên bắp cải &nbsp;
-Mì tôm xào bắp cải, trứng đơn giản ngon miệng &nbsp;
-Ăn chay cùng bắp cải cuộn rau củ &nbsp;
-Gà xào bắp cải phô mai kiểu Hàn Quốc &nbsp;
-Canh bắp cải thanh mát &nbsp;',500,'bapcai.jpg','09-25-2021',30,0),
(2,3,N'Bắp mỹ',17000,N'Bắp Mỹ là một loại thực phẩm được trồng rất nhiều ở khắp nơi trên thế giới. Đây là một loại quả vừa ngon, lại có rất nhiều chất khoáng chất và vitamin. Bắp có thể chế biến thành nhiều món ăn ngon như: cơm bắp, chè bắp, sữa bắp,... bất kỳ món gì cũng tạo nên hương vị tuyệt hảo. &nbsp;
Các món có thể chế biến từ Bắp Mỹ: &nbsp;
- Cơm bắp thơm ngọt. &nbsp;
- Chè bắp ngọt ngon. &nbsp;
- Bắp luộc nhanh chóng tiện lợi. &nbsp;
- Bánh phồng tôm nhân bắp đậu cà rốt lạ miệng. &nbsp;
- Súp tôm bắp ngon ngất ngây. &nbsp;
- Sữa bắp dinh dưỡng',700,'bapmy.jpg','09-25-2021',30,0),
(3,3,N'Bầu',11000,N'Được nhiều chị em nội trợ chọn mua để chế biến thành các món ăn ngon cho gia đình. Ngoài làm thực phẩm, bầu sao còn có thể dùng trong đông y, có tác dụng lợi tiểu, mát gan, giải độc, làm đẹp da và giảm cân. Bầu có thể chế biến thành các món ăn như: luộc, xào, nấu canh đều rất ngon. &nbsp;
Các món có thể chế biến từ Bầu: 
- Bầu luộc chấm muối vừng, mát và bổ.&nbsp;
- Bầu nấu tôm thanh mát.&nbsp;
- Canh bầu nấu thịt.&nbsp;',500,'bau.jpg','09-25-2021',30,0),
(4,3,N'Bí đỏ',21000,N'Còn gọi là bí đỏ hạt đậu, đây là giống bí có ruột rất đặc, ít hả ăn dẻo và ngọt. Bí hồ lô chứa nhiều chất dinh dưỡng và mang lại nhiều lợi ích cho sức khoẻ. Bí hồ lô có thể chế biến thành nhiều món ăn ngon như: sữa bí, canh bí, súp bí,... món nào cũng đều thơm ngon. &nbsp;
- Các món có thể chế biến từ Bí Đỏ:&nbsp;
- Tăng cân với sữa bí đỏ hạt sen.&nbsp;
- Canh bí đỏ hầm xương bổ dưỡng cho cả nhà.&nbsp;
- Súp bí đỏ kem tươi béo ngậy.&nbsp;
- Bổ não cùng với món óc heo chưng bí đỏ.&nbsp;
- Cháo gà bí đỏ bổ dưỡng cho bé cưng nhà bạn.&nbsp;',700,'bidoholo.jpg','09-25-2021',30,0),
(5,3,N'Bí xanh',14000,N'Được nhiều chị em nội trợ chọn mua để chế biến thành các món ăn ngon cho gia đình. Ngoài làm thực phẩm, bí xanh còn có thể dùng trong đông y, có tác dụng lợi tiểu, mát gan, giải độc, làm đẹp da và giảm cân. Bầu có thể chế biến thành các món ăn như: luộc, xào, nấu canh đều rất ngon. &nbsp;
Các món có thể chế biến từ Bí Xanh:.&nbsp;
- Trà bí đao hạt chia.&nbsp; 
- Canh bí đao thịt bằm.&nbsp; 
- Canh bí đao nhồi thịt.&nbsp; 
- Mứt bí đao đường phèn.&nbsp;',500,'bixanh.jpg','09-25-2021',30,0),
(6,3,N'Bông súng',13000,N'Bông súng - đặc sản miền Tây có mùi thơm, nhiều màu: màu trắng, màu tím lục bình, màu hồng cánh sen. Thân bông súng có màu nâu. Vị giòn, ngọt và thơm nên thường người sử dụng thân bông súng để chế biến món ăn như gỏi, lẩu,... &nbsp;
Các món có thể chế biến từ Bông Súng:.&nbsp;
- Làm rau sống.&nbsp;
- Bông súng bóp xổi.&nbsp;
- Gỏi bông súng.&nbsp;
- Bông súng xào.&nbsp;
- Canh chua, lẩu chua bông súng.&nbsp;
- Bông súng muối chua.&nbsp;
- Gỏi bông súng tôm thịt.&nbsp;',300,'bongsung.jpg','09-25-2021',30,0),
(7,3,N'Cà chua bi',8000,N'Cà chua bi là loại rau củ rất tốt cho sức khoẻ, đây là giống cà có kích thước khá nhỏ nhưng cũng rất dồi dào chống dinh dưỡng như chất xơ, vitamin C,... Bạn có thể sử dụng cà chua bi để ăn sống, trộn salad hoặc có thể dùng để chế biến thành các món ăn khác đều rất tốt.&nbsp;
Các món có thể chế biến từ Cà Chua Bi:.&nbsp; 
- Xiên cùng với thịt heo, thịt bò nướng, hải sản nướng và các loại củ khác..&nbsp;
- Canh chua cá tra chua cay, đúng vị miền Tây.&nbsp;
- Giảm cân cùng nước ép, sinh tố cà chua.&nbsp;',250,'cachuabi.jpg','09-25-2021',30,0),
(8,3,N'Cải bó xôi',32500,N'Với công dụng tuyệt vờicó thể kể đến như chống ung thư, chống viêm, ngăn ngừa bệnh tuyến tiền liệt, hỗ trợ giảm cân, làm đẹp da, sáng mắt,.... Cải bó xôi của Bách hóa xanh tự tin mang đến cho bạn những món ăn đầy đủ dinh dưỡng, hấp dẫn và thanh mát.&nbsp;
Các món có thể chế biến từ Cải bó xôi:.&nbsp;
- Canh cải bó xôi nấu tôm, nấu với thịt băm.&nbsp;
- Cháo cá hồi cải bó xôi.&nbsp;
- Cải bó xôi xào thịt bằm,....&nbsp;',500,'caiboxoi.jpg','09-25-2021',30,0),
(9,3,N'Cải ngọt',18800,N'Với vị ngọt thanh, phù hợp với việc chế biến nhiều món ăn khác nhau nên Cải ngọt baby được sử dụng phổ biến trong các bữa ăn của người Việt. Do chưa hàm lượng dinh dưỡng cao nên cải ngọt giúp phòng ngừa ung thư, hỗ trợ trị bệnh gout,....&nbsp;
Các món có thể chế biến từ Cải Ngọt:.&nbsp;
Cải ngọt có vị ngọt thanh tự nhiên, vì thế chúng thường được chế biến thành các món canh để tạo ra vị thanh đạm như canh cải ngọt thịt bằm, canh cải ngọt hến,....&nbsp;
Khi kết hợp cải ngọt với các loại nấm, thịt heo, thịt bò, hải sản,... sẽ tạo ra những món xào đơn giản như rất thơm ngon và bổ dưỡng như cải ngọt xào tỏi, cải ngọt xào nấm bào ngư,....&nbsp;
Đặc biệt, cải ngọt là một trong những nguyên liệu không thể thiếu để tạo ra những món mì xào giòn hải sản, mì xào thịt bò,... thơm ngon..&nbsp;',300,'caingot.jpg','09-25-2021',30,0),
(10,3,N'Cải thìa',6900,N'Cải thìa còn có tên là bạch giới tử thuộc họ cải cùng họ với cải thảo, cải bẹ xanh. Đây là loại rau chứa nhiều thành phần dinh dưỡng dễ chế biến, ăn ngon miệng. Đặc biệt, rau cải thìa cũng mang đến nhiều lợi cho sức khỏe như phòng ngừa bệnh đục nhân mắt, ngăn ngừa ung thư,...&nbsp;
Các món có thể chế biến từ Cải Thìa:.&nbsp;
Canh cải thìa với tôm.&nbsp;
Cải thìa xào thịt nạc.&nbsp;',300,'caithia.jpeg','09-25-2021',30,0),
(11,3,N'Cần tây',14700,N'Cần tây là loại rau quen thuộc trong bữa ăn hàng ngày, không chỉ giúp món ăn thêm phần thơm ngon mà còn mang lại nhiều lợi ích cho sức khỏe. Theo chuyên gia dinh dưỡng Megan Ware, trong cần tây chứa gần 95% nước cùng nhiều vitamin, protein và chất khoáng. Đặc biệt, hàm lượng vitamin K trong cần tây rất cao. Bên cạnh đó, cần tây chứa hàm lượng chất xơ phong phú, giúp ích cho quá trình đào thải độc tố ra ngoài cơ thể.&nbsp;
Các món có thể chế biến từ Cần tây:.&nbsp;
- Detox ngon miệng với nước ép cần tây táo xanh.&nbsp;
- Da đẹp với nước ép cần tây, cà rốt và táo.&nbsp;
- Mực xào cần tây đơn giản thơm ngon.&nbsp;
- Thịt bò xào cần tây dinh dưỡng.&nbsp;
- Sinh tố cần tây cực dễ uống.&nbsp;',200,'cantay.jpg','09-25-2021',30,0),
(12,3,N'Cà rốt',14000,N'Cà rốt không chỉ là loại củ quen thuộc trong các món ăn trong gia đình mà còn là vị thuốc quý, rất tốt cho sức khỏe. Với hàm lượng chất dinh dưỡng và vitamin A cao, cà rốt được xem là một nguyên liệu cần thiết cho các món ăn dặm của trẻ nhỏ, giúp trẻ sáng mắt và cung cấp nguồn chất xơ dồi dào.&nbsp;
Ngoài ra, cà rốt còn được xem là một "thần dược" trong quá trình chăm sóc da của phụ nữ. Chỉ với những bước làm đơn giản là bạn đã có ngay hỗn hợp mặt nạ cà rốt - mật ong giúp ngăn ngừa mụn, làm sáng da và cải thiện làn da sạm và lão hóa.&nbsp;
Các món có thể chế biến từ Cà rốt:.&nbsp;
- Cà rốt có thể chế biến thành nước ép cà rốt cam và củ dền, nước ép cà rốt và cà chua, sinh tố cà rốt. Ngoài ra, cà rốt cũng có thể làm cà rốt, củ cải chua ăn kèm với thịt nguội, chả lụa cho các bữa tiệc. Một số món ăn từ cà rốt như sau: Các loại cháo bổ dưỡng cho trẻ như cháo tim heo cà rốt, cháo lươn cà rốt, cháo thịt bò cà rốt,...&nbsp;
- Cà rốt dùng cho các món nộm gỏi như nộm su hào cà rốt hoặc làm ra món kim chi cải thảo truyền thống của Hàn Quốc,...&nbsp;
- Cà rốt xào với mì, nui,... cùng với các nguyên liệu thịt heo, thịt bò, trứng,... Đặc biệt, cà rốt còn được xem là món ăn vặt an toàn khi được chế biến thành mứt cà rốt, thích hợp cho việc nhâm nhi của cả gia đình.&nbsp; ',500,'carot.jpg','09-25-2021',30,0),
(13,3,N'Cà tím',25500,N'Cà tím hay còn được gọi là cà dái dê, đây là một loại rau củ chế biến được thành rất nhiều món ăn thơm ngon như: hấp, xào, nướng, ăn sống,... mỗi dạng đều mang lại hương vị rất ngon. Trong cà tím chứa hàm lượng chất xơ vô cùng cao và giàu sắt rất tốt cho cơ thể.&nbsp;
Cà tím có tên gọi khác là cà dái dê, có họ hàng với cà chua, khoai tây, cà pháo. Loại củ, quả này sử dụng trong chế biến dưới dạng thức ăn hầm, xào, nướng. Nhờ chứa hàm lượng chất xơ vô cùng cao và giàu sắt, cà tím còn giúp giảm nguy cơ mắc các bệnh ung thư như ung thư ruột kết, trực tràng, tim mạch, chữa chứng hay quên,...&nbsp;
Các món có thể chế biến từ Cà tím:&nbsp;
- Cà tím chiên tẩm nước tương.&nbsp;
- Cà tím nhồi thịt, sốt chua ngọt.
- Thanh ngọt, bùi béo với cà tím hấp mỡ hành,...&nbsp;',500,'catim.jpg','09-25-2021',30,0),
(14,3,N'Củ cải đỏ',37500,N'Củ cải đỏ hay củ cải đường có vị ngọt mát, thanh đạm, có lớp vỏ ngoài mỏng, màu đỏ hồng. Bên trong có phần thịt giòn xốp màu trắng trong và củ có dạng tròn. Củ cải đỏ còn chứa rất nhiều chất dinh dưỡng, vitamin rất tốt cho cơ thể, giúp giảm cân hiệu quả, lành mạnh.&nbsp;
Củ cải đỏ (hay còn gọi là củ cải đường) có vị ngọt mát, thanh đạm, là nguyên liệu không thể thiếu cho những thực đơn giảm cân lành mạnh và hiệu quả. Đồng thời, loại củ này cũng chứa rất nhiều vitamin và khoáng chất cần thiết cho cơ thể.&nbsp;
Không giống với cà rốt và củ cải trắng, củ cải đỏ có lớp vỏ ngoài mỏng, màu đỏ hồng. Bên trong có phần thịt giòn xốp màu trắng trong và củ có dạng tròn.&nbsp;
Các món có thể chế biến từ Củ cải đỏ:.&nbsp;
- Nộm củ cải đỏ – Món ăn ngon với củ cải đỏ.&nbsp;
- Củ cải đỏ hầm cánh gà – Món ăn ngon với củ cải đỏ.&nbsp;
- Súp củ cải – món ăn đặc trưng của người ukraine.&nbsp;
- Súp củ cải đỏ là một món ăn đặc biệt.&nbsp;',500,'cucaido.jpg','09-25-2021',30,0),
(15,3,N'Củ cải trắng',13500,N'Củ cải trắng là một loại rau củ vừa có thể dùng để làm thực phẩm, vừa có thể sử dụng để làm dầu hạt cải. Loại rau củ này chứa rất nhiều vitamin và khoáng chất, rất tốt cho cơ thể. Một vài công dụng của củ cải trắng có thể kể đến như: hỗ trợ giảm cân, hỗ trợ hệ tiêu hoá, tăng cường miễn dịch,...&nbsp;
Củ cải trắng hay còn được gọi là củ cải mùa đông, có nguồn gốc từ Trung Quốc và Nhật Bản. Đây là một loại rau củ được trồng để làm thực phẩm và dầu hạt. Củ cải trắng có ngoại hình giống với cà rốt nhưng có màu trắng, mùi vị thì hơi ngọt và cay.&nbsp;
Các món có thể chế biến từ Củ Cải Trắng:&nbsp;
Củ cải trắng có thể chế biến thành nhiều món ăn ngon có thể kể đến như: Thịt kho củ cải, bò kho củ cải, cá kèo kho củ cải trắng,... Đặc biệt, củ cải trắng còn là nguyên liệu không thể thiếu trong việc chế biến thành các món kim chi Hàn Quốc hay kim chi Việt Nam từ củ sen giòn.&nbsp;',500,'cucaitrang.jpg','09-25-2021',30,0),
(16,3,N'Củ dền',17500,N'Là một loại củ thường được các chị em nội trợ chọn vào menu hàng tuần. Bên trong loại rau củ này và cả lá của nó có chứa nhiều vitamin và khoáng chất giúp cải thiện sức khoẻ cho cơ thể. Củ dền có thể dùng chế biến thành các món ăn như canh hay có thể dùng để làm nước ép cũng rất ngon..&nbsp;
Củ dền hay còn gọi là củ dền đỏ, là một loại củ quen thuộc trong món ăn của nhiều gia đình. Củ dền có lớp vỏ bên ngoài xù xì, bên trong có màu đỏ thẫm hoặc tím than, lớp thịt cứng giòn. Đây là loại rau củ chứa nhiều vitamin (A, B2, C,...) cùng với hàm lượng chất xơ, chất sắt cao và các khoáng chất có lợi.
Vì thế, củ dền có rất nhiều công dụng đối với sức khỏe con người khi chế biến thành nhiều món ăn như điều hòa huyết áp, cải thiện đường tiêu hóa, hỗ trợ thải độc,....&nbsp;
Các món có thể chế biến từ Củ Dền:.&nbsp;
- Củ dền sau khi sơ chế được nấu kết hợp với nhiều nguyên liệu khác nhau như thịt heo, rau củ quả các loại..&nbsp;
- Canh củ dền với sườn heo hoặc thịt heo bằm thơm ngon, bổ dưỡng.&nbsp;
- Nước ép củ dền giúp bổ máu, ổn định huyết áp..&nbsp;
- Súp củ dền cho trẻ.&nbsp;',500,'cuden.jpg','09-25-2021',30,0),
(17,3,N'Đậu bắp',13800,N'Chứa nhiều chất xơ, giàu dinh dưỡng, nhiều vitamin,…Đậu bắp của Bách Hóa Xanh luôn rất được ưa chuộng để chế biến những món ăn hàng ngày. Những thành phần dưỡng chất trong đậu bắp rất hữu ích cho hệ tiêu hóa, tim mạch, chống ung thư, tốt cho da và mắt,...&nbsp;
Đậu bắp với tên gọi khác mướp tây hay bắp còi, là một trong loại thực phẩm quen thuộc được sử dụng trong các bữa ăn hằng ngày. Nó chứa nhiều chất xơ, giàu dinh dưỡng, nhiều vitamin,…đều là những thành phần dưỡng chất hữu ích cho hệ tiêu hóa, tim mạch, chống ung thư, tốt cho da và mắt,...
Ngoài việc trở thành món ăn trong các bữa ăn hằng ngày thì đậu bắp còn được chế biến thành nước để uống. Nước đậu bắp rất tốt cho các bà bầu, hạn chế khả năng dị tật của thai nhi tốt.&nbsp;
Các món có thể chế biến từ Đậu Bắp:.&nbsp;
Ngoài món luộc thì đậu bắp còn được chế biến nhiều món ngon đa dạng như:.&nbsp; 
- Giải nhiệt mát người với canh chua đậu bắp.&nbsp;
- Đậu bắp muối chua.&nbsp;
- Ngon bổ dưỡng với đậu bắp xào thịt bò.&nbsp;
- Đậu bắp xào bún khô đơn giản, thanh tịnh.&nbsp;',300,'daubap.jpg','09-25-2021',30,0),
(18,3,N'Dưa leo',17400,N'Dưa leo baby là một giống dưa mới, được trồng khá nhiều ở nước ta, đây là một loại rau củ rất ngon, gần như là quen thuộc trong tất cả bữa ăn ở mọi gia đình. Dưa leo chứa rất nhiều chất dinh dưỡng và vitamin rất tốt cho cơ thể. Ngoài ra, dưa leo còn có thể dụng để làm đẹp cũng rất hiệu quả.&nbsp;
Dưa leo (hay còn gọi là dưa chuột) được trồng rộng rãi ở nhiều nước khác nhau, có thể được sử dụng với nhiều mục đích khác nhau nhưng dù ở dạng nào dưa leo vẫn giữ nguyên được những giá trị dinh dưỡng của mình. Dưa leo baby với hình dạng giống hệt trái dưa leo thông thường với vỏ xanh lá cây sọc trắng, nhưng chiều dài lại chỉ từ 3 - 5cm và vị thì ngọt và mát hơn dưa leo thông thường.&nbsp;
Các món có thể chế biến từ Dưa leo:.&nbsp;
- Nước ép dưa leo, nước ép dưa leo cà rốt.&nbsp;
- Dưa leo muối.&nbsp;
- Mực xào dưa leo.&nbsp;
- Gỏi dưa leo.&nbsp;
- Salad bơ dưa chuột.&nbsp;
- Kim chi dưa leo.&nbsp;',500,'dualeo.jpg','09-25-2021',30,0),
(19,3,N'Giá',13000,N'Giá đậu xanh hay còn gọi là giá đỗ, là một trong những nguồn thực phẩm rau quen thuộc trong các món ăn của nhiều gia đình Việt Nam. Giá đậu xanh có tính hàn, vị ngọt rất nhẹ vì thế mang đến cho người dùng cảm giác dễ chịu, giúp thanh lọc và làm mát cơ thể.&nbsp; 
Các món có thể chế biến từ giá:.&nbsp;
- Canh kim chi giá đỗ cay nồng chuẩn vị Hàn Quốc.&nbsp;
- Dưa giá giòn giòn, chua ngọt.&nbsp; 
- Giá đỗ xào với thịt heo, thịt bò.&nbsp;',300,'gia.jpg','09-25-2021',30,0),
(20,3,N'Gừng',4800,N'Gừng là một loại củ có rất nhiều công dụng đối với chúng ta. Ngoài là gia vị trong nấu ăn hàng ngày, chúng còn có thể dùng trong làm đẹp, làm thuốc cũng cực tốt. Có thể kể đến một số lợi ích của gừng như: làm ấm cơ thể, trừ hàn, tiêu đàm, dịu ho, cầm máu,...&nbsp;
Gừng là một loài thực vật hay được dùng làm gia vị, thuốc. Trong củ gừng có các hoạt chất: Tinh dầu zingiberen, chất nhựa, chất cay, tinh bột. Chính tinh dầu này làm món ăn thơm ngon hơn, khử đi mùi tanh của thịt cá. Không những vậy, gừng có vị cay, tính ôn, kích thích vị giác, tạo cảm giác thèm ăn,
khiến bữa ăn thêm ngon miệng. Bên cạnh đó những lợi ích từ gừng như: làm ấm cơ thể, trừ hàn, tiêu đàm, dịu ho, cầm máu, giúp giảm các cơn đau cơ, viêm khớp, thấp khớp, đau đầu hay đau nửa đầu.&nbsp;
Các món có thể chế biến từ Gừng:.&nbsp;
- Ấm nồng ngày mưa với gà kho gừng.&nbsp;
- Canh cải bẹ xanh nấu gừng ấm bụng, giải cảm.&nbsp;
- Ngon lạ miệng với đuôi bò hấp gừng.&nbsp;
- Mực nhồi thịt hấp gừng.&nbsp;
- Ngoài ra, gừng có thể dùng để pha trà nóng, mật ong hoặc làm nước mắm chấm,...&nbsp;',50,'gung.jpg','09-25-2021',30,0),
(21,3,N'Me',5000,N'Được đóng gói thành từng hộp gọn gàng và ngăn nắp, có công dụng làm gia vị trong các món ăn như canh chua. Ngoài ra, các dưỡng chất trong me cũng mang đến rất nhiều dưỡng chất cực tốt cho cơ thể như: giảm mỡ, ngừa thiếu máu, cao huyết áp,...&nbsp;
Me chua vắt là thực phẩm được dùng rất phổ biến trong việc chế biến các món ăn, là rau gia vị dùng để chế biến nên nhiều món ăn ngon, hấp dẫn mà nó còn rất tốt cho sức khỏe. Nó có công dụng giảm mỡ, ngừa thiếu máu, cao huyết áp,... Sản phẩm được làm sạch, đóng hộp dễ chế biến, bảo quản được lâu, giúp người nội trợ tiết kiệm được nhiều thời gian.&nbsp;
Các món chế biến từ quả Me:.&nbsp;
- Cá thu sốt me. Cá thu sốt me là món ăn hòa quyện giữa vị ngọt thơm của thịt cá với vị chua dịu của me.&nbsp;
- Canh thịt nạc nấu me.&nbsp;
- Canh chua cá lóc.&nbsp;
- Ốc hương xào me.&nbsp;
- Thịt ba chỉ cuộn rau củ sốt me.&nbsp;
- Trứng cút lộn xào me.&nbsp;
- Càng ghẹ xào me.&nbsp;
- Canh sườn nấu me chua.&nbsp;',100,'mechua.jpg','09-25-2021',30,0),
(22,3,N'Hành lá',9000,N'Hành lá hay gọi là hành hoa, hành hương, hành ta, là loại rau nêm có mùi thơm đặc trưng, được dùng chủ yếu như một loại gia vị ăn kèm của các món ăn. Ngoài ra, hành lá cũng xuất hiện trong một số bài thuốc đông y nhằm phòng hoặc chữa một vài căn bệnh nào như:
giải quyết dứt điểm triệu chứng cảm sốt, nhức đầu, ăn uống không tiêu, ngăn ngừa tiểu đường, tốt cho mắt, nâng cao hoạt động hệ tim mạch,....&nbsp;
Các món có thể chế biến từ Hành lá:.&nbsp;
- Chân gà hấp hành.&nbsp;
- Trứng chiên thịt bằm hành lá.&nbsp;
- Bánh hành giòn tan.&nbsp;
- Làm gia vị cho các món canh: canh bí đỏ, bắp cải...&nbsp;',200,'hanhla.jpg','09-25-2021',30,0),
(23,3,N'Hành tây',17000,N'Hành tây là một loại củ phổ biển được sử dụng trong rất nhiều món ăn của người Việt và trên toàn thế giới. Loại rau củ này chứa khá nhiều vitamin và khoáng chất có công dụng cho sức khỏe. Hành tây có thể dùng để chiên, xào, nướng hoặc có thể ăn sống đểu rất ngon.&nbsp;
Hành tây là loại củ mọc dưới lòng đất, được trồng phổ biến trên toàn thế giới và có quan hệ gần với hẹ, tỏi và hành lá. Đây là nguyên liệu chủ yếu trong nhiều món ăn, được chế biến rất đa dạng, từ nướng, luộc, chiên, rang, xào, lăn bột hoặc thậm chí là ăn sống. Hành tây chứa khá nhiều vitamin và khoáng chất có công dụng cho sức khỏe như: 
giúp điều hòa đường huyết, cải thiện sức khỏe xương, ngăn ngừa ung thư, tăng cường hệ miễn dịch,...&nbsp;
Các món có thể chế biến từ Hành tây:.&nbsp;
- Gà xào hành tây lạ miệng, đưa cơm.&nbsp;
- Giòn thơm với mực xào hành tây.&nbsp;
- Bò xào hành tây thơm mềm, thơm ngon.&nbsp;
- Súp hành tây kiểu Pháp.&nbsp;',500,'hanhtay.jpg','09-25-2021',30,0),
(24,3,N'Khoai lang',29000,N'Là món ăn được rất nhiều người yêu thích, được trồng và có củ quanh năm, ngon nhất là khi được nướng lên trên một bếp than đổ hồng. Loại củ này có vị ngọt ngào như mật, tan tan trên đầu lưỡi. Khoai lang Nhật chứa nhiều vitamin A, B, C và nhiều khoáng chất cần thiết cho làn da đẹp.&nbsp;
Là một loại củ có hình dáng thon, dài. Với lớp vỏ bên ngoài màu tím, trong ruột thì vàng, hương vị ngọt dịu nhẹ, bùi nên chiếm được rất nhiều cảm tình của mọi người. Trong Đông y củ khoai lang có vị ngọt, tính bình, có công dụng nhuận tràng, bồi bổ cơ thể, tiêu viêm, lợi mật, sáng mắt,.. đặc biệt ăn khoai vào buổi sáng sẽ giúp bạn cung cấp đầy đủ dinh dưỡng cho cơ thể, 
đặc biệt là chữa được nhiều bệnh nguy hiểm mà bạn không ngờ tới.&nbsp;
Các món có thể chế biến từ Khoai lang:.&nbsp;
Khoai lang có thể chế biến thành một số món ăn ngon như: khoai lang luộc, khoai lang nướng, khoai lang kén, khoai lang chiên giòn, thạch rau câu khoai lang, chè khoai lang,...&nbsp;',1,'khoailang.jpg','09-25-2021',30,0),
(25,3,N'Khoai mỡ',47000,N'Là nguyên liệu khá quen thuộc của các chị em khi nấu ăn cho cả gia đình. Với hàm lượng khoáng chất và vitamin có trong khoai mỡ sẽ giúp cải thiện hệ tiêu hoá, giúp nhuận tràng, chữa táo bón rất tốt. Khoai mỡ có thể sử dụng để chế biến thành các món như: canh, bánh khoai mỡ, khoai mỡ chiên giòn,...&nbsp;
Các món có thể chế biến từ Khoai Mỡ:.&nbsp; 
- Canh khoai mỡ thịt bằm.&nbsp;
- Khoai mỡ nấu với tôm khô.&nbsp; 
- Bánh khoai mỡ hấp nước cốt dừa.&nbsp;
- Khoai mỡ chiên giòn để các bé ăn vặt.&nbsp;',1,'khoaimo.jpg','09-25-2021',30,0),
(26,3,N'Khoai môn',25000,N'Khoai môn hay môn ngọt là tên gọi của một số giống khoai thuộc loài Colocasia esculenta Schott, một loài cây thuộc họ Ráy. Cây khoai môn có củ cái và củ con. Củ cái nặng từ 1,5 đến trên 2 kg, ít củ con, chứa nhiều tinh bột.&nbsp;
- Các món có thể chế biến từ Khoai Môn:.&nbsp;
- Khoai môn lệ phố.&nbsp;
- Trà sữa khoai môn.&nbsp;
- Canh khoai môn.&nbsp;
- Bánh khoai môn chiên.&nbsp;
- Bánh khoai môn hấp.&nbsp;
- Chả giò khoai môn.&nbsp;
- Sinh tố khoai môn.&nbsp;',500,'khoaimon.jpg','09-25-2021',30,0),
(27,3,N'Khoai tây',15000,N'Đã quá quen thuộc với mỗi chúng ta. Loại củ này được xuất hiện thường xuyên trên mâm cơm này có rất nhiều công dụng hữu ích.
Nó không chỉ tốt cho sức khỏe, làm đẹp hiệu quả mà còn có rất nhiều tác dụng bổ ích khác. Khoai tây bi có thể chế biến thành canh, súp, hoặc chiên đều rất ngon.&nbsp;
Khoai tây thuộc họ cà, là một loại củ đa năng có hàm lượng chất dinh dưỡng cao, vì vậy nhiều hộ gia đình tại Việt Nam đã lựa chọn khoai tây như một món ăn chính trong các bữa ăn hàng ngày.
Sở hữu nguồn vitamin và khoáng chất phong phú, khoai tây mang lại nhiều lợi ích cho sức khỏe như kháng viêm, giảm đau, tăng cường hệ miễn dịch, kích thích tiêu hóa,...&nbs
Các món có thể chế biến từ Khoai Tây:.&nbsp;
- Súp gà khoai tây nhẹ nhàng với bữa sáng.&nbsp;
- Bổ dưỡng, giảm cân với salad khoai tây.&nbsp;
- Bánh khoai tây nướng phô mai nóng hổi, giòn rụm.&nbsp;
- Lạ vị với khoai tây chiên bơ.&nbsp;',500,'khoaitay.jpg','09-25-2021',30,0),
(28,3,N'Nấm bào ngư',20000,N'Nấm bào ngư là loại nấm có những đặc điểm dễ nhận biết: tai nấm có dạng phễu lệch, phiến nấm mang bào tử kéo dài xuống đến chân, cuống nấm gần gốc có lớp lông nhỏ mịn,
nấm bào ngư trắng còn có những tên gọi khác là nấm sò, nấm hương trắng, nấm dai và tên khoa học là Pleurotus florida. Từ lâu nấm bào ngư trắng đã trở thành sản phẩm quen thuộc trong bữa ăn của mỗi gia đình Việt,
nấm bào ngư trắng có thể dùng để chế biến thành các món chính hoặc dùng để nhúng lẩu hoặc ăn kèm như các loại rau khác.&nbsp;
Các món có thể chế biến từ Nấm Bào Ngư:.&nbsp;
- Nấm bào ngư thấp sả.&nbsp;
- Thịt heo, bò xào nấm bào ngư.&nbsp;
- Nấm bào ngư xào xả ớt.&nbsp;
- Nấm bào ngư nấu canh bí đỏ thịt băm.&nbsp;',300,'nambaongu.jpg','09-25-2021',30,0),
(29,3,N'Nấm đùi gà',27500,N'Nấm đùi gà của Bách hóa Xanh được nuôi trồng và đóng gói theo những tiêu chuẩn nghiêm ngặt, bảo đảm các tiêu chuẩn xanh - sach, chất lượng và an toàn với người dùng. Nấm giòn dai, ngọt thịt, nhiều dinh dưỡng thường được dùng cho các món xào,
chiên giòn hoặc nướng ăn kèm với các loại xốt chấm.&nbsp;
Nấm đùi gà còn được biết đến với tên gọi khác là nấm bào ngư Nhật. Đây là loại nấm thuộc họ bào ngư, chứa hàm lượng dinh dưỡng lớn, rất tốt cho sức khỏe con người. Chứa nhiều loại vitamin thiết yếu cho cơ thể như: vitamin B1, B6, E,... các dưỡng chất này giúp cải thiện sức khỏe, nâng cao sức đề kháng cho người dùng,
đặc biệt chống ung thư rất hiệu quả, giảm bệnh tiểu đường và tốt cho tiêu hóa.&nbsp;
Các món có thể chế biến từ Nấm Đùi Gà:.&nbsp;
- Nấm đùi gà sốt sa tế, kho nước tương.&nbsp;
- Nấm luộc chấm mắm.&nbsp;
- Lẩu nấm kết hợp các loại nấm cực ngon.&nbsp;',200,'namduiga.jpg','09-25-2021',30,0),
(30,3,N'Nấm hải sản',25000,N'Nấm hải sản của Bách hóa Xanh được nuôi trồng và đóng gói theo những tiêu chuẩn nghiêm ngặt, bảo đảm các tiêu chuẩn xanh - sach, chất lượng và an toàn với người dùng. Nấm trắng ngần, ngọt, chứa nhiều chất, hàm lượng dinh dưỡng cao nên thường dùng để nấu cháo hoặc làm rau nhúng lẩu.&nbsp;
Nấm hải sản còn có tên gọi khác nấm bạch tuyết. Đây được xem là một loại thực phẩm rất tốt cho sức khỏe bởi nó chứa rất nhiều vitamin và protein. Thực phẩm này còn có rất nhiều tác dụng trong việc ngăn ngừa ung thư, thông gan, tốt cho dạ dày, tăng cường trí lực, giảm quá trình lão hóa, tăng cường hệ miễn dịch của cho mẹ bầu.&nbsp;
Các món có thể chế biến từ Nấm Hải Sản:.&nbsp;
- Gói nấm mua về cắt bỏ gốc.&nbsp;
- Rửa sạch với nước.&nbsp;
- Cắt khúc to, nhỏ tùy theo món ăn bạn chế biến.&nbsp;',150,'namhaisan.jpg','09-25-2021',30,0),
(31,3,N'Nấm kim châm',16000,N'Nấm là loại thực phẩm tuy có hàm lượng vitamin và khoáng chất chỉ ngang bằng các loại rau xanh nhưng nó lại chứa nhiều loại chất dinh dưỡng cần thiết cho cơ thể trong đó có vitamin D là dưỡng chất mà khó tìm thấy trong rau hoặc một số loại thực phẩm khác. Nấm kim châm cũng là một trong số những nguồn vitamin,
khoáng chất họ nấm, theo nghiên cứu chỉ với 65g nấm kim châm cung cấp chất dinh dưỡng cần thiết cho cơ thể.&nbsp;
Các món có thể chế biến từ Nấm kim châm:.&nbsp;
- Canh nấm kim châm nấu thịt bằm.&nbsp;
- Canh thịt bò nấm kim châm.&nbsp;
- Ba chỉ bò cuộn nấm kim châm.&nbsp;
- Cải bó xôi sốt nấm kim châm.&nbsp;
Hay mua thêm một số loại nấm khác như nấm bào ngư, nấm hải sản, nấm hương,... để có thể tự chế biến món lẩu nấm thơm ngon.&nbsp;',150,'namkimcham.jpg','09-25-2021',30,0),
(32,3,N'Ngò nhí',6300,N'Là một loại rau thường được ăn sống, chấm nước kho hoặc dùng để làm gia vị cho các món ăn. Không những là một loại rau ngon, mà ngò rí còn chứa nhiều vitamin A, C có lợi cho hệ miễn dịch của cơ thể. Ngoài ra, nước ép ngò rí còn có tác dụng cực tốt có thể làm hạ sốt, trị cảm cúm hiệu quả.&nbsp;
Ngò rí hay còn gọi là ngò, rau mùi, ngò suôn, mùi ta,... có mùi thơm, thường được trồng làm rau nêm và gia vị. Kết hợp ăn rau khác nhau tương ứng với từng món ăn khác nhau làm gia tăng hương vị cho món ăn. Hoặc được sử dụng như một phương pháp điều trị bệnh: Rau mùi có chứa nhiều vitamin A, C có lợi cho hệ miễn dịch của cơ thể, uống nước rau mùi có thể làm hạ sốt, trị cảm cúm, bảo vệ tim mạch, lọc máu,...&nbsp;
Các món có thể chế biến từ Ngò Nhí:.&nbsp;
Rau thường được dùng cho hai mục đích chính:.&nbsp;
- Ăn sống, húng có tinh dầu cay nên hay được phối trộn với các loại rau mát khác như giá đỗ, bắp chuối thái mỏng, xà lách, rau má.&nbsp;
- Gia vị cho các món ăn: nhiều loại rau thơm được gia vào các món ăn như một thứ gia vị, tùy theo nguyên liệu chính để chế biến món ăn mà người nội trợ thường có kinh nghiệm riêng cho các loại rau thơm khác nhau như: bún đậu mắm tôm, bún bò Huế, bún riêu cua, bún chả, lòng lợn, phở cuốn,...&nbsp;',50,'ngonhi.jpg','09-25-2021',30,0),
(33,3,N'Ớt hiểm',7500,N'Với vị cay nồng, thơm, kích thích vị giác của người ăn, ớt là một trong những gia vị không thể thiếu trong nấu ăn cũng như mâm cơm của người Việt. Ớt hiểm của Bách Hóa Xanh luôn giữ được độ tươi mỗi ngày, được nuôi trồng theo quy trình nghiêm ngặt, bảo đảm các chỉ tiêu về an toàn và chất lượng.&nbsp;
Ớt mang một vị cay đặc trưng, cùng với hành, tỏi, và các loại rau nêm khác trở thành nguyên liệu không thể thiếu trong mỗi món ăn, giúp các món ăn cay nồng, dậy mùi thêm phần hấp dẫn. Người ta có thể dùng ớt ở bất kể món ăn nào nếu muốn có thêm vị cay cay the the, có người còn ăn ớt sống, mỗi bữa cơm hai trái như thói quen để kích thích vị giác, giúp ăn ngon miệng hơn. Ớt có nhiều loại, 
nhưng phải nói là cay nhất thì chỉ có ớt hiểm, chính là loại quả ớt thường mọc quả có 3 màu trắng, đỏ, vàng trên cùng một cây.&nbsp;
Các món có thể chế biến từ Ớt:.&nbsp;
- Bánh mì nướng muối ớt.&nbsp;
- Tôm nướng muối ớt.&nbsp;
- Gà kho xả ớt.&nbsp;
- Bò xào xả ớt.&nbsp;
- Canh khổ qua cà ớt.&nbsp;
- Lẩu gà ớt hiểm.&nbsp;',50,'ot.jpg','09-25-2021',30,0),
(34,3,N'Rau dền',11500,N'Rau dền tươi xanh đảm bảo chất lượng an toàn thực phẩm. Đặt hàng giao ngay trong ngày tại Green Food.&nbsp;
Rau dền là một loại rau xanh có 3 loại phổ biến: Rau đền đỏ, rau dền gai, rau dền cơm. Được các bà nội trợ bổ sung trong thực đơn mỗi ngày. Ngoài vị ngọt mát và thành phần dinh dưỡng cao, rau dền xanh còn được xem là một vị thuốc dân gian chữa được nhiều bệnh với lợi ích như:
Chống táo bón, điều trị tăng huyết áp, tốt cho bệnh nhân tiểu đường, ngừa ung thư...&nbsp;
Các món có thể chế biến từ Rau dền:.&nbsp;
- Thanh mát, dễ làm với canh rau dền thịt băm, canh tôm rau dền.&nbsp;
- Cháo tôm rau dền rong biển cho bé.&nbsp;
- Mì somen rau dền thịt heo.&nbsp;
- Nấm xào lòng heo rau dền.&nbsp;',500,'rauden.jpg','09-25-2021',30,0),
(35,3,N'Rau muống',5500,N'Rau muống nước baby là một loại rau muống có phần lá với kích thước nhỏ nhưng công dụng không thua kém gì so với rau muống thông thường. Đặc biệt, đây là loại rau có chứa hàm lượng nước cao (92%) cùng với một số các khoáng chất có lợi khác (canxi, photpho, sắt,...) 
cùng các nhóm vitamin B, C,... Vì thế, rau muống có nhiều công dụng như cung cấp nguồn nước cho cơ thể, giúp giải nhiệt, ổn định huyết áp, ngăn ngừa ung thư, điều hòa tim mạch,...&nbsp; 
Các món có thể chế biến từ Rau Muống:.&nbsp;
- Rau muống không chỉ là loại rau ăn kèm với các món phở bò, bún bò,... mà còn thích hợp để chế biến thành nhiều món ăn khác nhau từ luộc đến hấp, chiên, xào khi kết hợp với các loại thịt, hải sản, cá,...&nbsp; 
Một số món ăn ngon từ rau muống mà bạn nên thử như rau muống xào tỏi chao lạ miệng, rau muống xào với ốc móng tay, canh ghẹ rau muống ngọt thanh,...&nbsp;',300,'raumuong.jpg','09-25-2021',30,0),
(36,3,N'Su hào',9000,N'Su hào là một loại củ rất quen thuộc, được nhiều bà nội trợ chọn để chế biến thành các món ăn ngon cho gia đình. Xu hào rất giàu Vitamin, chất xơ, giúp chống oxy hóa mạnh, răng và nướu khỏe mạnh. Xu hào có thể chế biến thành các món ăn ngon như: xào, nấu canh, muối chua,...&nbsp; 
Su hào là loại củ được sử dụng nhiều trong chế biến món ăn vì nó có vị ngọt nhẹ, giòn và rất giàu Vitamin, chất xơ. Trong su hào rất giàu Vitamin C. Loại Vitamin này có tính chống oxy hóa mạnh, giúp cơ thể duy trì các mô liên kết, răng và nướu khỏe mạnh, giúp bảo vệ cơ thể con người hạn chế ung thư và đẩy các gốc tự do có hại ra khỏi cơ thể…Su hào còn chứa một lượng dồi dào nhóm Vitamin B phức hợp, 
là các yếu tố kết hợp với enzym trong quá trình trao đổi chất khác nhau trong cơ thể.&nbsp;
- Các món có thể chế biến từ Su Hào:.&nbsp;
- Ăn hết nồi cơm cùng thịt kho su hào.&nbsp;
- Su hào, cà rốt muối đơn giản ngon miệng.&nbsp;
- Nộm su hào, cà rốt giòn giòn.&nbsp;
- Su hào xào thịt bò đậm đà.&nbsp;',300,'suhao.jpg','09-25-2021',30,0),
(37,3,N'Su su',11000,N'Su su hay su le trong phương ngữ miền Trung Việt Nam là một loại cây lấy quả ăn, thuộc họ Bầu bí, cùng với dưa hấu, dưa chuột và bí. Cây này có lá rộng, thân cây dây leo trên mặt đất hoặc trên giàn. 
Ở Việt Nam, su su được trồng để vừa lấy quả và vừa lấy ngọn trong chế biến các món ăn.&nbsp;
Các món có thể chế biến từ Su Su:.&nbsp;
- Su su xào nấm tuyết (mộc nhĩ trắng) Su su•Nấm mèo (mộc nhĩ)•Nấm tuyết (mộc nhĩ trắng, tuyết nhĩ)•Cà rốt.&nbsp;
- Su Su Xào Thịt Bò.&nbsp;
- Đọt su su xào giá.&nbsp;
- Su Su Xào Trứng Muối.&nbsp;
- Su Su xào trứng.&nbsp;
- Canh su su, cà rốt, khoai lang tím nấu thịt băm.&nbsp;
- Su su xào thịt heo.&nbsp;
- Su su xào trứng.&nbsp;',500,'susu.jpg','09-25-2021',30,0),
(38,2,N'Tắc',10000,N'Tắc trái của Green Food luôn giữ được độ tươi mỗi ngày, được nuôi trồng theo quy trình công nghệ nghiêm ngặt, bảo đảm các chỉ tiêu về an toàn và chất lượng. Hương tắc thơm, vị chua dịu,
không quá gắt kích thích vị giác của người dùng thường được dùng ăn kèm với các món bún, pha nước tắc.&nbsp;
Tắc là loại quả có vị chua và mùi thơm kích thích. Tắc không chỉ được làm thức uống giải nhiệt và nguyên liệu chế biến món ăn, nước chấm mà công dụng của trái tắc còn chữa bệnh cực hay.&nbsp; 
Trái tắc chứa nhiều vitamin A, C, B1,…cùng các khoáng chất như canxi, photpho, sắt,… Không chỉ có hương vị thơm ngon, quả tắc còn chứa nhiều dưỡng chất, đặc biệt là vitamin C – chất chống oxy hóa. Hơn nữa, quả tắc chứa rất ít natri và hầu như không có chất béo cũng như cholesterol.&nbsp;',500,'tac.jpg','09-25-2021',30,0),
(39,3,N'Rau tần ô',7500,N'Rau tần ô hay còn gọi là rau cải cúc, là một loại rau có tính hàn mát, vị ngọt nhẹ, rất phù hợp cho việc chế biến thành các món canh rau cho gia đình. Ngoài ra, rau tần ô cũng mang đến nhiều lợi ích cho sức khỏe con người như trị ho, trị đau đầu, lợi tiểu, chữa tiêu chảy,...&nbsp;
Các món có thể chế biến từ Rau Tần Ô:.&nbsp;
- Rau tần ô khi được nấu cùng với các loại thịt heo, tôm,.. sẽ cho ra những món canh thơm ngon, ngọt thanh và bổ dưỡng như canh rau tần ô nấu với thịt bằm, canh rau tần ô thịt bò,...&nbsp;
- Rau tần ô cũng được dùng để chế biến thành các món xào như rau tần ô xào tỏi, xào thịt bò,...&nbsp;',300,'tano.jpg','09-25-2021',30,0),
(40,3,N'Xà lách lô lô',13400,N'Được trồng theo hình thức thủy canh, Xà lách lô lô thủy canh trông rất tươi mát, có vị ngon ngọt, lá không quá giòn và cũng không quá mềm. Đặc biệt, bởi vì được nuôi trồng bởi quy trình nghiêm ngặt nên đảm bảo về chất lượng và an toàn đến tay người tiêu dùng.&nbsp;
Xà lách từ lâu đã thành loại rau xanh ăn kèm không thể thiếu đối với nhiều món ăn, nhất là những món chiên, nướng. Ngoài ra với hàm lượng chất dinh dưỡng cao cũng như các ưu điểm nổi bật trong việc hỗ trợ cải thiện vóc dáng, sắc đẹp, xà lách luôn là loại rau chắc chắn phải có trong nhiều loại salad trộn hay cũng như nước ép.
Trên thị trường hiện nay có rất nhiều loại xà lách, đặc điểm nhận dạng của lá xà lách thường là phiến lá to và có màu xanh,  nhưng mỗi loại xà lách lại có một điểm riêng biệt như xà lách búp mỡ là loại xà lách có lá lớn và được sắp xếp hơi rời rạc, dễ dàng tách ra từ thân của nó, xà lách lô lô cũng có lá sắp xếp rời rạc nhưng tầng lá rộng và xoăn.
Màu xanh của lá trông rất tươi mát, có vị ngon ngọt, lá không quá giòn và cũng không quá mềm.&nbsp;',300,'xalachlolo.jpg','09-25-2021',30,0),
(41,3,N'Xà lách búp',15500,N'Xà lách búp mỡ thủy canh của Bách Hóa Xanh có lá cây rất mềm, có vị ngọt thanh, rất thơm ngon khi ăn sống. Chứa nhiều chất xơ có lợi cho tiêu hóa, giàu giá trị dinh dưỡng, chứa nhiều vitamin và khoáng chất, có công dụng bồi bổ sức khỏe, chống oxy hóa, ngăn ngừa ung thư.&nbsp;
Các món có thể chế biến từ Xà lách búp:.&nbsp;
Xà lách mỡ có thể dùng để chế biến nhiều món ăn ngon như luộc, canh, xào, salad.&nbsp;
- Làm rau sống, dùng để cuốn và ăn kèm với cá, thịt.&nbsp;
- Xà lách trộn dầu giấm, trứng.&nbsp;
- Xà lách trộn thịt bò.&nbsp;
- Xà lách chấm nước sốt cà.&nbsp;
- Ăn kèm chung với các món nhúng giấm.',300,'xalach.jpg','09-25-2021',30,0),
(42,2,N'Cam Valencia',75000,N'Cam vàng Valencia trái tròn căng bóng, mọng nước và cực kỳ thơm ngon, đây là loại trái cây nhập khẩu từ Úc an toàn vệ sinh. Thích hợp để vắt uống bởi chứa nhiều vitamin C và vị chua dịu hợp khẩu vị.&nbsp;
Các món có thể chế biến từ Cam Valencia:&nbsp;
- Cam Vắt.&nbsp;
- Bổ cam ra thành từng múi.&nbsp;
- Nước ép cam.&nbsp;',1,'cam.jpg','09-25-2021',30,0),
(48,2,N'Táo mỹ',80000,N'Là loại trái cây nhập khẩu xuất xứ từ Mỹ, nhiều giá trị dinh dưỡng. Loại táo này có kích thước vừa tay cầm, vỏ mỏng màu đỏ thẫm, phần thịt màu trắng, giòn cứng, vị ngọt mát xen kẽ một chút vị chua, rất dễ ăn. Có thể chế biến thành nhiều món ăn hoặc thức uống khác nhau, mang đến lợi ích sức khoẻ con người...&nbsp;',1,'tao.jpg','09-25-2021',30,0),
(43,2,N'Chanh dây',18000,N'Chanh dây là loại trái cây có vị chua nhưng hậu ngọt, thường dùng làm bánh hay nước giải khát thanh nhiệt trong mùa hè nóng bức, là thức uống được nhiều người yêu thích. Ngoài là nước giải khát thì chanh dây còn có nhiều lợi ích cho sức khỏe. Loại trái này còn giàu các chất hữu cơ như caroten và polyphenol.
Trên thực tế, khoa học đã chứng minh rằng trong các loại trái cây nhiệt đới như chuối, xoài, đu đủ, dứa, vải thiều thì chanh dây chứa hàm lượng polyphenol cao nhất. Ngoài ra còn chứa một lượng nhỏ chất sắt. Thông thường cơ thể chúng ta khó có thể hấp thụ chất sắt từ thực vật, tuy nhiên nhờ hàm lượng vitamin C cao trong trái chanh dây mà cơ thể dễ dàng hấp thụ chất sắt hơn.&nbsp;
- Các món có thể chế biến từ Chanh dây;.&nbsp;
- Sinh tố chanh dây ngon ngất ngây.&nbsp;
- Pha nước chanh dây mát lạnh.&nbsp;
- Canh chua chanh dây lạ miệng.&nbsp;
- Cuối tuần healthy với salad thanh long chanh dây.&nbsp;
- Cá dứa chiên giòn sốt chanh dây đơn giản.&nbsp;',1,'chanhday.jpeg','09-25-2021',30,0),
(44,2,N'Dâu tây New Zealand',82000,N'Là dâu tây được nhập khẩu từ New Zealand có vị chua, ngọt có thể ăn trực tiếp hoặc làm sinh tố, nước ép, kem,... Sản phẩm tươi ngon - an toàn thực phẩm người tiêu dùng, chứa nhiều vitamin A giúp tăng sức đề kháng cho cơ thể và ngăn ngừa nhiều bệnh.&nbsp;
Dâu tây New Zealand có vị chua, ngọt có thể ăn trực tiếp hoặc làm sinh tố, nước ép, kem,… Loại trái cây nhập khẩu này chứa nhiều vitamin A, B1, B2, đặc biệt là vitamin C rất cao, hơn cả cam và dưa hấu, giúp tăng sức đề kháng cho cơ thể và ngăn ngừa nhiều bệnh. Chúng được ví như những viên đá quý màu đỏ này rất tốt cho trái tim của bạn theo những cách khác nhau.&nbsp; 
Các món có thể chế biến từ Dâu tây:.&nbsp;
- Mứt dâu tây.&nbsp;
- Sinh tố dâu tây.&nbsp;
- Trà dâu.&nbsp;
- Trà sữa dâu.&nbsp;
- Kem dâu tây.&nbsp;
- Nước ép dâu tây.&nbsp;
- Cháo yến mạch dâu tây.&nbsp;
- Bánh kem dâu tây.&nbsp;',250,'dautay.jpg','09-25-2021',30,0),
(45,2,N'Lê Nam Phi',72000,N'Lê nhập khẩu 100% từ Nam Phi (giấy chứng nhận nguồn gốc xuất xứ). Đạt tiêu chuẩn xuất khẩu toàn cầu. Bảo quản tươi ngon đến tận tay khách hàng. Quả hình chuông, tròn và thon đều. Vỏ màu xanh xen lẫn vàng và đỏ rực rỡ. Trái chín: chắc thịt, mọng nước, ngọt dịu, thơm mát.&nbsp;
Lê Nam Phi giòn, ngọt, mọng nước, là loại trái cây nhập khẩu rất được yêu thích, lê Nam Phi bổ sung nhiều chất xơ, vitamin và khoáng chất cho cơ thể khoẻ và da đẹp, dáng chuẩn hơn.&nbsp;',1,'le.jpeg','09-25-2021',30,0),
(46,2,N'Ổi nữ hoàng',20000,N'Giống ổi này có vị ngọt man mát, hơi xốp, giòn, thơm nhè nhẹ, đặc biệt rất ít hạt cho cảm giăc ăn vô cùng thích thú. Trong ổi chứa nhiều vitamin giúp tăng cường miễn dịch, đẹp da, giảm cân,...Cam kết bán đúng khối lượng, chất lượng và an toàn, bao bì kín đáo sạch sẽ vệ sinh.&nbsp;
Các món có thể chế biến từ Ổi:.&nbsp;
- Bổ để ăn.&nbsp;
- Nước ép ổi.&nbsp; 
- Sinh tố ổi.&nbsp;',500,'oi.jpeg','09-25-2021',30,0),
(47,2,N'Xoài',20500,N'Loại trái cây phổ biến được ưa chuộng giàu chất xơ, vitamin, khoáng chất thiết yếu giúp cung cấp chất dinh dưỡng cho cơ thể con người và mang lại nhiều lợi ích tuyệt vời cho hệ tiêu hóa, tim mạch, giúp mắt sáng, làm đẹp da. Xoài đeo có vị ngọt thanh nhẹ nhàng, giòn xốp được nhiều người ưa thích.&nbsp;
Xoài đeo hạt lép là một loại trái cây gây sốt ở mọi nơi vì mùi vị ngọt thanh nhẹ nhàng, giòn xốp nhưng giá lại rất rẻ. Loại xoài này có dáng thon thắt eo ở gần đuôi, phần thân khá tròn, đầy nhưng vẫn có đường cong.&nbsp;
Khi còn sống sẽ có vỏ màu xanh nhạt, khi già sẽ chuyển dần sang xanh đậm. Khi chín xoài sẽ ngả sang màu vàng dần từ cuống xuống đuôi quả. Khi ăn quả còn xanh, bạn sẽ cảm nhận vị ngọt đậm nhưng không gắt cổ, giòn xốp, thanh mát và khi quả chín hẳn thì thịt sẽ mềm, ngọt đậm, hương thơm nồng nàn, lan toả.&nbsp;',1,'soai.jpg','09-25-2021',30,0),
(49,1,N'Thịt heo ba rọi',96000,N'Ba rọi heo của thương hiệu CP đạt các tiêu chuẩn về an toàn toàn thực phẩm, đảm bảo chất lượng, độ tươi ngon. Thịt heo mềm, vân nạc, mỡ rõ ràng nên rất phù hợp làm nguyên liệu để nấu thịt kho hột vịt, thịt nướng BBQ. Có thể dùng điện thoại quét mã QR trên tem sản phẩm để kiểm tra nguồn gốc.&nbsp;
Các món có thể chế biến từ Thịt ba rọi:.&nbsp;
- Thịt luộc, cà pháo.&nbsp;
- Nướng.&nbsp;',500,'baroi.jpeg','09-25-2021',30,0),
(50,1,N'Chân giò',65000,N'Chân giò heo trước CP đạt các tiêu chuẩn về an toàn toàn thực phẩm. Giò heo săn chắc, thịt có sự kết hợp với gân mỡ nên ăn béo ngậy và thơm, thích hợp để hầm canh, nấu các món nước như hủ tiếu, bánh canh,... Có thể dùng điện thoại quét mã QR trên tem sản phẩm để kiểm tra nguồn gốc.&nbsp;
Chân giò heo trước CP được sản xuất từ hệ thống được kiểm soát chặt chẽ theo nguyên tắc chuỗi khép kín “Thức ăn chăn nuôi - Trang trại chăn nuôi – Nhà máy chế biến thực phẩm”.&nbsp;
Các món được chế biến từ Chân giò:.&nbsp;
- Chân giò tàu xì Móng giò heo, ngũ vị hương, hành tím, tỏi, gừng, ớt tươi, ớt bột, hạt tiêu, quế hồi.&nbsp;
- Chân giò giả cầy.&nbsp;
- Chân giò hầm coca.&nbsp;
- Chân giò nấu giả cầy.&nbsp;
- Chân giò heo hầm củ cải muối.&nbsp;
- Chân giò heo hầm rau củ (cà rốt, khoai tây, bắp cải).&nbsp;
- Canh rau củ hầm chân giò.&nbsp;
- Chân giò nướng mộc.&nbsp;',500,'changio.jpg','09-25-2021',30,0),
(51,1,N'Móng giò',74000,N'Móng giò heo của thương hiệu CP được đóng gói và bảo quản theo những tiêu chuẩn nghiêm ngặt về vệ sinh và an toàn thực phẩm, đảm bảo về chất lượng, độ tươi và ngon của thực phẩm, xuất xứ rõ ràng.Lớp da giòn, béo kết hợp với gân mềm nên thường được sử dụng để hầm các loại canh bổ dưỡng.&nbsp;
Các món được chế biến từ Móng giò:.&nbsp;
- Bún móng giò.&nbsp;
- Móng giò hầm táo đỏ.&nbsp;
- Móng giò om hoa hồi.&nbsp;',500,'monggio.jpeg','09-25-2021',30,0),
(53,1,N'Thịt nạc dăm',82000,N'Nạc dăm heo của thương hiệu Greenfeed được đóng gói và bảo quản theo những tiêu chuẩn nghiêm ngặt về vệ sinh và an toàn thực phẩm, đảm bảo về chất lượng, độ tươi và ngon của thực phẩm, xuất xứ rõ ràng. Thịt nạc dăm sạch sẽ, mềm, có độ đàn hồi nên rất phù hợp với món thịt luộc với bánh tráng.&nbsp;
Các món được chế biến từ Thịt nạc dăm:.&nbsp;
- Thịt nạc dăm chiên giòn Hàn Quốc.&nbsp;
- Thịt nạc dăm nướng (sườn nướng cơm tấm).&nbsp;
- Thịt nạc dăm kho.&nbsp;
- Thịt nạc dăm xào dứa.&nbsp;
- Bún thịt xào.&nbsp;
- Thịt heo cuộn phô mai.&nbsp;
- Đậu hũ và thịt nạc dăm băm.&nbsp;
- Bún chả Hà Nội.&nbsp;',500,'nacdam.jpg','09-25-2021',30,0),
(52,1,N'Thịt sườn cốt',80000,N'Thịt cốt lết thường được cắt kèm với phần đầu xương sườn nên mọi người hay gọi là sườn cốt lết, là nguyên liệu quen thuộc của mọi nhà. Cốt lết heo nhập khẩu đông lạnh với phương pháp cấp đông hiện đại, giúp lưu giữ hương vị tự nhiên, mang đến những món ăn ngon cho gia đình.&nbsp;
Các món được chế biến từ Thịt Sườn Cốt
- Sườn cốt lết rim mặn ngọt. Đứng đầu danh sách các món ngon dễ làm với thịt cốt lết sẽ là món sườn cốt lết rim mặn ngọt.&nbsp;
- Sườn cốt lết rim sữa tươi.&nbsp;
- Sườn cốt lết nướng cơm tấm.&nbsp;
- Sườn cốt lết rim nước dừa.&nbsp;
- Sườn cốt lết nướng mật ong.&nbsp;
- Sườn cốt lết sốt cà chua.&nbsp;
- Sườn cốt lết rim me.&nbsp;
- Sườn cốt lết áp chảo.&nbsp;',500,'suoncot.jpg','09-25-2021',30,0),
(54,1,N'Thịt sườn non',109000,N'Sườn non CP đạt các tiêu chuẩn về an toàn toàn thực phẩm, đảm bảo chất lượng, độ tươi ngon. Sườn được cắt sẵn miếng vừa ăn, có thể chế biến thành nhiều món ngon như sườn kho tiêu, sườn nấu canh, sườn xào chua ngọt,..... Có thể dùng điện thoại quét mã QR trên tem sản phẩm để kiểm tra nguồn gốc.&nbsp;
Các món được chế biến từ Thịt Sườn Non:.&nbsp;
- Sườn rang muối.&nbsp;
- Sườn sốt me.&nbsp;
- Sườn nướng chao.&nbsp;
- Sườn non kho thơm (sườn non kho dứa).&nbsp;
- Sườn non nướng ngũ vị.&nbsp;
- Sườn nướng cà phê.&nbsp;
- Sườn rán giòn.&nbsp;
- Sườn chiên nước mắm.&nbsp;',500,'suonnon.jpeg','09-25-2021',30,0),
(56,1,N'Cánh gà',83000,N'Cánh gà tươi nhập khẩu là một trong những bộ phận ngon nhất của thịt gà, thích hợp dùng cho các món chiên, xào, kho,... và rất nhiều nhiều người yêu thích. Cánh gà không chỉ có phần thịt mềm mà còn có lớp da dai dai, phù hợp với khẩu vị của nhiều người. 
Cánh gà nhập khẩu đông lạnh từ Mỹ với phương pháp làm đông lạnh cấp tốc từ thịt gà tươi trong thời gian nhanh nhất, giúp các dinh dưỡng thất thoát sẽ ít hơn, chất lượng thịt không kém xa thịt gà.&nbsp;
Các món có thể chế biến từ Cánh gà:.&nbsp;
- Cánh gà chiên nước mắm đậm đà.&nbsp;
- Cánh gà chiên giòn rụm.&nbsp;
- Cánh gà chiên bơ ngon như mơ.&nbsp;
- Cánh gà nướng siêu ngon.&nbsp;
- Cánh gà sốt chua cay kiểu Thái.&nbsp;
- Lạ miệng với cánh gà chiên coca.&nbsp;',1,'Cánh gà.jpg','09-25-2021',30,0),
(58,1,N'Đùi gà',52000,N'Đùi tỏi gà CP đạt các tiêu chuẩn về an toàn thực phẩm, đảm bảo về chất lượng, độ tươi và ngon, xuất xứ rõ ràng. Là một một nguyên liệu thích hợp để nấu món gà rán, cơm đùi gà quay tiêu hay gà chiên nước mắm,... Có thể dùng điện thoại quét code QR trên sản phẩm để kiểm tra nguồn góc.&nbsp;
Thịt gà CP được sản xuất từ hệ thống được kiểm soát chặt chẽ theo nguyên tắc chuỗi khép kín “Thức ăn chăn nuôi - Trang trại chăn nuôi – Nhà máy chế biến thực phẩm”.&nbsp; 
Các món được chế biến từ Đùi gà:.&nbsp;
- Đùi gà chiên.&nbsp;
- Đùi gà hấp cam.&nbsp;
- Đùi gà hấp xì dầu.&nbsp;
- Đùi gà nướng bơ tỏi.&nbsp;
- Đùi gà nướng muối ớt.&nbsp;
- Gà rim nước tương cà.&nbsp;
- Đùi gà chiên sốt chua ngọt.&nbsp;
- Đùi gà rim.&nbsp;',500,'duiga.jpeg','09-25-2021',30,0),
(57,1,N'Chân gà',62000,N'Chân gà của thương hiệu CP đạt các tiêu chuẩn về an toàn thực phẩm, đảm bảo về chất lượng, độ tươi và ngon, xuất xứ rõ ràng. Thích hợp để nấu món chân gà ngâm sả tắc, chân gà nướng sa tế, chân gà sốt cay Hàn Quốc,... Có thể dùng điện thoại quét code QR trên sản phẩm để kiểm tra nguồn gốc.&nbsp;
Các món được chế biến từ Chân gà:.&nbsp;
- Chân gà rang muối. Nguyên liệu làm chân gà rang muối (cho 4 người).&nbsp;
- Chân gà ngâm sả tắc.&nbsp;
- Chân gà sốt cay Hàn Quốc.&nbsp;
- Nộm chân gà rút xương.&nbsp;
- Chân gà ngâm giấm sả ớt.&nbsp;
- Chân gà nướng sa tế.&nbsp;
- Chân gà hấp tàu xì.&nbsp;
- Chân gà muối chua.&nbsp;',500,'changa.jpg','09-25-2021',30,0),
(55,1,N'Ức gà',43500,N'Thịt gà là một trong những thực phẩm được tiêu thụ thường xuyên trong đời sống hằng ngày. Trong đó, phần thịt được sử dụng nhiều trong chế độ ăn uống khoa học đó là ức gà. Ức gà phi lê CP là sản phẩm được sản xuất chọn lọc từ những con gà khoẻ mạnh trên dây chuyền nuôi hiện đại, được kiểm soát chặt chẽ theo nguyên tắc chuỗi khép kín “Thức ăn chăn nuôi - Trang trại chăn nuôi – Nhà máy chế biến thực phẩm”.&nbsp;
Các món được chế biến từ Ức gà:.&nbsp;
Salad ức gà.&nbsp;
- Ức gà xào nấm.&nbsp;
- Ức gà nướng.&nbsp;
- Ức gà sốt mật ong.&nbsp;
- Cải thảo cuộn ức gà.&nbsp;
- Ức gà xào bông cải xanh.&nbsp;
- Ức gà áp chảo.&nbsp;
- Ức gà cuộn phô mai.&nbsp;',1,'ucga.jpeg','09-25-2021',30,0),
(59,1,N'Gà nguyên con',68000,N'Là một loại gia súc có rất nhiều dinh dưỡng.&nbsp;
Các món được chế biến từ Gà:.&nbsp;
- Gà hầm thuốc Bắc.&nbsp;
- Gỏi gá lá chanh chua ngọt.&nbsp;
- Gỏi gà bắp cải.&nbsp;
- Gà nướng mật ong.&nbsp;
- Gà kho măng.&nbsp;
- Cánh gà chiên nước mắm.&nbsp;
- Gà chiên xù&nbsp;
- Gà chiên xì dầu.&nbsp;',1,'ganguyencon.jpeg','09-25-2021',30,0),
(62,4,N'Cá nục',83000,N'Là loại cá mang đến nhiều dưỡng chất có lợi và công dụng tuyệt vời cho sức khoẻ. Cá nục đông lạnh vẫn giữ được độ tươi ngon từ cá biển tươi, giúp bảo quản lâu hơn mà thịt cá vẫn chắc, không bở mà vẫn giữ nguyên vị đậm đà cho việc chế biến món ăn.&nbsp;
Các món có thể chế biến từ Cá Nục:.&nbsp;
- Chiên ngập dầu.&nbsp;
- Sốt cà chua.&nbsp;',1,'canuc.jpg','09-25-2021',30,0),
(63,4,N'Cá basa',69000,N'Cá saba với đặc tính ít xương khi chế biến thịt sẽ có vị ngọt thơm và ăn rất ngon, dễ dàng dùng làm nguyên liệu chế biến các món ngon và chứa nhiều chất dinh dưỡng. Cá saba đông lạnh giúp bảo quản lâu hơn mà thịt cá vẫn chắc, không bở mà vẫn giữ nguyên vị đậm đà.&nbsp;
Cá saba (cá sapa) là một loài cá nổi tiếng có nguồn gốc từ Nhật Bản, có màu trắng, nhiều nạc và ít mỡ, thịt cá dày, ít xương khi chế biến thịt sẽ có vị ngọt thơm và ăn rất ngon. Cá saba đông lạnh được lấy từ những con cá tươi, còn sống, thịt săn chắc, làm lạnh nhanh và trữ đông ở -18 độ C,
điều này giúp cho thịt cá vẫn giữ nguyên độ tươi ngay khi rã đông sử dụng. Cá đông lạnh tại Green Food có thể bảo quản trong thời gian dài mà vẫn đảm bảo hương vị cũng như giá trị dinh dưỡng, thích hợp với nhu cầu sử của các bà nội trợ cho nhiều lần sử dụng.&nbsp;
Các món có thể chế biến từ Cá Saba:.&nbsp;
- Cá saba nướng giấy bạc.&nbsp;
- Cá saba kho tộ.&nbsp;
- Cá saba áp chảo.&nbsp;
- Cá saba sốt cà chua.&nbsp;
- Cá saba kho măng.&nbsp;',1,'casaba.jpeg','09-25-2021',30,0),
(64,4,N'Cá trứng',38000,N'Hải sản đông lạnh thương hiệu Đôi Đũa Vàng. Loài cá có kích thước nhỏ, bên trong chứa đầy ắp trứng có hương vị bùi béo và giàu dinh dưỡng. Cá trứng Đôi Đũa Vàng khay 400g từ nguồn nguyên liệu nhập khẩu châu Âu có thể chế biến nhiều món ăn thơm như chiên giòn, nướng muối ớt hay sốt cà chua,...&nbsp;
Các món có thể chế biến từ Cá trứng:.&nbsp;
- Cá trứng chay sốt cà chua. Bã đậu mới •Tàu hũ ki lá, lá rong biển cuộn sushi•cà chua, hạt nêm•đường.&nbsp;
- Cá Trứng Lăn Bột Chiên Giòn. cá trứng•Bột chiên giòn•Dầu ăn•Tương ớt.&nbsp;
- Cá Trứng Chiên Mắm.&nbsp;
- Cá trứng chiên giòn.&nbsp;
- Cá Trứng Chiên Mè Chấm Mắm Me.&nbsp;
- Cơm chiên cá trứng.&nbsp;
- Cá trứng chiên sả ớt.&nbsp;
- Cá trứng chiên.&nbsp;',200,'catrung.jpeg','09-25-2021',30,0),
(65,4,N'Chả cá thác lác',21000,N'Chả cá thác lác Kỳ Như là sản phẩm không thể thiếu cho mọi nhà, thích hợp cho các bà nội trợ chế biến thành những món ăn ngon, bổ dưỡng của thương hiệu thực phẩm Kỳ Như. Sản phẩm được chế biến từ những phần thịt cá thác lác tươi sống, còn giữ nguyên vị ngọt thanh.&nbsp;
Các món có thể chế biến từ Chả Cá Thác Lác:.&nbsp;
- Lẩu cá thác lác.&nbsp;
- Canh khổ qua cá thác lác.&nbsp;
- Canh bông bí cá thác lác.&nbsp;
- Canh chua chả cá thác lác.&nbsp;
- Bún chả cá thác lác.&nbsp;
- Chả cá thác lác chiên.&nbsp;
- Khoai môn bọc chả cá thác lác.&nbsp;
- Chả cá thác lác bọc xôi chiên.&nbsp;',200,'chacathaclac.jpg','09-25-2021',30,0),
(66,4,N'Lườn cá hồi',32500,N'Là loại thực phẩm giàu chất dinh dưỡng và cực kỳ tốt cho sức khoẻ. Lườn cá hồi vừa dễ ăn, vừa mang vị ngậy béo vô cùng, lại giàu omega-3, protein,... tốt cho cơ thể. Lườn cá hồi tươi ngon,
được làm sạch cẩn thận, chỉ cần rửa sạch là có thể chế biến món ăn. Không chỉ ngon miệng mà cá hồi còn được biết đến là thực phẩm giàu dinh dưỡng và tốt cho sức khỏe. Ăn cá hồi giúp phòng tránh một số bệnh và đặc biệt có ích cho tim, da, tóc và não bộ con người.
Cá hồi là loại cá có chứa Omega-3 giàu EPA và DHA, protein cùng nhiều dưỡng chất thiết yếu khác như vitamin B, kali và selen,... đều là những dưỡng chất cần thiết cho cơ thể. Nếu muốn sở hữu làn da trắng sáng và mịn màng hơn ngay từ bên trong thì cá hồi chính là sự lựa chọn tốt nhất cho bạn.
Các chất chống ôxy hóa carotenoid trong cá hồi có thể làm giảm đáng kể ảnh hưởng của các gốc tự do gây hại, gây lão hóa cho da. Lườn cá hồi nằm ở phần bụng cá, có vị béo, mềm, được mọi người rất yêu thích.',
250,'luoncahoi.jpg','09-25-2021',30,0),
(60,6,N'Trứng gà',21000,N'Trứng gà quê ngoại là một loại thực phẩm chứa nhiều chất dinh dưỡng, cung cấp lượng đạm cao, cung cấp chất béo và vitamin, khoáng chất. Các sản phẩm trứng của T.Food được sản xuất ở trang trại sạch, 
chất lượng, nên khách hàng có thể yên tâm về sản phẩm. Đặc biệt trứng gà quê ngoại giàu vitamin E và Omega 3 so với những trứng gà thông thường.&nbsp;
Các món được chế biến từ Trứng gà: &nbsp;

- Trứng chiên cà chua. Cà chua có vị chua nhẹ, thơm khi được kết hợp với trứng gà hoặc trứng vịt, chắc chắn sẽ làm bạn ngất ngây với món trứng chiên cà chua.&nbsp;
- Trứng chiên thịt bằm.&nbsp;
- Trứng chiên xúc xích.&nbsp;
- Trứng chiên phô mai.&nbsp;
- Trứng chiên nấm.&nbsp;
- Trứng chiên lá mơ.&nbsp;
- Trứng chiên lá lốt.&nbsp;
- Trứng chiên nước mắm.',
6,'trungga.jpg','09-25-2021',30,0),
(61,6,N'Trứng vịt',28800,N'Cũng như trứng gà, trứng vịt là một loại thực phẩm chứa nhiều chất dinh dưỡng, cung cấp lượng đạm cao, cung cấp chất béo và vitamin, khoáng chất.&nbsp;
Các món được chế biến từ Trứng Vịt: &nbsp;
- Trứng xào mướp đắng. Món trứng xào mướp đắng là món ăn giúp thanh nhiệt cơ thể và có hàm lượng vitamin dồi dào.&nbsp;
- Trứng xào ngồng tỏi.&nbsp;
- Trứng xào nấm hẹ.&nbsp;
- Trứng cuộn tôm hấp.&nbsp;
- Trứng chiên rau củ.&nbsp;
- Trứng chiên kim chi.&nbsp;
- Trứng chiên thịt.&nbsp;',
6,'trungvit.jpg','09-25-2021',30,0),
(67,5,N'Dầu ăn đậu nành',255000,N'Được làm từ những hạt đậu nành giàu dinh dưỡng, có hàm lượng Omega 3-6-9 cao tốt cho tim mạch. Được sản xuất trên dây chuyền công nghệ khép kín liên tục từ khâu trích ly đến khâu tinh luyện và đóng chai, dầu đậu nành cao cấp COBA giữ được hàm lượng dinh dưỡng, đem lại trái tim khỏe cho mọi nhà.&nbsp;
Bên cạnh thành phần an toàn, dầu đậu nành có chứa hàm lượng lớn các axit béo không bão hòa đơn và axit béo không bão hòa đa, như acid oleic làm tăng hàm lượng “Cholesterol tốt” (hay còn gọi là HDL) và giảm “Cholesterol xấu” (LDL). Dầu đậu nành giúp bổ sung Omega 3, 6, 9 có lợi cho sức khỏe và sự phát triển của não bộ.&nbsp;
ản phẩm có thể được sử dụng trong việc chế biến thành nhiều món ăn khác nhau từ chiên, xào, trộn salad, làm bánh, làm nước sốt chấm,... Đặc biệt, những người ăn chay hoặc ăn kiêng hoàn toàn có thể sử dụng được.&nbsp;
Sản phẩm có dung tích 5 lít, lượng dầu nhiều hơn, giá cả phải chăng, tiết kiệm chi phí, giúp các bà mẹ có đa dạng sự lựa chọn.&nbsp;
',5,'daudaunanh.jpg','09-25-2021',30,0),
(68,5,N'Dầu ăn Cái Lân',179000,N'Dầu thực vật tinh luyện Cái Lân chai 5 lít được tinh chế từ 100% dầu hạt đậu nành nguyên chất, cây oliu, hạt cải. Nhờ đó, dầu ăn luôn giữ được vị thơm béo đồng thời giữ nguyên vẹn các dưỡng chất thiết yếu.&nbsp;
Dầu ăn có chứa nhiều axit béo chưa no, khi ăn vào cơ thể có tác dụng chuyển hóa và rất tốt đối với những người mắc bệnh tim mạch, người cao tuổi. Sản phẩm còn cung cấp Omega-3, Omega-6 và Omega-9 tốt cho hệ tim mạch.&nbsp;
Sản phẩm đến từ thương hiệu dầu ăn Cái Lân không chứa cholesterol, không sử dụng chất bảo quản và chất tạo màu nên an toàn cho người sử dụng.&nbsp;',5,'dauancailan.jpg','09-25-2021',30,0),
(69,5,N'Dầu ăn Tường An',245000,N'Với ưu điểm giàu Omega 3,6,9, dầu đậu nành Tường An 5 lít sẽ giúp làm giảm nguy cơ tăng Cholesterol trong máu, tăng cường hệ thống miễn dịch. Dầu ăn Tường An luôn mang đến cho bạn nguồn dinh dưỡng tuyệt vời và một trái tim khoẻ mạnh với các dòng dầu ăn an toàn cho sức khoẻ.&nbsp;',5,'dauantuongan.jpg','09-25-2021',30,0),
(70,5,N'Dầu ăn Simply',264000,N'rong dầu đậu nành Simply nguyên chất can 5 lít có chứa tới 80% axit béo chưa bão hoà cùng một lượng lớn chất chống oxy hoá có khả năng làm giảm lượng cholesterol xấu trong máu và cho bạn một trái tim khoẻ mạnh.&nbsp;
Đây là loại dầu ăn sử dụng nguyên liệu chọn lọc, không chứa chất bảo quản, chất tạo màu hay cholesterol, hoàn toàn thân thiện cho sức khoẻ.&nbsp;
Ưu điểm của dầu đậu nành Simply:.&nbsp;
- Nguyên liệu chọn lọc từ những hạt đậu nành có nguồn gốc từ Châu Mỹ.&nbsp;
- Công nghệ tinh chế hiện đại, đảm bảo độ tinh khiết và giữ được trọn vẹn giá trị dinh dưỡng.&nbsp;
- Giàu Omega-3, Omega-6 & Omega-9, tốt cho tim mạch.&nbsp;
- Có bổ sung vitamin A và vitamin E giúp mắt khoẻ và da căng mịn.&nbsp;
- Được hội tim mạch Việt Nam khuyên dùng.&nbsp;',5,'dauansimply.jpg','09-25-2021',30,0)
GO
CREATE TABLE QUANLYDONHANG
(	
	MaDonHang int identity primary key not null,
	MaKH int foreign key references THANHVIEN(MaTV),
	--MaNV int foreign key references NhanVien(MaNV),
	NgayDat date default getdate(),
	NgayGiao date default getdate(),
	GhiChu nvarchar(50),
)
GO

INSERT INTO QUANLYDONHANG
VALUES
(2,'09-09-2021','09-09-2021',N'Giao hàng trong vòng 24h.')

GO
CREATE TABLE CHITIETDONHANG
(
	MaDonHang int foreign key references QUANLYDONHANG(MaDonHang),
	MaThucPham int foreign key references THUCPHAM(MaThucPham),
	MaLoaiThucPham int foreign key references LOAITHUCPHAM(MaLoaiThucPham),
	TrongLuong int,
	TongTien decimal(10,2) check(TongTien>0),
	NgayThanhToan date default getdate(),
	ThanhToan int check (ThanhToan in(1,0)) default 0 not null, /* yes/no 1/0 */
	primary key(MaDonHang,MaThucPham,MaLoaiThucPham )
)
GO
--drop table CHITIETDONHANG
INSERT INTO CHITIETDONHANG
VALUES
(1,50,1,500,65.000,'09-09-2021',1)

GO
CREATE TABLE BINHLUAN
(
	MaBL int identity primary key not null,
	TenNguoiBL nvarchar(50),
	NoiDungBL nvarchar(1000),
	MaThucPham int foreign key references THUCPHAM(MaThucPham),
	NgayBL date default getdate(),
	Email varchar(200), --NEW
	DanhGia int,  --NEW
	Duyet int check(Duyet in (1,0)) default 0
)
GO
--DROP TABLE BINHLUAN
INSERT INTO BINHLUAN
VALUES
(N'Vô danh',N'Thực phẩm rất tươi và sạch',50,'09-09-2021','m.contact@gmail.com',5,1)
GO

CREATE TABLE CHUONGTRINHKHUYENMAI
(
	MaKM int identity primary key not null,
	TenKM nvarchar(100),
	ThoiGianBD date default getdate(),
	ThoiGianKT date default getdate(),
	Up int default 0
)
GO
INSERT INTO CHUONGTRINHKHUYENMAI
VALUES
(N'Mua 2 tặng 1', '09-25-2021', '10-08-2021',0),
(N'Giảm 20%', '09-25-2021', '10-08-2021' ,0),
(N'Giảm 30%', '09-25-2021', '10-08-2021' ,0),
(N'Khung giờ vàng giảm 50%', '09-25-2021', '10-08-2021',0)
--DROP table CHUONGTRINHKHUYENMAI
CREATE TABLE CHITIETKHUYENMAI
(
	MaCT int identity primary key not null,
	MaKM int foreign key references CHUONGTRINHKHUYENMAI(MaKM),
	MaThucPham int foreign key references THUCPHAM(MaThucPham),
	TenThucPham nvarchar(30), 
	Gia money,
	AnhBia nvarchar(500),
	GiamGia int,
	Up int default 0
)
--INSERT INTO CHITIETKHUYENMAI
--VALUES
--(4, 1, 50),
--(1, 2, 50),
--(2, 3, 50),
--(3, 4, 50)
--DROP table CHITIETKHUYENMAI

CREATE TABLE TINNHANLIENHE
(
	MaTinNhan int identity primary key not null,
	TenKH nvarchar(30),
	Email varchar(50),
	TieuDe nvarchar(100),
	NoiDungTuKH nvarchar(1000),
	MaNhanVien int,
	TraLoi nvarchar(1000),
	NgayNhan date default getdate()
)


--Data thanh toán
CREATE TABLE DATA_PAYMENT
(
	ID int identity primary key not null,
	MaDonHang int,
	paymentMethod varchar(10),
	bankCode varchar(10)
)
--INSERT INTO DATA_PAYMENT
--VALUES
--(1, 'CASH', 'ATM_ONLINE')
--DROP table DATA_PAYMENT