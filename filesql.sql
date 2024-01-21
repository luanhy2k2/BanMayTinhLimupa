

GO
/****** Object:  Table [dbo].[ChiTietAnh]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietAnh](
	[MaAnhChiTiet] [int] IDENTITY(1,1) NOT NULL,
	[id_product] [int] NULL,
	[Anh] [nvarchar](2000) NULL,
 CONSTRAINT [PK_ChiTietAnh] PRIMARY KEY CLUSTERED 
(
	[MaAnhChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietorder]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietorder](
	[MaChiTietorder] [int] IDENTITY(1,1) NOT NULL,
	[id_order] [int] NULL,
	[id_product] [int] NULL,
	[SoLuong] [int] NULL,
	[GiaMua] [int] NULL,
 CONSTRAINT [PK_ChiTietorder] PRIMARY KEY CLUSTERED 
(
	[MaChiTietorder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDonBan]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonBan](
	[MaChiTietHoaDonBan] [int] IDENTITY(1,1) NOT NULL,
	[SoHoaDon] [int] NULL,
	[id_product] [int] NULL,
	[SoLuong] [int] NULL,
	[GiaBan] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDonBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDonNhap]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonNhap](
	[MaChiTietHoaDonNhap] [int] IDENTITY(1,1) NOT NULL,
	[SoHoaDon] [int] NULL,
	[id_product] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDonNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietKho]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietKho](
	[MaChiTietKho] [int] IDENTITY(1,1) NOT NULL,
	[MaKho] [int] NULL,
	[id_product] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietKho] PRIMARY KEY CLUSTERED 
(
	[MaChiTietKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id_order] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [date] NULL,
	[TrangThai] [nvarchar](50) NULL,
	[ToTal] [int] NULL,
	[id_customer] [int] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id_order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaCa]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaCa](
	[MaSo] [int] IDENTITY(1,1) NOT NULL,
	[id_product] [int] NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[Gia] [int] NULL,
 CONSTRAINT [PK_GiaCa] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[SoHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[NgayBan] [date] NULL,
	[MaNguoiDung] [int] NULL,
	[ToTal] [int] NULL,
 CONSTRAINT [PK_HoaDonBan] PRIMARY KEY CLUSTERED 
(
	[SoHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[SoHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[NgayNhap] [date] NULL,
	[MaNguoiDung] [int] NULL,
	[nsx_id] [int] NULL,
	[ToTal] [int] NULL,
 CONSTRAINT [PK_HoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[SoHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id_customer] [int] IDENTITY(1,1) NOT NULL,
	[customer_name] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[id_customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[MaKho] [int] IDENTITY(1,1) NOT NULL,
	[TenKho] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kho] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[danhmuc]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[danhmuc](
	[danhmuc_id] [int] IDENTITY(1,1) NOT NULL,
	[danhmuc_name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[danhmuc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producer]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producer](
	[nsx_id] [int] IDENTITY(1,1) NOT NULL,
	[nsx_name] [nvarchar](50) NOT NULL,
	[diachi] [nvarchar](50) NULL,
	[sdt] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[nsx_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productComment]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productComment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_product] [int] NULL,
	[MaNguoiDung] [int] NULL,
	[noiDung] [nvarchar](500) NULL,
 CONSTRAINT [PK_productComment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id_product] [int] IDENTITY(1,1) NOT NULL,
	[name_product] [nvarchar](250) NOT NULL,
	[danhmuc_id] [int] NOT NULL,
	[nsx_id] [int] NOT NULL,
	[tomtat] [nvarchar](2000) NOT NULL,
	[namsx] [datetime] NULL,
	[dungTich] [nvarchar](20) null,
	[trongLuong] [nvarchar](20) null,
	[image] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[MaSlide] [int] IDENTITY(1,1) NOT NULL,
	[Slide] [nvarchar](2000) NULL,
	[Link] [nvarchar](200) NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[MaSlide] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 11/12/2023 10:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[TrangThai] [nvarchar](50) NULL,
	[LoaiQuyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietorder] ON 

INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (5, 1, 2, 1, 123000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (6, 2, 2, 1, 124590)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (7, 7, 2, 1, 124590)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (8, 7, 3, 2, 224590)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (9, 8, 2, 1, 1)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (10, 9, 2, 1, 1)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (11, 10, 4, NULL, NULL)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (12, 11, 4, NULL, NULL)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (13, 12, 4, NULL, NULL)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (14, 13, 4, NULL, NULL)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (15, 13, 3, NULL, NULL)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (16, 19, 4, 1, 125000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (17, 20, 4, 1, 231000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (18, 20, 3, 1, 120000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (19, 21, 4, 1, 231000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (20, 22, 4, 1, 231000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (21, 22, 3, 1, 120000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (22, 21, 3, 1, 120000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (23, 23, 4, 1, 231000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (24, 23, 3, 1, 120000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (26, 25, 3, 1, 120000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (27, 25, 2, 1, 230000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (28, 26, 2, 2, 230000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (29, 26, 4, 3, 231000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (30, 27, 2, 2, 230000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (31, 27, 4, 3, 231000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (32, 28, 2, 2, 230000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (33, 28, 4, 3, 231000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (34, 29, 2, 2, 230000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (35, 29, 4, 3, 231000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (36, 30, 2, 2, 230000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (37, 30, 4, 3, 231000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (39, 32, 2, 1, 12600000)
INSERT [dbo].[ChiTietorder] ([MaChiTietorder], [id_order], [id_product], [SoLuong], [GiaMua]) VALUES (40, 32, 3, 1, 120000)
SET IDENTITY_INSERT [dbo].[ChiTietorder] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonBan] ON 

INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [id_product], [SoLuong], [GiaBan]) VALUES (2, 1, 2, 1, 125000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [id_product], [SoLuong], [GiaBan]) VALUES (3, 1, 2, 1, 125000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [id_product], [SoLuong], [GiaBan]) VALUES (4, 1, 3, 1, 87000)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonBan] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonNhap] ON 

INSERT [dbo].[ChiTietHoaDonNhap] ([MaChiTietHoaDonNhap], [SoHoaDon], [id_product], [SoLuong], [DonGia]) VALUES (2, 1, 2, 10, 1350000)
INSERT [dbo].[ChiTietHoaDonNhap] ([MaChiTietHoaDonNhap], [SoHoaDon], [id_product], [SoLuong], [DonGia]) VALUES (3, 1, 3, 10, 2350000)
INSERT [dbo].[ChiTietHoaDonNhap] ([MaChiTietHoaDonNhap], [SoHoaDon], [id_product], [SoLuong], [DonGia]) VALUES (4, 2, 4, 10, 2540000)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[order] ON 

INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (1, CAST(N'2023-11-04' AS Date), N'Chưa xác nhận', 1234342, 1)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (2, CAST(N'2023-11-05' AS Date), N'string', 0, 1)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (3, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 5)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (4, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 6)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (5, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 7)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (6, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 8)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (7, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 9)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (8, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 10)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (9, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 11)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (10, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 13)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (11, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 12)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (12, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 14)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (13, CAST(N'2023-11-06' AS Date), N'Chưa xác nhận', 1, 15)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (14, CAST(N'2023-11-07' AS Date), N'Chưa xác nhận', 1, 16)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (15, CAST(N'2023-11-07' AS Date), N'Chưa xác nhận', 1, 17)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (16, CAST(N'2023-11-07' AS Date), N'Chưa xác nhận', 1, 18)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (17, CAST(N'2023-11-07' AS Date), N'Chưa xác nhận', 1, 20)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (18, CAST(N'2023-11-07' AS Date), N'Chưa xác nhận', 1, 19)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (19, CAST(N'2023-11-07' AS Date), N'Chưa xác nhận', 1, 21)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (20, CAST(N'2023-11-07' AS Date), N'Chưa xác nhận', 1, 22)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (21, CAST(N'2023-11-07' AS Date), N'Chưa xác nhận', 351000, 23)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (22, CAST(N'2023-11-07' AS Date), N'Chưa xác nhận', 351000, 24)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (23, CAST(N'2023-11-19' AS Date), N'Chưa xác nhận', 351000, 25)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (24, CAST(N'2023-12-07' AS Date), N'Chưa xác nhận', 640200, 26)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (25, CAST(N'2023-12-07' AS Date), N'Chưa xác nhận', 350000, 27)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (26, CAST(N'2023-12-07' AS Date), N'Chưa xác nhận', 1153000, 28)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (27, CAST(N'2023-12-08' AS Date), N'Chưa xác nhận', 1153000, 29)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (28, CAST(N'2023-12-08' AS Date), N'Chưa xác nhận', 1153000, 30)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (29, CAST(N'2023-12-08' AS Date), N'Chưa xác nhận', 1153000, 31)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (30, CAST(N'2023-12-08' AS Date), N'Chưa xác nhận', 1153000, 32)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (31, CAST(N'2023-12-11' AS Date), N'Chưa xác nhận', 12843120, 33)
INSERT [dbo].[order] ([id_order], [NgayDat], [TrangThai], [ToTal], [id_customer]) VALUES (32, CAST(N'2023-12-11' AS Date), N'Chưa xác nhận', 12720000, 34)
SET IDENTITY_INSERT [dbo].[order] OFF
GO
SET IDENTITY_INSERT [dbo].[GiaCa] ON 

INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (1, 2, CAST(N'2023-08-14' AS Date), NULL, 12600000)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (2, 3, CAST(N'2023-08-14' AS Date), NULL, 120000)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (3, 4, CAST(N'2023-08-14' AS Date), NULL, 231000)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (5, 8, CAST(N'2023-11-13' AS Date), NULL, 250000)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (6, 9, CAST(N'2023-12-07' AS Date), NULL, 123000)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (8, 11, CAST(N'2023-12-07' AS Date), NULL, 123000)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (9, 12, CAST(N'2023-12-07' AS Date), NULL, 123000)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (11, 14, CAST(N'2023-12-07' AS Date), NULL, 123120)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (12, 15, CAST(N'2023-12-07' AS Date), NULL, 123120)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (14, 17, CAST(N'2023-12-08' AS Date), NULL, 123120)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (15, 25, CAST(N'2023-12-11' AS Date), NULL, 125000)
INSERT [dbo].[GiaCa] ([MaSo], [id_product], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (16, 26, CAST(N'2023-12-11' AS Date), NULL, 12350000)
SET IDENTITY_INSERT [dbo].[GiaCa] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonBan] ON 

INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaNguoiDung], [ToTal]) VALUES (1, CAST(N'2023-10-29' AS Date), 1, 125000)
SET IDENTITY_INSERT [dbo].[HoaDonBan] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonNhap] ON 

INSERT [dbo].[HoaDonNhap] ([SoHoaDon], [NgayNhap], [MaNguoiDung], [nsx_id], [ToTal]) VALUES (1, CAST(N'2023-10-29' AS Date), 1, 1, 1450000)
INSERT [dbo].[HoaDonNhap] ([SoHoaDon], [NgayNhap], [MaNguoiDung], [nsx_id], [ToTal]) VALUES (2, CAST(N'2023-10-28' AS Date), 1, 1, 2450000)
SET IDENTITY_INSERT [dbo].[HoaDonNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (1, N'Đinh Thành Luân', N'Hưng Yên', N'luan2k2hy@gmail.com', N'0987676753')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (2, N'kj', N'string', N'string', N'string')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (3, N'kj', N'string', N'string', N'string')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (4, N'ds', N'string', N'string', N'string')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (5, N'Phí Văn An', N'Ân Thi-Hưng Yên', N'An@gmail.com', N'0978654567')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (6, N'Phí Văn An', N'Ân Thi-Hưng Yên', N'An@gmail.com', N'0978654567')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (7, N'Phí Văn An', N'Ân Thi-Hưng Yên', N'An@gmail.com', N'0978654567')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (8, N'Phí Văn An', N'Ân Thi-Hưng Yên', N'An@gmail.com', N'0978654567')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (9, N'Phí Văn An', N'Ân Thi-Hưng Yên', N'An@gmail.com', N'0978654567')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (10, N'a', N'a', N'a', N'a')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (11, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (12, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (13, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (14, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (15, N'Nguyễn Văn An', N'Đặng Lễ-Ân Thi-Hưng Yên', N'fuji@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (16, NULL, NULL, NULL, NULL)
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (17, N'b', N'b', N'b', N'b')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (18, N'b', N'b', N'b', N'b')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (19, NULL, NULL, NULL, NULL)
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (20, NULL, NULL, NULL, NULL)
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (21, N'Luaa', N'Hung Yen', N'luan@gmail.com', N'0987656787')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (22, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (23, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (24, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (25, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (26, N'Nguyễn Quang Anh', N'Hà Nội', N'luanhy2k2@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (27, N'Nguyễn Quang Anh', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luanhy2k2@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (28, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luanhy2k2@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (29, N'', N'', N'', N'')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (30, N'', N'', N'', N'')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (31, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luanhy2k2@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (32, N'Đinh Thành Luân', N'Hà Nội', N'luanhy2k2@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (33, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luanhy2k2@gmail.com', N'0987878786')
INSERT [dbo].[customer] ([id_customer], [customer_name], [DiaChi], [Email], [SDT]) VALUES (34, N'Đinh Thành Luân', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luanhy2k2@gmail.com', N'0987878786')
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[danhmuc] ON 

INSERT [dbo].[danhmuc] ([danhmuc_id], [danhmuc_name]) VALUES (1, N'Yamaha')

SET IDENTITY_INSERT [dbo].[danhmuc] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Email], [SDT]) VALUES (1, N'Đinh Thành Luân', CAST(N'2002-09-15' AS Date), N'Nam', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0971877014')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Email], [SDT]) VALUES (2, N'Nguyễn Quang Anh', CAST(N'2002-09-01' AS Date), N'Nam', N'Đặng Lễ-Ân Thi-Hưng Yên', N'anh2k2@gmail.com', N'0978765654')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Email], [SDT]) VALUES (3, N'Hoàng Hào Vũ', CAST(N'2002-03-09' AS Date), N'Nam', N'Yên Mỹ-Mỹ Hào-Hưng Yên', N'vu@gmail.com', N'0978656765')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Email], [SDT]) VALUES (4, N'Phạm Xuân Tuyển', CAST(N'2002-03-09' AS Date), N'Nam', N'Yên Mỹ-Mỹ Hào-Hưng Yên', N'vu@gmail.com', N'0978656765')
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[producer] ON 

INSERT [dbo].[producer] ([nsx_id], [nsx_name], [diachi], [sdt]) VALUES (2, N'Yamha', N'120 Cầu Giấy, Hà Nội', 978787666)

SET IDENTITY_INSERT [dbo].[producer] OFF
GO
SET IDENTITY_INSERT [dbo].[productComment] ON 

INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (1, 2, 1, N'hay')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (2, 3, 2, N'Chất lượng')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (3, 4, 3, N'hay')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (4, 2, 2, N'5 sao')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (5, 2, 2, N'5 sao')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (8, 2, 2, N'Đỉnh')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (9, 3, 2, N'Hay')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (10, 3, 2, N'5 sao')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (11, 2, 2, N'Chất lượng')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (12, 3, 2, N'Đỉnh')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (13, 3, 2, N'Chất')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (14, 3, 2, N'sdf')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (15, 3, 2, N'dfg')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (16, 3, 2, N'dfg')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (17, 4, 2, N'không hay')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (18, 2, 2, N'hay')
INSERT [dbo].[productComment] ([id], [id_product], [MaNguoiDung], [noiDung]) VALUES (19, 2, 2, N'hay')
SET IDENTITY_INSERT [dbo].[productComment] OFF
GO
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (2, N'Laptop Dell 7420', 2, 1, N'...', CAST(N'2023-12-10T10:02:26.733' AS DateTime),  N'string')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (3, N'Trồng cây gây rừng', 2, 1, N'...', CAST(N'2023-08-14T01:12:38.433' AS DateTime), N'3UBHZDJM.jpg')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (4, N'Dù được ban đôi cánh', 3, 1, N'...', CAST(N'2023-08-14T01:15:48.813' AS DateTime),  N'4WBD9Q8Y.jpg')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (8, N'Đại Nam', 3, 2, N'...', CAST(N'2001-09-09T00:00:00.000' AS DateTime),  N'7YYWZJ3H.jpg')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (9, N'Gương soi tội lỗis', 2, 1, N'...', CAST(N'2023-12-24T00:00:00.000' AS DateTime), N'C3F24YNQ.jpg')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (11, N'Đại Nam', 2, 1, N'...', CAST(N'2023-12-08T00:00:00.000' AS DateTime),  N'3UBHZDJM.jpg')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (12, N'Đại Nam', 2, 1, N'...', CAST(N'2023-12-31T00:00:00.000' AS DateTime),  N'')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (14, N'Đại Nam', 2, 1, N'1', CAST(N'2023-12-23T00:00:00.000' AS DateTime),  N'')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (15, N'Gương soi tội lỗi', 2, 1, N'...', CAST(N'2023-12-21T00:00:00.000' AS DateTime),  N'ánh.jpg')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (17, N'Cùng ăn sinh nhật', 4, 1, N'...', CAST(N'2023-12-17T00:00:00.000' AS DateTime),  N'DKQYFA75.jpg')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (25, N'string', 2, 1, N'string', CAST(N'2023-12-10T16:44:42.447' AS DateTime),  N'string')
INSERT [dbo].[product] ([id_product], [name_product], [danhmuc_id], [nsx_id], [tomtat], [namsx],  [image]) VALUES (26, N'12a', 32, 1, N'1', CAST(N'2001-09-09T00:00:00.000' AS DateTime),  N'6HHNAJ7E.jpg')
SET IDENTITY_INSERT [dbo].[product] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNguoiDung], [TaiKhoan], [MatKhau], [NgayBatDau], [NgayKetThuc], [TrangThai], [LoaiQuyen]) VALUES (1, 4, N'tuyen@gmail.com', N'1', NULL, NULL, N'1', N'admin')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
ALTER TABLE [dbo].[producer] ADD  DEFAULT ((0)) FOR [diachi]
GO
ALTER TABLE [dbo].[producer] ADD  DEFAULT ((0)) FOR [sdt]
GO
ALTER TABLE [dbo].[product] ADD  DEFAULT ((0)) FOR [tomtat]
GO
ALTER TABLE [dbo].[ChiTietAnh]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[product] ([id_product])
GO
ALTER TABLE [dbo].[ChiTietorder]  WITH CHECK ADD FOREIGN KEY([id_order])
REFERENCES [dbo].[order] ([id_order])
GO
ALTER TABLE [dbo].[ChiTietorder]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[product] ([id_product])
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[product] ([id_product])
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan]  WITH CHECK ADD FOREIGN KEY([SoHoaDon])
REFERENCES [dbo].[HoaDonBan] ([SoHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[product] ([id_product])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD FOREIGN KEY([SoHoaDon])
REFERENCES [dbo].[HoaDonNhap] ([SoHoaDon])
GO
ALTER TABLE [dbo].[ChiTietKho]  WITH CHECK ADD FOREIGN KEY([MaKho])
REFERENCES [dbo].[Kho] ([MaKho])
GO
ALTER TABLE [dbo].[ChiTietKho]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[product] ([id_product])
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD FOREIGN KEY([id_customer])
REFERENCES [dbo].[customer] ([id_customer])
GO
ALTER TABLE [dbo].[GiaCa]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[product] ([id_product])
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD FOREIGN KEY([nsx_id])
REFERENCES [dbo].[producer] ([nsx_id])
GO
ALTER TABLE [dbo].[productComment]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[productComment]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[product] ([id_product])
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([danhmuc_id])
REFERENCES [dbo].[danhmuc] ([danhmuc_id])
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([nsx_id])
REFERENCES [dbo].[producer] ([nsx_id])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
USE [master]
GO
ALTER DATABASE [QuanLyMayTinh] SET  READ_WRITE 
GO
