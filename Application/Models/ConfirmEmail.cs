﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ConfirmEmail
    {
        public string userId { get; set; }
        public string code { get; set; }
    }
}
