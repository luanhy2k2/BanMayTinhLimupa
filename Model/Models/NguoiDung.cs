using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class NguoiDung
{
    public NguoiDung()
    {
        TaiKhoans = new HashSet<TaiKhoan>();
    }

    public int MaNguoiDung { get; set; }
    public string? HoTen { get; set; }
    public DateTime? NgaySinh { get; set; }
    public string? GioiTinh { get; set; }
    public string? DiaChi { get; set; }
    public string? Email { get; set; }
    public string? Sdt { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
}
