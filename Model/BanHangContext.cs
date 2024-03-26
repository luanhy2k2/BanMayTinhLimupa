using System;
using System.Collections.Generic;
using System.Text.Json;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class QuanlybanhangContext : IdentityDbContext<ApplicationUser>
{
    public QuanlybanhangContext()
    {

    }
    public QuanlybanhangContext(DbContextOptions<QuanlybanhangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietAnh> ChiTietAnh { get; set; }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }

    public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBan { get; set; }

    public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhap { get; set; }

    public virtual DbSet<ChiTietKho> ChiTietKho { get; set; }



    public virtual DbSet<DonHang> DonHang { get; set; }

    public virtual DbSet<GiaCa> GiaCa { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBan { get; set; }

    public virtual DbSet<HoaDonNhap> HoaDonNhap { get; set; }

    public virtual DbSet<KhachHang> KhachHang { get; set; }

    public virtual DbSet<Kho> Kho { get; set; }

    public virtual DbSet<Loaisp> Loaisp { get; set; }



    public virtual DbSet<Nhasx> Nhasx { get; set; }

    public virtual DbSet<ProductComment> ProductComment { get; set; }

    public virtual DbSet<Sanpham> Sanpham { get; set; }
    public virtual DbSet<Message> Message { get; set; }
    public virtual DbSet<Room> Room { get; set; }
    public virtual DbSet<Slide> Slide { get; set; }



    public Task SaveChangesAsync(JsonSerializerOptions jsonSerializerOptions)
    {
        throw new NotImplementedException();
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    //    => optionsBuilder.UseSqlServer("Server=ADMIN;Database=Limupa;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietAnh>(entity =>
        {
            entity.HasKey(e => e.MaAnhChiTiet);

            entity.ToTable("ChiTietAnh");

            entity.HasIndex(e => e.SanpId, "IX_ChiTietAnh_sanp_id");

            entity.Property(e => e.Anh).HasMaxLength(2000);

            entity.Property(e => e.SanpId).HasColumnName("sanp_id");

            entity.HasOne(d => d.Sanp)
                .WithMany(p => p.ChiTietAnhs)
                .HasForeignKey(d => d.SanpId)
                .HasConstraintName("FK__ChiTietAn__sanp___6EF57B66");
        });

        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => e.MaChiTietDonHang);

            entity.ToTable("ChiTietDonHang");

            entity.HasIndex(e => e.MaDonHang, "IX_ChiTietDonHang_MaDonHang");

            entity.HasIndex(e => e.SanpId, "IX_ChiTietDonHang_sanp_id");

            entity.Property(e => e.SanpId).HasColumnName("sanp_id");

            entity.HasOne(d => d.MaDonHangNavigation)
                .WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaDonHang)
                .HasConstraintName("FK__ChiTietDo__MaDon__4F47C5E3");

            entity.HasOne(d => d.Sanp)
                .WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.SanpId)
                .HasConstraintName("FK__ChiTietDo__sanp___70DDC3D8");
        });

        modelBuilder.Entity<ChiTietHoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaChiTietHoaDonBan);

            entity.ToTable("ChiTietHoaDonBan");

            entity.HasIndex(e => e.SoHoaDon, "IX_ChiTietHoaDonBan_SoHoaDon");

            entity.HasIndex(e => e.SanpId, "IX_ChiTietHoaDonBan_sanp_id");

            entity.Property(e => e.SanpId).HasColumnName("sanp_id");

            entity.HasOne(d => d.Sanp)
                .WithMany(p => p.ChiTietHoaDonBans)
                .HasForeignKey(d => d.SanpId)
                .HasConstraintName("FK__ChiTietHo__sanp___71D1E811");

            entity.HasOne(d => d.SoHoaDonNavigation)
                .WithMany(p => p.ChiTietHoaDonBans)
                .HasForeignKey(d => d.SoHoaDon)
                .HasConstraintName("FK__ChiTietHo__SoHoa__72C60C4A");
        });

        modelBuilder.Entity<ChiTietHoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.MaChiTietHoaDonNhap);

            entity.ToTable("ChiTietHoaDonNhap");

            entity.HasIndex(e => e.SoHoaDon, "IX_ChiTietHoaDonNhap_SoHoaDon");

            entity.HasIndex(e => e.SanpId, "IX_ChiTietHoaDonNhap_sanp_id");

            entity.Property(e => e.NsxId).HasColumnName("nsx_id");

            entity.Property(e => e.SanpId).HasColumnName("sanp_id");

            entity.HasOne(d => d.Nsx)
                .WithMany(p => p.ChiTietHoaDonNhaps)
                .HasForeignKey(d => d.NsxId)
                .HasConstraintName("FK_ChiTietHoaDonNhap_Nhasx");

            entity.HasOne(d => d.Sanp)
                .WithMany(p => p.ChiTietHoaDonNhaps)
                .HasForeignKey(d => d.SanpId)
                .HasConstraintName("FK__ChiTietHo__sanp___73BA3083");

            entity.HasOne(d => d.SoHoaDonNavigation)
                .WithMany(p => p.ChiTietHoaDonNhaps)
                .HasForeignKey(d => d.SoHoaDon)
                .HasConstraintName("FK_ChiTietHoaDonNhap_HoaDonNhap");
        });

        modelBuilder.Entity<ChiTietKho>(entity =>
        {
            entity.HasKey(e => e.MaChiTietKho);

            entity.ToTable("ChiTietKho");

            entity.HasIndex(e => e.MaKho, "IX_ChiTietKho_MaKho");

            entity.HasIndex(e => e.SanpId, "IX_ChiTietKho_sanp_id");

            entity.Property(e => e.SanpId).HasColumnName("sanp_id");

            entity.HasOne(d => d.MaKhoNavigation)
                .WithMany(p => p.ChiTietKhos)
                .HasForeignKey(d => d.MaKho)
                .HasConstraintName("FK__ChiTietKh__MaKho__75A278F5");

            entity.HasOne(d => d.Sanp)
                .WithMany(p => p.ChiTietKhos)
                .HasForeignKey(d => d.SanpId)
                .HasConstraintName("FK__ChiTietKh__sanp___76969D2E");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang);

            entity.ToTable("DonHang");

            entity.HasIndex(e => e.MaKhachHang, "IX_DonHang_MaKhachHang");

            entity.Property(e => e.NgayDat).HasColumnType("date");

            entity.HasOne(d => d.MaKhachHangNavigation)
                .WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__DonHang__MaKhach__778AC167");
        });

        modelBuilder.Entity<GiaCa>(entity =>
        {
            entity.HasKey(e => e.MaSo);

            entity.ToTable("GiaCa");

            entity.HasIndex(e => e.SanpId, "IX_GiaCa_sanp_id");

            entity.Property(e => e.NgayBatDau).HasColumnType("date");

            entity.Property(e => e.NgayKetThuc).HasColumnType("date");

            entity.Property(e => e.SanpId).HasColumnName("sanp_id");

            entity.HasOne(d => d.Sanp)
                .WithMany(p => p.GiaCas)
                .HasForeignKey(d => d.SanpId)
                .HasConstraintName("FK__GiaCa__sanp_id__787EE5A0");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.SoHoaDon);

            entity.ToTable("HoaDonBan");

            entity.HasIndex(e => e.MaKhachHang, "IX_HoaDonBan_MaKhachHang");

            entity.Property(e => e.NgayBan).HasColumnType("date");

            entity.HasOne(d => d.MaKhachHangNavigation)
                .WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__HoaDonBan__MaKha__2739D489");
        });

        modelBuilder.Entity<HoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.SoHoaDon);

            entity.ToTable("HoaDonNhap");

            entity.HasIndex(e => e.MaNguoiDung, "IX_HoaDonNhap_MaNguoiDung");

            entity.Property(e => e.NgayNhap).HasColumnType("date");

            entity.HasOne(d => d.MaNguoiDungNavigation)
                .WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK_HoaDonNhap_AspNetUsers");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang);

            entity.ToTable("KhachHang");

            entity.Property(e => e.DiaChi).HasMaxLength(50);

            entity.Property(e => e.Email).HasMaxLength(50);

            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");

            entity.Property(e => e.TenKhachHang).HasMaxLength(50);
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.MaKho);

            entity.ToTable("Kho");

            entity.Property(e => e.DiaChi).HasMaxLength(50);

            entity.Property(e => e.TenKho).HasMaxLength(50);
        });

        modelBuilder.Entity<Loaisp>(entity =>
        {
            entity.HasKey(e => e.LoaiId)
                .HasName("PK__Loaisp__25B10ED8F4FCD793");

            entity.ToTable("Loaisp");

            entity.Property(e => e.LoaiId).HasColumnName("loai_id");

            entity.Property(e => e.LoaiName)
                .HasMaxLength(50)
                .HasColumnName("loai_name");
        });



        modelBuilder.Entity<Nhasx>(entity =>
        {
            entity.HasKey(e => e.NsxId)
                .HasName("PK__Nhasx__298823BF3D295D5C");

            entity.ToTable("Nhasx");

            entity.Property(e => e.NsxId).HasColumnName("nsx_id");

            entity.Property(e => e.Diachi)
                .HasMaxLength(50)
                .HasColumnName("diachi")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.NsxName)
                .HasMaxLength(50)
                .HasColumnName("nsx_name");

            entity.Property(e => e.Sdt)
                .HasColumnName("sdt")
                .HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<ProductComment>(entity =>
        {
            entity.ToTable("productComment");

            entity.HasIndex(e => e.MaNguoiDung, "IX_productComment_MaNguoiDung");

            entity.HasIndex(e => e.SanpId, "IX_productComment_sanp_id");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.NoiDung)
                .HasMaxLength(500)
                .HasColumnName("noiDung");

            entity.Property(e => e.SanpId).HasColumnName("sanp_id");

            entity.HasOne(d => d.MaNguoiDungNavigation)
                .WithMany(p => p.ProductComments)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK_productComment_AspNetUsers");

            entity.HasOne(d => d.Sanp)
                .WithMany(p => p.ProductComments)
                .HasForeignKey(d => d.SanpId)
                .HasConstraintName("FK__productCo__sanp___7D439ABD");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.SanpId)
                .HasName("PK__Sanpham__FBCD4D6E7BD38EE4");

            entity.ToTable("Sanpham");

            entity.HasIndex(e => e.LoaiId, "IX_Sanpham_loai_id");

            entity.HasIndex(e => e.NsxId, "IX_Sanpham_nsx_id");

            entity.Property(e => e.SanpId).HasColumnName("sanp_id");

            entity.Property(e => e.Battery)
                .HasMaxLength(50)
                .HasColumnName("battery");

            entity.Property(e => e.Card)
                .HasMaxLength(50)
                .HasColumnName("card");

            entity.Property(e => e.Cpu)
                .HasMaxLength(50)
                .HasColumnName("cpu");

            entity.Property(e => e.Display)
                .HasMaxLength(50)
                .HasColumnName("display");

            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .HasColumnName("image");

            entity.Property(e => e.LoaiId).HasColumnName("loai_id");

            entity.Property(e => e.Namsx)
                .HasColumnType("datetime")
                .HasColumnName("namsx");

            entity.Property(e => e.NsxId).HasColumnName("nsx_id");

            entity.Property(e => e.Ram)
                .HasMaxLength(50)
                .HasColumnName("ram");

            entity.Property(e => e.Rom)
                .HasMaxLength(50)
                .HasColumnName("rom");

            entity.Property(e => e.SanpName)
                .HasMaxLength(250)
                .HasColumnName("sanp_name");

            entity.Property(e => e.Tomtat)
                .HasMaxLength(2000)
                .HasColumnName("tomtat")
                .HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Loai)
                .WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.LoaiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sanpham__loai_id__7E37BEF6");

            entity.HasOne(d => d.Nsx)
                .WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.NsxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sanpham__nsx_id__7F2BE32F");
        });

        modelBuilder.Entity<Slide>(entity =>
        {
            entity.HasKey(e => e.MaSlide);

            entity.ToTable("Slide");

            entity.Property(e => e.Link).HasMaxLength(200);

            entity.Property(e => e.Slide1)
                .HasMaxLength(2000)
                .HasColumnName("Slide");
        });
        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);

        // Thêm đoạn code sau để xác định lại khóa chính cho IdentityUserLogin<string>
        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
