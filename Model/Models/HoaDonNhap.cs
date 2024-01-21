using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class HoaDonNhap
{
    public int SoHoaDon { get; set; }

    public DateTime? NgayNhap { get; set; }

    public int? MaNguoiDung { get; set; }

    public int? NsxId { get; set; }

    public int? ToTal { get; set; }

    public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; } = new List<ChiTietHoaDonNhap>();

    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }

    public virtual Nhasx? Nsx { get; set; }
}
