using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OrderModel
    {
        public int MaDonHang {  get; set; }
        public DateTime NgayDat {  get; set; }
        public string TrangThai {  get; set; }
        public string TrangThaiThanhToan {  get; set; }
        public string TrangThaiGiaoHang {  get; set; }
        public string Email {  get; set; }
        public int MaKhachHang {  get; set; }
        public string Sdt {  get; set; }
        public string DiaChi {  get; set; }
        public int ToTal {  get; set; }
        public string TenKhachHang { get; set; }
     
        
    }
}
