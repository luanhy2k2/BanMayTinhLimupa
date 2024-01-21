using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class ChiTietHoaDonNhap
{
    public int MaChiTietHoaDonNhap { get; set; }

    public int? SoHoaDon { get; set; }

    public int? SanpId { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGia { get; set; }

    public virtual Sanpham? Sanp { get; set; }

    public virtual HoaDonNhap? SoHoaDonNavigation { get; set; }
}
