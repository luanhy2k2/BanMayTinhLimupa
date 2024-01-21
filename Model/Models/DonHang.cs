using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class DonHang
{
    public int MaDonHang { get; set; }

    public DateTime? NgayDat { get; set; }

    public string? TrangThai { get; set; }

    public int? ToTal { get; set; }

    public int? MaKhachHang { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; } = new List<ChiTietDonHang>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }
}
