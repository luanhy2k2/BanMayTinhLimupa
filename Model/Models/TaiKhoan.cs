using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class TaiKhoan
{
    public int MaTaiKhoan { get; set; }

    public int? MaNguoiDung { get; set; }

    public string? TaiKhoan1 { get; set; }

    public string? MatKhau { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? TrangThai { get; set; }

    public string? LoaiQuyen { get; set; }

    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
}
