using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductModel
    {
        public int SanpId { get; set; }
        public string SanpName { get; set; }
       
        public string LoaiName { get; set; }    
      
        public string NsxName { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public string Cpu { get; set; }
        public int Price { get; set; }
        public string Display { get; set; }
        public string Battery { get; set; }
        public string Card { get; set; }
        public int Quantity {  get; set; }
     
        public DateTime? Namsx { get; set; }

        public string? Image { get; set; }
    }
}
