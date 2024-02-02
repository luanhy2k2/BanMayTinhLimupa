USE [master]
GO
/****** Object:  Database [Limupa]    Script Date: 3/2/2024 3:49:12 AM ******/
CREATE DATABASE [Limupa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Limupa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Limupa.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Limupa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Limupa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Limupa] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Limupa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Limupa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Limupa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Limupa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Limupa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Limupa] SET ARITHABORT OFF 
GO
ALTER DATABASE [Limupa] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Limupa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Limupa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Limupa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Limupa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Limupa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Limupa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Limupa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Limupa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Limupa] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Limupa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Limupa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Limupa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Limupa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Limupa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Limupa] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Limupa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Limupa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Limupa] SET  MULTI_USER 
GO
ALTER DATABASE [Limupa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Limupa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Limupa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Limupa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Limupa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Limupa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Limupa] SET QUERY_STORE = ON
GO
ALTER DATABASE [Limupa] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Limupa]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[hoTen] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietAnh]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietAnh](
	[MaAnhChiTiet] [int] IDENTITY(1,1) NOT NULL,
	[sanp_id] [int] NULL,
	[Anh] [nvarchar](2000) NULL,
 CONSTRAINT [PK_ChiTietAnh] PRIMARY KEY CLUSTERED 
(
	[MaAnhChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaChiTietDonHang] [int] IDENTITY(1,1) NOT NULL,
	[MaDonHang] [int] NULL,
	[sanp_id] [int] NULL,
	[SoLuong] [int] NULL,
	[GiaMua] [int] NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[MaChiTietDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDonBan]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonBan](
	[MaChiTietHoaDonBan] [int] IDENTITY(1,1) NOT NULL,
	[SoHoaDon] [int] NULL,
	[sanp_id] [int] NULL,
	[SoLuong] [int] NULL,
	[GiaBan] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDonBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDonNhap]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonNhap](
	[MaChiTietHoaDonNhap] [int] IDENTITY(1,1) NOT NULL,
	[SoHoaDon] [int] NULL,
	[sanp_id] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDonNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietKho]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietKho](
	[MaChiTietKho] [int] IDENTITY(1,1) NOT NULL,
	[MaKho] [int] NULL,
	[sanp_id] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietKho] PRIMARY KEY CLUSTERED 
