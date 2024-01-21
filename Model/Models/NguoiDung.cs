using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class NguoiDung
{
    public int MaNguoiDung { get; set; }

    public string? HoTen { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; } = new List<HoaDonBan>();

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; } = new List<HoaDonNhap>();
    public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; } = new List<TaiKhoan>();
}
