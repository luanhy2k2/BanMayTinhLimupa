using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class GiaCa
{
    public int MaSo { get; set; }

    public int? SanpId { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public int? Gia { get; set; }

    public virtual Sanpham? Sanp { get; set; }
}
