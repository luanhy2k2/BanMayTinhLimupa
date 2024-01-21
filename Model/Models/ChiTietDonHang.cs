using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class ChiTietDonHang
{
    public int MaChiTietDonHang { get; set; }

    public int? MaDonHang { get; set; }

    public int? SanpId { get; set; }

    public int? SoLuong { get; set; }

    public int? GiaMua { get; set; }

    public virtual DonHang? MaDonHangNavigation { get; set; }

    public virtual Sanpham? Sanp { get; set; }
}
