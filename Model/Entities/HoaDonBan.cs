﻿using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class HoaDonBan
{
    public int SoHoaDon { get; set; }

    public DateTime? NgayBan { get; set; }

    public int? MaKhachHang { get; set; }

    public int? ToTal { get; set; }

    public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; } = new List<ChiTietHoaDonBan>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }
}
