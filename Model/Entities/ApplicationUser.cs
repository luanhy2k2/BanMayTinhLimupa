﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string hoTen { get; set; } = null!;
        public string address { get; set; } = null!;
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual ICollection<ProductComment> ProductComments { get; set; }
    }
}
