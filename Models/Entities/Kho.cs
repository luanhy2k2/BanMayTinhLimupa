using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class Kho
{
    public int MaKho { get; set; }

    public string? TenKho { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<ChiTietKho> ChiTietKhos { get; set; } = new List<ChiTietKho>();
}
