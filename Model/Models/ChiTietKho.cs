using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class ChiTietKho
{
    public int MaChiTietKho { get; set; }

    public int? MaKho { get; set; }

    public int? SanpId { get; set; }

    public int? SoLuong { get; set; }

    public virtual Kho? MaKhoNavigation { get; set; }

    public virtual Sanpham? Sanp { get; set; }
}
