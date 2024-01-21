using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.entity
{
    //public class ct
    //{
    //    public int sanpId { get; set; }
    //    public int gia { get; set; }
    //    public int quantity { get; set; }
    //}
    public class CreateDonHang
    {
        public KhachHang customer { get; set; }
 
        public List<ChiTietDonHang> orderDetails { get; set; }
        public int total { get; set; }
    }
    
    public class GetOrder
    {
        public KhachHang khach { get; set; }
        public List<DonHang> donHang { get; set; }

    }
    
}
