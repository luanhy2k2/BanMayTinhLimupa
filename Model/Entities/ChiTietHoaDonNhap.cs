﻿using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class ChiTietHoaDonNhap
{
    public int MaChiTietHoaDonNhap { get; set; }
    public int? SoHoaDon { get; set; }
    public int? NsxId { get; set; }
    public int? SanpId { get; set; }
    public int? SoLuong { get; set; }
    public int? DonGia { get; set; }

    public virtual Nhasx? Nsx { get; set; }
    public virtual Sanpham? Sanp { get; set; }
    public virtual HoaDonNhap? SoHoaDonNavigation { get; set; }
}
