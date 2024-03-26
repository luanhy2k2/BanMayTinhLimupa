using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ExportInvoiceModel
    {
        public int SoHoaDon {  get; set; }
        public DateTime NgayBan { get; set; }
        public int MaKhachHang { get; set; }
        public string TenKhachHang {  get; set; }
        public string DiaChi { get; set; }
        public string Phone {  get; set; }
        public string Email {  get; set; }
        public int ToTal {  get; set; }
    }
    public class ExportInvoiceDetailModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string SanpName { get; set; }
        public int SanpId { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
}
