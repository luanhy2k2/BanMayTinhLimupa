using Model.Models.entity;
using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class HoaDonNhap
{
    public HoaDonNhap()
    {
        ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
    }

    public int SoHoaDon { get; set; }
    public DateTime? NgayNhap { get; set; }
    public string? MaNguoiDung { get; set; }
    public int? ToTal { get; set; }

    public virtual ApplicationUser? MaNguoiDungNavigation { get; set; }
    public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
}
