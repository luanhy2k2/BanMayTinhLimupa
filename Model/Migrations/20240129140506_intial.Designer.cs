﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Models;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(QuanlybanhangContext))]
    [Migration("20240129140506_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Model.Models.ChiTietAnh", b =>
                {
                    b.Property<int>("MaAnhChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaAnhChiTiet"), 1L, 1);

                    b.Property<string>("Anh")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("SanpId")
                        .HasColumnType("int")
                        .HasColumnName("sanp_id");

                    b.HasKey("MaAnhChiTiet");

                    b.HasIndex("SanpId");

                    b.ToTable("ChiTietAnh", (string)null);
                });

            modelBuilder.Entity("Model.Models.ChiTietDonHang", b =>
                {
                    b.Property<int>("MaChiTietDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietDonHang"), 1L, 1);

                    b.Property<int?>("GiaMua")
                        .HasColumnType("int");

                    b.Property<int?>("MaDonHang")
                        .HasColumnType("int");

                    b.Property<int?>("SanpId")
                        .HasColumnType("int")
                        .HasColumnName("sanp_id");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietDonHang");

                    b.HasIndex("MaDonHang");

                    b.HasIndex("SanpId");

                    b.ToTable("ChiTietDonHang", (string)null);
                });

            modelBuilder.Entity("Model.Models.ChiTietHoaDonBan", b =>
                {
                    b.Property<int>("MaChiTietHoaDonBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietHoaDonBan"), 1L, 1);

                    b.Property<int?>("GiaBan")
                        .HasColumnType("int");

                    b.Property<int?>("SanpId")
                        .HasColumnType("int")
                        .HasColumnName("sanp_id");

                    b.Property<int?>("SoHoaDon")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietHoaDonBan");

                    b.HasIndex("SanpId");

                    b.HasIndex("SoHoaDon");

                    b.ToTable("ChiTietHoaDonBan", (string)null);
                });

            modelBuilder.Entity("Model.Models.ChiTietHoaDonNhap", b =>
                {
                    b.Property<int>("MaChiTietHoaDonNhap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietHoaDonNhap"), 1L, 1);

                    b.Property<int?>("DonGia")
                        .HasColumnType("int");

                    b.Property<int?>("SanpId")
                        .HasColumnType("int")
                        .HasColumnName("sanp_id");

                    b.Property<int?>("SoHoaDon")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietHoaDonNhap");

                    b.HasIndex("SanpId");

                    b.HasIndex("SoHoaDon");

                    b.ToTable("ChiTietHoaDonNhap", (string)null);
                });

            modelBuilder.Entity("Model.Models.ChiTietKho", b =>
                {
                    b.Property<int>("MaChiTietKho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietKho"), 1L, 1);

                    b.Property<int?>("MaKho")
                        .HasColumnType("int");

                    b.Property<int?>("SanpId")
                        .HasColumnType("int")
                        .HasColumnName("sanp_id");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietKho");

                    b.HasIndex("MaKho");

                    b.HasIndex("SanpId");

                    b.ToTable("ChiTietKho", (string)null);
                });

            modelBuilder.Entity("Model.Models.DonHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDonHang"), 1L, 1);

                    b.Property<int?>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayDat")
                        .HasColumnType("date");

                    b.Property<int?>("ToTal")
                        .HasColumnType("int");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TrangThai");

                    b.Property<string>("TrangThaiGiaoHang")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TrangThaiGiaoHang");

                    b.Property<string>("TrangThaiThanhToan")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TrangThaiThanhToan");

                    b.HasKey("MaDonHang");

                    b.HasIndex("MaKhachHang");

                    b.ToTable("DonHang", (string)null);
                });

            modelBuilder.Entity("Model.Models.entity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("hoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Model.Models.GiaCa", b =>
                {
                    b.Property<int>("MaSo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSo"), 1L, 1);

                    b.Property<int?>("Gia")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("date");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("date");

                    b.Property<int?>("SanpId")
                        .HasColumnType("int")
                        .HasColumnName("sanp_id");

                    b.HasKey("MaSo");

                    b.HasIndex("SanpId");

                    b.ToTable("GiaCa", (string)null);
                });

            modelBuilder.Entity("Model.Models.HoaDonBan", b =>
                {
                    b.Property<int>("SoHoaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoHoaDon"), 1L, 1);

                    b.Property<int?>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayBan")
                        .HasColumnType("date");

                    b.Property<int?>("ToTal")
                        .HasColumnType("int");

                    b.HasKey("SoHoaDon");

                    b.HasIndex("MaKhachHang");

                    b.ToTable("HoaDonBan", (string)null);
                });

            modelBuilder.Entity("Model.Models.HoaDonNhap", b =>
                {
                    b.Property<int>("SoHoaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoHoaDon"), 1L, 1);

                    b.Property<int?>("MaNguoiDung")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayNhap")
                        .HasColumnType("date");

                    b.Property<int?>("NsxId")
                        .HasColumnType("int")
                        .HasColumnName("nsx_id");

                    b.Property<int?>("ToTal")
                        .HasColumnType("int");

                    b.HasKey("SoHoaDon");

                    b.HasIndex("MaNguoiDung");

                    b.HasIndex("NsxId");

                    b.ToTable("HoaDonNhap", (string)null);
                });

            modelBuilder.Entity("Model.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKhachHang"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sdt")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SDT");

                    b.Property<string>("TenKhachHang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaKhachHang");

                    b.ToTable("KhachHang", (string)null);
                });

            modelBuilder.Entity("Model.Models.Kho", b =>
                {
                    b.Property<int>("MaKho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKho"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenKho")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaKho");

                    b.ToTable("Kho", (string)null);
                });

            modelBuilder.Entity("Model.Models.Loaisp", b =>
                {
                    b.Property<int>("LoaiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("loai_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiId"), 1L, 1);

                    b.Property<string>("LoaiName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("loai_name");

                    b.HasKey("LoaiId")
                        .HasName("PK__Loaisp__25B10ED8F4FCD793");

                    b.ToTable("Loaisp", (string)null);
                });

            modelBuilder.Entity("Model.Models.NguoiDung", b =>
                {
                    b.Property<int>("MaNguoiDung")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNguoiDung"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GioiTinh")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoTen")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("Sdt")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SDT");

                    b.HasKey("MaNguoiDung");

                    b.ToTable("NguoiDung", (string)null);
                });

            modelBuilder.Entity("Model.Models.Nhasx", b =>
                {
                    b.Property<int>("NsxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nsx_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NsxId"), 1L, 1);

                    b.Property<string>("Diachi")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("diachi")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("NsxName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nsx_name");

                    b.Property<int?>("Sdt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sdt")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("NsxId")
                        .HasName("PK__Nhasx__298823BF3D295D5C");

                    b.ToTable("Nhasx", (string)null);
                });

            modelBuilder.Entity("Model.Models.ProductComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MaNguoiDung")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("noiDung");

                    b.Property<int?>("SanpId")
                        .HasColumnType("int")
                        .HasColumnName("sanp_id");

                    b.HasKey("Id");

                    b.HasIndex("MaNguoiDung");

                    b.HasIndex("SanpId");

                    b.ToTable("productComment", (string)null);
                });

            modelBuilder.Entity("Model.Models.Sanpham", b =>
                {
                    b.Property<int>("SanpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sanp_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanpId"), 1L, 1);

                    b.Property<string>("Battery")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("battery");

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("card");

                    b.Property<string>("Cpu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("cpu");

                    b.Property<string>("Display")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("display");

                    b.Property<string>("Image")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("image");

                    b.Property<int>("LoaiId")
                        .HasColumnType("int")
                        .HasColumnName("loai_id");

                    b.Property<DateTime?>("Namsx")
                        .HasColumnType("datetime")
                        .HasColumnName("namsx");

                    b.Property<int>("NsxId")
                        .HasColumnType("int")
                        .HasColumnName("nsx_id");

                    b.Property<string>("Ram")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ram");

                    b.Property<string>("Rom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("rom");

                    b.Property<string>("SanpName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("sanp_name");

                    b.Property<string>("Tomtat")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("tomtat")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("SanpId")
                        .HasName("PK__Sanpham__FBCD4D6E7BD38EE4");

                    b.HasIndex("LoaiId");

                    b.HasIndex("NsxId");

                    b.ToTable("Sanpham", (string)null);
                });

            modelBuilder.Entity("Model.Models.Slide", b =>
                {
                    b.Property<int>("MaSlide")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSlide"), 1L, 1);

                    b.Property<string>("Link")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Slide1")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("Slide");

                    b.HasKey("MaSlide");

                    b.ToTable("Slide", (string)null);
                });

            modelBuilder.Entity("Model.Models.TaiKhoan", b =>
                {
                    b.Property<int>("MaTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTaiKhoan"), 1L, 1);

                    b.Property<string>("LoaiQuyen")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MaNguoiDung")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("date");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("date");

                    b.Property<string>("TaiKhoan1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TaiKhoan");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaTaiKhoan");

                    b.HasIndex("MaNguoiDung");

                    b.ToTable("TaiKhoan", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Model.Models.entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Model.Models.entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Models.entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Model.Models.entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Models.ChiTietAnh", b =>
                {
                    b.HasOne("Model.Models.Sanpham", "Sanp")
                        .WithMany("ChiTietAnhs")
                        .HasForeignKey("SanpId")
                        .HasConstraintName("FK__ChiTietAn__sanp___6EF57B66");

                    b.Navigation("Sanp");
                });

            modelBuilder.Entity("Model.Models.ChiTietDonHang", b =>
                {
                    b.HasOne("Model.Models.DonHang", "MaDonHangNavigation")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaDonHang")
                        .HasConstraintName("FK__ChiTietDo__MaDon__4F47C5E3");

                    b.HasOne("Model.Models.Sanpham", "Sanp")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("SanpId")
                        .HasConstraintName("FK__ChiTietDo__sanp___70DDC3D8");

                    b.Navigation("MaDonHangNavigation");

                    b.Navigation("Sanp");
                });

            modelBuilder.Entity("Model.Models.ChiTietHoaDonBan", b =>
                {
                    b.HasOne("Model.Models.Sanpham", "Sanp")
                        .WithMany("ChiTietHoaDonBans")
                        .HasForeignKey("SanpId")
                        .HasConstraintName("FK__ChiTietHo__sanp___71D1E811");

                    b.HasOne("Model.Models.HoaDonBan", "SoHoaDonNavigation")
                        .WithMany("ChiTietHoaDonBans")
                        .HasForeignKey("SoHoaDon")
                        .HasConstraintName("FK__ChiTietHo__SoHoa__72C60C4A");

                    b.Navigation("Sanp");

                    b.Navigation("SoHoaDonNavigation");
                });

            modelBuilder.Entity("Model.Models.ChiTietHoaDonNhap", b =>
                {
                    b.HasOne("Model.Models.Sanpham", "Sanp")
                        .WithMany("ChiTietHoaDonNhaps")
                        .HasForeignKey("SanpId")
                        .HasConstraintName("FK__ChiTietHo__sanp___73BA3083");

                    b.HasOne("Model.Models.HoaDonNhap", "SoHoaDonNavigation")
                        .WithMany("ChiTietHoaDonNhaps")
                        .HasForeignKey("SoHoaDon")
                        .HasConstraintName("FK__ChiTietHo__SoHoa__74AE54BC");

                    b.Navigation("Sanp");

                    b.Navigation("SoHoaDonNavigation");
                });

            modelBuilder.Entity("Model.Models.ChiTietKho", b =>
                {
                    b.HasOne("Model.Models.Kho", "MaKhoNavigation")
                        .WithMany("ChiTietKhos")
                        .HasForeignKey("MaKho")
                        .HasConstraintName("FK__ChiTietKh__MaKho__75A278F5");

                    b.HasOne("Model.Models.Sanpham", "Sanp")
                        .WithMany("ChiTietKhos")
                        .HasForeignKey("SanpId")
                        .HasConstraintName("FK__ChiTietKh__sanp___76969D2E");

                    b.Navigation("MaKhoNavigation");

                    b.Navigation("Sanp");
                });

            modelBuilder.Entity("Model.Models.DonHang", b =>
                {
                    b.HasOne("Model.Models.KhachHang", "MaKhachHangNavigation")
                        .WithMany("DonHangs")
                        .HasForeignKey("MaKhachHang")
                        .HasConstraintName("FK__DonHang__MaKhach__778AC167");

                    b.Navigation("MaKhachHangNavigation");
                });

            modelBuilder.Entity("Model.Models.GiaCa", b =>
                {
                    b.HasOne("Model.Models.Sanpham", "Sanp")
                        .WithMany("GiaCas")
                        .HasForeignKey("SanpId")
                        .HasConstraintName("FK__GiaCa__sanp_id__787EE5A0");

                    b.Navigation("Sanp");
                });

            modelBuilder.Entity("Model.Models.HoaDonBan", b =>
                {
                    b.HasOne("Model.Models.NguoiDung", "MaNguoiDungNavigation")
                        .WithMany("HoaDonBans")
                        .HasForeignKey("MaKhachHang")
                        .HasConstraintName("FK__HoaDonBan__MaKha__151B244E");

                    b.Navigation("MaNguoiDungNavigation");
                });

            modelBuilder.Entity("Model.Models.HoaDonNhap", b =>
                {
                    b.HasOne("Model.Models.NguoiDung", "MaNguoiDungNavigation")
                        .WithMany("HoaDonNhaps")
                        .HasForeignKey("MaNguoiDung")
                        .HasConstraintName("FK__HoaDonNha__MaNgu__7A672E12");

                    b.HasOne("Model.Models.Nhasx", "Nsx")
                        .WithMany("HoaDonNhaps")
                        .HasForeignKey("NsxId")
                        .HasConstraintName("FK__HoaDonNha__nsx_i__7B5B524B");

                    b.Navigation("MaNguoiDungNavigation");

                    b.Navigation("Nsx");
                });

            modelBuilder.Entity("Model.Models.ProductComment", b =>
                {
                    b.HasOne("Model.Models.NguoiDung", "MaNguoiDungNavigation")
                        .WithMany("ProductComments")
                        .HasForeignKey("MaNguoiDung")
                        .HasConstraintName("FK__productCo__MaNgu__7C4F7684");

                    b.HasOne("Model.Models.Sanpham", "Sanp")
                        .WithMany("ProductComments")
                        .HasForeignKey("SanpId")
                        .HasConstraintName("FK__productCo__sanp___7D439ABD");

                    b.Navigation("MaNguoiDungNavigation");

                    b.Navigation("Sanp");
                });

            modelBuilder.Entity("Model.Models.Sanpham", b =>
                {
                    b.HasOne("Model.Models.Loaisp", "Loai")
                        .WithMany("Sanphams")
                        .HasForeignKey("LoaiId")
                        .IsRequired()
                        .HasConstraintName("FK__Sanpham__loai_id__7E37BEF6");

                    b.HasOne("Model.Models.Nhasx", "Nsx")
                        .WithMany("Sanphams")
                        .HasForeignKey("NsxId")
                        .IsRequired()
                        .HasConstraintName("FK__Sanpham__nsx_id__7F2BE32F");

                    b.Navigation("Loai");

                    b.Navigation("Nsx");
                });

            modelBuilder.Entity("Model.Models.TaiKhoan", b =>
                {
                    b.HasOne("Model.Models.NguoiDung", "MaNguoiDungNavigation")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("MaNguoiDung")
                        .HasConstraintName("FK__TaiKhoan__MaNguo__00200768");

                    b.Navigation("MaNguoiDungNavigation");
                });

            modelBuilder.Entity("Model.Models.DonHang", b =>
                {
                    b.Navigation("ChiTietDonHangs");
                });

            modelBuilder.Entity("Model.Models.HoaDonBan", b =>
                {
                    b.Navigation("ChiTietHoaDonBans");
                });

            modelBuilder.Entity("Model.Models.HoaDonNhap", b =>
                {
                    b.Navigation("ChiTietHoaDonNhaps");
                });

            modelBuilder.Entity("Model.Models.KhachHang", b =>
                {
                    b.Navigation("DonHangs");
                });

            modelBuilder.Entity("Model.Models.Kho", b =>
                {
                    b.Navigation("ChiTietKhos");
                });

            modelBuilder.Entity("Model.Models.Loaisp", b =>
                {
                    b.Navigation("Sanphams");
                });

            modelBuilder.Entity("Model.Models.NguoiDung", b =>
                {
                    b.Navigation("HoaDonBans");

                    b.Navigation("HoaDonNhaps");

                    b.Navigation("ProductComments");

                    b.Navigation("TaiKhoans");
                });

            modelBuilder.Entity("Model.Models.Nhasx", b =>
                {
                    b.Navigation("HoaDonNhaps");

                    b.Navigation("Sanphams");
                });

            modelBuilder.Entity("Model.Models.Sanpham", b =>
                {
                    b.Navigation("ChiTietAnhs");

                    b.Navigation("ChiTietDonHangs");

                    b.Navigation("ChiTietHoaDonBans");

                    b.Navigation("ChiTietHoaDonNhaps");

                    b.Navigation("ChiTietKhos");

                    b.Navigation("GiaCas");

                    b.Navigation("ProductComments");
                });
#pragma warning restore 612, 618
        }
    }
}
