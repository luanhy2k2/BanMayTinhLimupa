using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class Nhasx
{
    public Nhasx()
    {
        ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
        Sanphams = new HashSet<Sanpham>();
    }

    public int NsxId { get; set; }
    public string NsxName { get; set; } = null!;
    public string? Diachi { get; set; }
    public int? Sdt { get; set; }

    public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
    public virtual ICollection<Sanpham> Sanphams { get; set; }
}
