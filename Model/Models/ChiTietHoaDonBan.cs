using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class ChiTietHoaDonBan
{
    public int MaChiTietHoaDonBan { get; set; }

    public int? SoHoaDon { get; set; }

    public int? SanpId { get; set; }

    public int? SoLuong { get; set; }

    public int? GiaBan { get; set; }

    public virtual Sanpham? Sanp { get; set; }

    public virtual HoaDonBan? SoHoaDonNavigation { get; set; }
}
