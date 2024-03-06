
using System;
using System.Collections.Generic;


namespace Models.Entities;

public partial class ProductComment
{
    public int Id { get; set; }
    public int? SanpId { get; set; }
    public string? MaNguoiDung { get; set; }
    public string? NoiDung { get; set; }

    public virtual ApplicationUser? MaNguoiDungNavigation { get; set; }
    public virtual Sanpham? Sanp { get; set; }
}
