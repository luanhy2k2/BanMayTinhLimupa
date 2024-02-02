﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.entity
{
    public class ApplicationUser:IdentityUser
    {
        public string hoTen { get; set; } = null!;
        public string address { get; set; } = null!;

    }
}