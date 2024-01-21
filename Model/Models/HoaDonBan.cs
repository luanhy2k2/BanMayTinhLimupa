using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class HoaDonBan
{
    public int SoHoaDon { get; set; }

    public DateTime? NgayBan { get; set; }

    public int? MaNguoiDung { get; set; }

    public int? ToTal { get; set; }

    public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; } = new List<ChiTietHoaDonBan>();

    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
}
