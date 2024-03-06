using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class ChiTietAnh
{
    public int MaAnhChiTiet { get; set; }

    public int? SanpId { get; set; }

    public string? Anh { get; set; }

    public virtual Sanpham? Sanp { get; set; }
}
