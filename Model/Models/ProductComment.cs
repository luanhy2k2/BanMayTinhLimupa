using System;
using System.Collections.Generic;


namespace Model.Models;

public partial class ProductComment
{
    public int Id { get; set; }

    public int? SanpId { get; set; }

    public int? MaNguoiDung { get; set; }

    public string? NoiDung { get; set; }

    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }

    public virtual Sanpham? Sanp { get; set; }
}
