using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class KhachHang
{
    public int MaKhachHang { get; set; }

    public string? TenKhachHang { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }
    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