(
	[MaChiTietKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [date] NULL,
	[TrangThai] [nvarchar](max) NULL,
	[TrangThaiThanhToan] [nvarchar](max) NULL,
	[TrangThaiGiaoHang] [nvarchar](max) NULL,
	[ToTal] [int] NULL,
	[MaKhachHang] [int] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaCa]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaCa](
	[MaSo] [int] IDENTITY(1,1) NOT NULL,
	[sanp_id] [int] NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[Gia] [int] NULL,
 CONSTRAINT [PK_GiaCa] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[SoHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[NgayBan] [date] NULL,
	[MaKhachHang] [int] NULL,
	[ToTal] [int] NULL,
 CONSTRAINT [PK_HoaDonBan] PRIMARY KEY CLUSTERED 
(
	[SoHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 3/2/2024 3:49:13 AM ******/
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
/****** Object:  Table [dbo].[KhachHang]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho]    Script Date: 3/2/2024 3:49:13 AM ******/
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
/****** Object:  Table [dbo].[Loaisp]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaisp](
	[loai_id] [int] IDENTITY(1,1) NOT NULL,
	[loai_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Loaisp__25B10ED8F4FCD793] PRIMARY KEY CLUSTERED 
(
	[loai_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 3/2/2024 3:49:13 AM ******/
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
/****** Object:  Table [dbo].[Nhasx]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhasx](
	[nsx_id] [int] IDENTITY(1,1) NOT NULL,
	[nsx_name] [nvarchar](50) NOT NULL,
	[diachi] [nvarchar](50) NULL,
	[sdt] [int] NULL,
 CONSTRAINT [PK__Nhasx__298823BF3D295D5C] PRIMARY KEY CLUSTERED 
(
	[nsx_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productComment]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productComment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sanp_id] [int] NULL,
	[MaNguoiDung] [int] NULL,
	[noiDung] [nvarchar](500) NULL,
 CONSTRAINT [PK_productComment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 3/2/2024 3:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham](
	[sanp_id] [int] IDENTITY(1,1) NOT NULL,
	[sanp_name] [nvarchar](250) NOT NULL,
	[loai_id] [int] NOT NULL,
	[nsx_id] [int] NOT NULL,
	[ram] [nvarchar](50) NOT NULL,
	[rom] [nvarchar](50) NOT NULL,
	[cpu] [nvarchar](50) NOT NULL,
	[display] [nvarchar](50) NOT NULL,
	[battery] [nvarchar](50) NOT NULL,
	[card] [nvarchar](50) NOT NULL,
	[tomtat] [nvarchar](2000) NOT NULL,
	[namsx] [datetime] NULL,
	[image] [nvarchar](50) NULL,
 CONSTRAINT [PK__Sanpham__FBCD4D6E7BD38EE4] PRIMARY KEY CLUSTERED 
(
	[sanp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 3/2/2024 3:49:13 AM ******/
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
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 3/2/2024 3:49:13 AM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240129140506_intial', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240129141039_createdatabase', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240131144441_addAddressuser', N'6.0.10')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0dc446bb-1f8f-4095-8335-c2edf8fa1808', N'Administrator', N'ADMINISTRATOR', N'a8ff9ea0-4916-4599-a080-49f51fb82e24')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1e8bdfb5-12ff-4fc8-95cc-7ae56e22e598', N'Staff', N'STAFF', N'068ed68f-bfe5-412b-894f-9d96bf764497')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'36b9caad-a823-46f3-8c56-a1958933a606', N'Customer', N'CUSTOMER', N'd4ca1c14-8caf-4c15-a0c8-7f806c6d7d08')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'120fc966-0f8b-499b-80a3-816061ae6166', N'0dc446bb-1f8f-4095-8335-c2edf8fa1808')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'869de74f-34f2-4762-b3c5-b96538a852fd', N'1e8bdfb5-12ff-4fc8-95cc-7ae56e22e598')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b97a3d02-cf93-4c09-97a0-bf984883b0d0', N'36b9caad-a823-46f3-8c56-a1958933a606')
GO
INSERT [dbo].[AspNetUsers] ([Id], [hoTen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [address]) VALUES (N'120fc966-0f8b-499b-80a3-816061ae6166', N'Đinh Thành Luân', N'luan@gmail.com', N'LUAN@GMAIL.COM', N'luan@gmail.com', N'LUAN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBWTqkPr1RyzaGUQb8/sGm4jmDxl8ccafAOmVa+Q8v16Fh+11AaBAdLURBOeZ5OicA==', N'S6HACNOR6EGGUDCGLCUBDBZ5VTFZCPWM', N'5581d029-6dd6-46ba-868e-9cbb943bde95', NULL, 0, 0, NULL, 1, 0, N'')
INSERT [dbo].[AspNetUsers] ([Id], [hoTen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [address]) VALUES (N'869de74f-34f2-4762-b3c5-b96538a852fd', N'Đinh Văn Phúc', N'phuc@gmail.com', N'PHUC@GMAIL.COM', N'phuc@gmail.com', N'PHUC@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHouruX2aonsoS74v8ncfOvPUy78A6PFSZodlDm23DXO1FyhsNFetMPJ8S2hBoRUgg==', N'XXJCNYZYO2KNS4KBCMGBIMCIDP3UBOP6', N'2e7d1444-f35e-442c-811d-f3fded5f8c39', N'0976787676', 0, 0, NULL, 1, 0, N'Đặng Lễ, Ân Thi, Hưng Yên')
INSERT [dbo].[AspNetUsers] ([Id], [hoTen], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [address]) VALUES (N'b97a3d02-cf93-4c09-97a0-bf984883b0d0', N'Nguyễn Quang Anh', N'anh@example.com', N'ANH@EXAMPLE.COM', N'anh@example.com', N'ANH@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEAadPjv5GBbTEbeCZCMqj6xZQ4Pc/g9aP5zaSFUOcXOqcV/n2Kj/MNXhsieFMa2B6g==', N'MOSUOLSSDZDURHWTNJW43SV5HZBAJFLH', N'7a4d8ab5-57b3-4992-8ebd-24d03f23e639', N'0971866014', 0, 0, NULL, 1, 0, N'Ân Thi, Hưng Yên')
GO
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] ON 

INSERT [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [sanp_id], [SoLuong], [GiaMua]) VALUES (55, 42, 4, 1, 18500000)
INSERT [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [sanp_id], [SoLuong], [GiaMua]) VALUES (56, 42, 3, 1, 20000000)
INSERT [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [sanp_id], [SoLuong], [GiaMua]) VALUES (57, 43, 2, 1, 27000000)
INSERT [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [sanp_id], [SoLuong], [GiaMua]) VALUES (58, 44, 11, 1, 34000000)
INSERT [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [sanp_id], [SoLuong], [GiaMua]) VALUES (59, 44, 12, 1, 22300000)
INSERT [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [sanp_id], [SoLuong], [GiaMua]) VALUES (60, 45, 9, 1, 17800000)
INSERT [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [sanp_id], [SoLuong], [GiaMua]) VALUES (61, 45, 12, 1, 22300000)
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonBan] ON 

INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (19, 18, 2, 1, 27000000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (20, 20, 12, 1, 22300000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (21, 20, 11, 1, 34000000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (22, 21, 11, 1, 34000000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (23, 21, 12, 1, 22300000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (24, 22, 11, 1, 34000000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (25, 22, 12, 1, 22300000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (26, 23, 12, 1, 22300000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (27, 23, 11, 1, 34000000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (28, 24, 11, 1, 34000000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (29, 24, 12, 1, 22300000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (30, 25, 12, 1, 22300000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (31, 25, 11, 1, 34000000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (32, 26, 11, 1, 34000000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (33, 26, 12, 1, 22300000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (34, 27, 11, 1, 34000000)
INSERT [dbo].[ChiTietHoaDonBan] ([MaChiTietHoaDonBan], [SoHoaDon], [sanp_id], [SoLuong], [GiaBan]) VALUES (35, 27, 12, 1, 22300000)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonBan] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonNhap] ON 

INSERT [dbo].[ChiTietHoaDonNhap] ([MaChiTietHoaDonNhap], [SoHoaDon], [sanp_id], [SoLuong], [DonGia]) VALUES (11, 7, 2, 30, 810000000)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietKho] ON 

INSERT [dbo].[ChiTietKho] ([MaChiTietKho], [MaKho], [sanp_id], [SoLuong]) VALUES (7, 1, 2, 129)
INSERT [dbo].[ChiTietKho] ([MaChiTietKho], [MaKho], [sanp_id], [SoLuong]) VALUES (8, NULL, 3, 99)
INSERT [dbo].[ChiTietKho] ([MaChiTietKho], [MaKho], [sanp_id], [SoLuong]) VALUES (9, NULL, 4, 99)
INSERT [dbo].[ChiTietKho] ([MaChiTietKho], [MaKho], [sanp_id], [SoLuong]) VALUES (10, NULL, 8, 100)
INSERT [dbo].[ChiTietKho] ([MaChiTietKho], [MaKho], [sanp_id], [SoLuong]) VALUES (11, NULL, 9, 100)
INSERT [dbo].[ChiTietKho] ([MaChiTietKho], [MaKho], [sanp_id], [SoLuong]) VALUES (12, NULL, 11, 99)
INSERT [dbo].[ChiTietKho] ([MaChiTietKho], [MaKho], [sanp_id], [SoLuong]) VALUES (13, NULL, 12, 99)
INSERT [dbo].[ChiTietKho] ([MaChiTietKho], [MaKho], [sanp_id], [SoLuong]) VALUES (15, NULL, 14, 100)
SET IDENTITY_INSERT [dbo].[ChiTietKho] OFF
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([MaDonHang], [NgayDat], [TrangThai], [TrangThaiThanhToan], [TrangThaiGiaoHang], [ToTal], [MaKhachHang]) VALUES (42, CAST(N'2024-01-29' AS Date), N'Đã xác nhận', N'Chưa thanh toán', N'Giao hàng thành công', 38500000, 44)
INSERT [dbo].[DonHang] ([MaDonHang], [NgayDat], [TrangThai], [TrangThaiThanhToan], [TrangThaiGiaoHang], [ToTal], [MaKhachHang]) VALUES (43, CAST(N'2024-01-30' AS Date), N'Đã xác nhận', N'Đã thanh toán', N'Giao hàng thành công', 27000000, 45)
INSERT [dbo].[DonHang] ([MaDonHang], [NgayDat], [TrangThai], [TrangThaiThanhToan], [TrangThaiGiaoHang], [ToTal], [MaKhachHang]) VALUES (44, CAST(N'2024-02-02' AS Date), N'Đã xác nhận', N'Chưa thanh toán', N'Giao hàng thành công', 56300000, 46)
INSERT [dbo].[DonHang] ([MaDonHang], [NgayDat], [TrangThai], [TrangThaiThanhToan], [TrangThaiGiaoHang], [ToTal], [MaKhachHang]) VALUES (45, CAST(N'2024-02-03' AS Date), N'Chưa xác nhận', N'Chưa thanh toán', N'Chưa giao hàng', 40100000, 47)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[GiaCa] ON 

INSERT [dbo].[GiaCa] ([MaSo], [sanp_id], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (19, 2, NULL, NULL, 27000000)
INSERT [dbo].[GiaCa] ([MaSo], [sanp_id], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (20, 3, NULL, NULL, 20000000)
INSERT [dbo].[GiaCa] ([MaSo], [sanp_id], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (21, 4, NULL, NULL, 18500000)
INSERT [dbo].[GiaCa] ([MaSo], [sanp_id], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (22, 8, NULL, NULL, 21200000)
INSERT [dbo].[GiaCa] ([MaSo], [sanp_id], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (23, 9, NULL, NULL, 17800000)
INSERT [dbo].[GiaCa] ([MaSo], [sanp_id], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (24, 11, NULL, NULL, 34000000)
INSERT [dbo].[GiaCa] ([MaSo], [sanp_id], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (25, 12, NULL, NULL, 22300000)
INSERT [dbo].[GiaCa] ([MaSo], [sanp_id], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (26, 14, NULL, NULL, 21500000)
INSERT [dbo].[GiaCa] ([MaSo], [sanp_id], [NgayBatDau], [NgayKetThuc], [Gia]) VALUES (27, 15, NULL, NULL, 16500000)
SET IDENTITY_INSERT [dbo].[GiaCa] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonBan] ON 

INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (18, CAST(N'2024-01-29' AS Date), 45, 27000000)
INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (19, CAST(N'2024-01-30' AS Date), 41, 21500000)
INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (20, CAST(N'2024-02-01' AS Date), 46, 56300000)
INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (21, CAST(N'2024-02-01' AS Date), 46, 56300000)
INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (22, CAST(N'2024-02-01' AS Date), 46, 56300000)
INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (23, CAST(N'2024-02-01' AS Date), 46, 56300000)
INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (24, CAST(N'2024-02-01' AS Date), 46, 56300000)
INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (25, CAST(N'2024-02-01' AS Date), 46, 56300000)
INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (26, CAST(N'2024-02-01' AS Date), 46, 56300000)
INSERT [dbo].[HoaDonBan] ([SoHoaDon], [NgayBan], [MaKhachHang], [ToTal]) VALUES (27, CAST(N'2024-02-01' AS Date), 46, 56300000)
SET IDENTITY_INSERT [dbo].[HoaDonBan] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonNhap] ON 

INSERT [dbo].[HoaDonNhap] ([SoHoaDon], [NgayNhap], [MaNguoiDung], [nsx_id], [ToTal]) VALUES (7, CAST(N'2024-01-29' AS Date), 1, 1, 810000000)
SET IDENTITY_INSERT [dbo].[HoaDonNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [Email], [SDT]) VALUES (41, N'Đinh Thành Luân', N'Ân Thi, Hưng Yên', N'luan2k2hy@gmail.com', N'0971877014')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [Email], [SDT]) VALUES (42, N'Nguyễn Quốc Anh', N'Ân Thi, Hưng Yên', N'anh@gmail.com', N'0967656787')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [Email], [SDT]) VALUES (43, N'Đinh Thành Luân', N'Ân Thi, Hưng Yên', N'luan2k2hy@gmail.com', N'0971877014')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [Email], [SDT]) VALUES (44, N'Đinh Thành Luân', N'Đặng Lễ, Ân Thi, Hưng Yên', N'luan2k2hy@gmail.com', N'0971877014')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [Email], [SDT]) VALUES (45, N'Đinh Thành Luân', N'Ân Thi, Hưng Yên', N'luan2k2hy@gmail.com', N'0971877014')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [Email], [SDT]) VALUES (46, N'Nguyễn Việt Anh', N'Ân Thi, Hưng Yên', N'anh@gmail.com', N'0971878656')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [Email], [SDT]) VALUES (47, N'Nguyễn Quang Anh', N'Ân Thi, Hưng Yên', N'anh@example.com', N'0971866014')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[Kho] ON 

INSERT [dbo].[Kho] ([MaKho], [TenKho], [DiaChi]) VALUES (1, N'Limupa', N'Đống Đa, Hà Nội')
SET IDENTITY_INSERT [dbo].[Kho] OFF
GO
SET IDENTITY_INSERT [dbo].[Loaisp] ON 

INSERT [dbo].[Loaisp] ([loai_id], [loai_name]) VALUES (1, N'Dell')
INSERT [dbo].[Loaisp] ([loai_id], [loai_name]) VALUES (2, N'Acer')
INSERT [dbo].[Loaisp] ([loai_id], [loai_name]) VALUES (3, N'Asus')
INSERT [dbo].[Loaisp] ([loai_id], [loai_name]) VALUES (4, N'Lenovo')
INSERT [dbo].[Loaisp] ([loai_id], [loai_name]) VALUES (5, N'Sử/kí')
INSERT [dbo].[Loaisp] ([loai_id], [loai_name]) VALUES (12, N'HP')
INSERT [dbo].[Loaisp] ([loai_id], [loai_name]) VALUES (32, N'MacBook')
SET IDENTITY_INSERT [dbo].[Loaisp] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Email], [SDT]) VALUES (1, N'Đinh Thành Luân', CAST(N'2002-09-15' AS Date), N'Nam', N'Đặng Lễ-Ân Thi-Hưng Yên', N'luan2k2hy@gmail.com', N'0971877014')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Email], [SDT]) VALUES (2, N'Nguyễn Quang Anh', CAST(N'2002-09-01' AS Date), N'Nam', N'Đặng Lễ-Ân Thi-Hưng Yên', N'anh2k2@gmail.com', N'0978765654')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Email], [SDT]) VALUES (3, N'Hoàng Hào Vũ', CAST(N'2002-03-09' AS Date), N'Nam', N'Yên Mỹ-Mỹ Hào-Hưng Yên', N'vu@gmail.com', N'0978656765')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Email], [SDT]) VALUES (4, N'Phạm Xuân Tuyển', CAST(N'2002-03-09' AS Date), N'Nam', N'Yên Mỹ-Mỹ Hào-Hưng Yên', N'vu@gmail.com', N'0978656765')
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[Nhasx] ON 

INSERT [dbo].[Nhasx] ([nsx_id], [nsx_name], [diachi], [sdt]) VALUES (1, N'Nhã Nam', N'120 Cầu Giấy, Hà Nội', 978787666)
INSERT [dbo].[Nhasx] ([nsx_id], [nsx_name], [diachi], [sdt]) VALUES (2, N'IPM', N'Số 103,Cầu Giấy, Hà Nội ', 971877014)
SET IDENTITY_INSERT [dbo].[Nhasx] OFF
GO
SET IDENTITY_INSERT [dbo].[Sanpham] ON 

INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (2, N'Laptop Dell 7420', 3, 1, N'8 GB', N'SSD 1TB', N'I7 4500U', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'45 Wh', N'NVIDIA MX250 2GB GDDR5', N'....', CAST(N'2023-12-10T10:02:26.733' AS DateTime), N'4671_dell_7490.jpg')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (3, N'Laptop Asus 7401', 2, 1, N'8 GB', N'SSD 1TB', N'i5 7400U', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'250w', N'Nvidia Gtx3060 ', N'...', CAST(N'2024-01-13T12:32:24.753' AS DateTime), N'laptop.webp')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (4, N'Laptop Asus Vivo Go 14', 3, 1, N'8 GB', N'SSD 256GB', N'Intel Core i7-8565U 4C-8T', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'45 Wh', N'NVIDIA MX250 2GB GDDR5', N'...', CAST(N'2023-08-14T01:15:48.813' AS DateTime), N'unnamed (1).webp')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (8, N'Laptop Dell Inspiron 14 7430', 3, 1, N'16 GB', N'SSD 1TB', N'Intel Core i7-8565U 4C-8T', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'	45 Wh', N'NVIDIA MX250 2GB GDDR5', N'...', CAST(N'2001-09-09T00:00:00.000' AS DateTime), N'unnamed (1).webp')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (9, N' Laptop Dell Inspiron 16 5630 ', 1, 1, N'8 GB', N'SSD 256GB', N'Intel Core i7-8565U 4C-8T', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'45 Wh', N'NVIDIA MX250 2GB GDDR5', N'...', CAST(N'2023-12-24T00:00:00.000' AS DateTime), N'unnamed (3).webp')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (11, N'Laptop Acer Nitro 16 Phoenix AN16-41-R5M4', 2, 1, N'16 GB', N'SSD 512GB', N'Intel Core i7-8565U 4C-8T', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'45 Wh', N'NVIDIA MX250 2GB GDDR5', N'...', CAST(N'2023-12-08T00:00:00.000' AS DateTime), N'unnamed (4).webp')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (12, N' Laptop Acer Nitro 5 Eagle AN515-57-54MV ', 2, 1, N'16 GB', N'SSD 1TB', N'Intel Core i7-8565U 4C-8T', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'45 Wh', N'NVIDIA MX250 2GB GDDR5', N'...', CAST(N'2023-12-31T00:00:00.000' AS DateTime), N'unnamed (5).webp')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (14, N'Laptop ACER Nitro 5 AN515-58-52SP', 2, 1, N'16 GB', N'SSD 512GB', N'Intel Core i7-8565U 4C-8T', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'45 Wh', N'NVIDIA MX250 2GB GDDR5', N'...', CAST(N'2023-12-23T00:00:00.000' AS DateTime), N'laptop.webp')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (15, N'Gương soi tội lỗi', 2, 1, N'16 GB', N'SSD 256GB', N'Intel Core i7-8565U 4C-8T', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'	45 Wh', N'NVIDIA MX250 2GB GDDR5', N'...', CAST(N'2023-12-21T00:00:00.000' AS DateTime), N'ánh.jpg')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (17, N'Cùng ăn sinh nhật', 4, 1, N'8gb', N'SSD 256GB', N'Intel Core i7-8565U 4C-8T', N'13.3 inch FHD 1920x1080 60Hz, 300 nits', N'	45 Wh', N'NVIDIA MX250 2GB GDDR5', N'...', CAST(N'2023-12-17T00:00:00.000' AS DateTime), N'DKQYFA75.jpg')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (25, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2023-12-10T16:44:42.447' AS DateTime), N'string')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (26, N'12a', 32, 1, N'1', N'1', N'1', N'1', N'1', N'1', N'1', CAST(N'2001-09-09T00:00:00.000' AS DateTime), N'6HHNAJ7E.jpg')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (28, N'a', 5, 1, N'a', N'a', N'a', N'a', N'a', N'a', N'a', CAST(N'2023-12-24T22:36:00.000' AS DateTime), N'ánh.jpg')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (30, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2024-01-20T12:43:54.417' AS DateTime), N'string')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (31, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2024-01-20T12:52:37.880' AS DateTime), N'string')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (32, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2024-01-20T13:10:51.837' AS DateTime), N'string')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (33, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2024-01-20T13:15:19.177' AS DateTime), N'string')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (34, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2024-01-20T13:21:52.567' AS DateTime), N'string')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (35, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2024-01-20T13:26:20.253' AS DateTime), N'string')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (36, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2024-01-20T13:30:10.850' AS DateTime), N'string')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (37, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2024-01-20T14:00:59.757' AS DateTime), N'string')
INSERT [dbo].[Sanpham] ([sanp_id], [sanp_name], [loai_id], [nsx_id], [ram], [rom], [cpu], [display], [battery], [card], [tomtat], [namsx], [image]) VALUES (38, N'string', 2, 1, N'string', N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2024-01-20T14:06:24.987' AS DateTime), N'string')
SET IDENTITY_INSERT [dbo].[Sanpham] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNguoiDung], [TaiKhoan], [MatKhau], [NgayBatDau], [NgayKetThuc], [TrangThai], [LoaiQuyen]) VALUES (1, 4, N'tuyen@gmail.com', N'1', NULL, NULL, N'1', N'admin')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNguoiDung], [TaiKhoan], [MatKhau], [NgayBatDau], [NgayKetThuc], [TrangThai], [LoaiQuyen]) VALUES (2, 1, N'luan2k2hy@gmail.com', N'150922', NULL, NULL, N'1', N'admin')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNguoiDung], [TaiKhoan], [MatKhau], [NgayBatDau], [NgayKetThuc], [TrangThai], [LoaiQuyen]) VALUES (3, 3, N'vu@gmail.com', N'1', NULL, NULL, N'1', N'client')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietAnh_sanp_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietAnh_sanp_id] ON [dbo].[ChiTietAnh]
(
	[sanp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietDonHang_MaDonHang]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietDonHang_MaDonHang] ON [dbo].[ChiTietDonHang]
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietDonHang_sanp_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietDonHang_sanp_id] ON [dbo].[ChiTietDonHang]
(
	[sanp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietHoaDonBan_sanp_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietHoaDonBan_sanp_id] ON [dbo].[ChiTietHoaDonBan]
(
	[sanp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietHoaDonBan_SoHoaDon]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietHoaDonBan_SoHoaDon] ON [dbo].[ChiTietHoaDonBan]
(
	[SoHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietHoaDonNhap_sanp_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietHoaDonNhap_sanp_id] ON [dbo].[ChiTietHoaDonNhap]
(
	[sanp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietHoaDonNhap_SoHoaDon]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietHoaDonNhap_SoHoaDon] ON [dbo].[ChiTietHoaDonNhap]
(
	[SoHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietKho_MaKho]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietKho_MaKho] ON [dbo].[ChiTietKho]
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ChiTietKho_sanp_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChiTietKho_sanp_id] ON [dbo].[ChiTietKho]
(
	[sanp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DonHang_MaKhachHang]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_DonHang_MaKhachHang] ON [dbo].[DonHang]
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GiaCa_sanp_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_GiaCa_sanp_id] ON [dbo].[GiaCa]
(
	[sanp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDonBan_MaKhachHang]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonBan_MaKhachHang] ON [dbo].[HoaDonBan]
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDonNhap_MaNguoiDung]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonNhap_MaNguoiDung] ON [dbo].[HoaDonNhap]
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDonNhap_nsx_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonNhap_nsx_id] ON [dbo].[HoaDonNhap]
(
	[nsx_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_productComment_MaNguoiDung]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_productComment_MaNguoiDung] ON [dbo].[productComment]
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_productComment_sanp_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_productComment_sanp_id] ON [dbo].[productComment]
(
	[sanp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sanpham_loai_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_Sanpham_loai_id] ON [dbo].[Sanpham]
(
	[loai_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sanpham_nsx_id]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_Sanpham_nsx_id] ON [dbo].[Sanpham]
(
	[nsx_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaiKhoan_MaNguoiDung]    Script Date: 3/2/2024 3:49:14 AM ******/
CREATE NONCLUSTERED INDEX [IX_TaiKhoan_MaNguoiDung] ON [dbo].[TaiKhoan]
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [address]
GO
ALTER TABLE [dbo].[Nhasx] ADD  DEFAULT ((0)) FOR [diachi]
GO
ALTER TABLE [dbo].[Nhasx] ADD  DEFAULT ((0)) FOR [sdt]
GO
ALTER TABLE [dbo].[Sanpham] ADD  DEFAULT ((0)) FOR [tomtat]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ChiTietAnh]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietAn__sanp___6EF57B66] FOREIGN KEY([sanp_id])
REFERENCES [dbo].[Sanpham] ([sanp_id])
GO
ALTER TABLE [dbo].[ChiTietAnh] CHECK CONSTRAINT [FK__ChiTietAn__sanp___6EF57B66]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietDo__MaDon__4F47C5E3] FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaDonHang])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK__ChiTietDo__MaDon__4F47C5E3]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietDo__sanp___70DDC3D8] FOREIGN KEY([sanp_id])
REFERENCES [dbo].[Sanpham] ([sanp_id])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK__ChiTietDo__sanp___70DDC3D8]
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__sanp___71D1E811] FOREIGN KEY([sanp_id])
REFERENCES [dbo].[Sanpham] ([sanp_id])
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan] CHECK CONSTRAINT [FK__ChiTietHo__sanp___71D1E811]
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__SoHoa__72C60C4A] FOREIGN KEY([SoHoaDon])
REFERENCES [dbo].[HoaDonBan] ([SoHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan] CHECK CONSTRAINT [FK__ChiTietHo__SoHoa__72C60C4A]
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__sanp___73BA3083] FOREIGN KEY([sanp_id])
REFERENCES [dbo].[Sanpham] ([sanp_id])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] CHECK CONSTRAINT [FK__ChiTietHo__sanp___73BA3083]
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__SoHoa__74AE54BC] FOREIGN KEY([SoHoaDon])
REFERENCES [dbo].[HoaDonNhap] ([SoHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] CHECK CONSTRAINT [FK__ChiTietHo__SoHoa__74AE54BC]
GO
ALTER TABLE [dbo].[ChiTietKho]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietKh__MaKho__75A278F5] FOREIGN KEY([MaKho])
REFERENCES [dbo].[Kho] ([MaKho])
GO
ALTER TABLE [dbo].[ChiTietKho] CHECK CONSTRAINT [FK__ChiTietKh__MaKho__75A278F5]
GO
ALTER TABLE [dbo].[ChiTietKho]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietKh__sanp___76969D2E] FOREIGN KEY([sanp_id])
REFERENCES [dbo].[Sanpham] ([sanp_id])
GO
ALTER TABLE [dbo].[ChiTietKho] CHECK CONSTRAINT [FK__ChiTietKh__sanp___76969D2E]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK__DonHang__MaKhach__778AC167] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK__DonHang__MaKhach__778AC167]
GO
ALTER TABLE [dbo].[GiaCa]  WITH CHECK ADD  CONSTRAINT [FK__GiaCa__sanp_id__787EE5A0] FOREIGN KEY([sanp_id])
REFERENCES [dbo].[Sanpham] ([sanp_id])
GO
ALTER TABLE [dbo].[GiaCa] CHECK CONSTRAINT [FK__GiaCa__sanp_id__787EE5A0]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK__HoaDonNha__MaNgu__7A672E12] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK__HoaDonNha__MaNgu__7A672E12]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK__HoaDonNha__nsx_i__7B5B524B] FOREIGN KEY([nsx_id])
REFERENCES [dbo].[Nhasx] ([nsx_id])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK__HoaDonNha__nsx_i__7B5B524B]
GO
ALTER TABLE [dbo].[productComment]  WITH CHECK ADD  CONSTRAINT [FK__productCo__MaNgu__7C4F7684] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[productComment] CHECK CONSTRAINT [FK__productCo__MaNgu__7C4F7684]
GO
ALTER TABLE [dbo].[productComment]  WITH CHECK ADD  CONSTRAINT [FK__productCo__sanp___7D439ABD] FOREIGN KEY([sanp_id])
REFERENCES [dbo].[Sanpham] ([sanp_id])
GO
ALTER TABLE [dbo].[productComment] CHECK CONSTRAINT [FK__productCo__sanp___7D439ABD]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK__Sanpham__loai_id__7E37BEF6] FOREIGN KEY([loai_id])
REFERENCES [dbo].[Loaisp] ([loai_id])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK__Sanpham__loai_id__7E37BEF6]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK__Sanpham__nsx_id__7F2BE32F] FOREIGN KEY([nsx_id])
REFERENCES [dbo].[Nhasx] ([nsx_id])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK__Sanpham__nsx_id__7F2BE32F]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK__TaiKhoan__MaNguo__00200768] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK__TaiKhoan__MaNguo__00200768]
GO
USE [master]
GO
ALTER DATABASE [Limupa] SET  READ_WRITE 
GO
