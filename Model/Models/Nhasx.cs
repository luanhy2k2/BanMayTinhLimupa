using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class Nhasx
{
    public int NsxId { get; set; }

    public string NsxName { get; set; } = null!;

    public string? Diachi { get; set; }

    public int? Sdt { get; set; }

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; } = new List<HoaDonNhap>();

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
