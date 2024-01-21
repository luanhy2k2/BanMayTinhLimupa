using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.entity
{
   
    public class ProductDetail
    {
        public int SanpId { get; set; }

        public string SanpName { get; set; } = null!;

        public int LoaiId { get; set; }

        public int NsxId { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public string Cpu { get; set; }
        public string Display { get; set; }
        public string Battery { get; set; }
        public string Card { get; set; }
        public string Tomtat { get; set; } = null!;

        public DateTime? Namsx { get; set; }

        public string? Image { get; set; }

        public int gia { get; set; }
    }
}
