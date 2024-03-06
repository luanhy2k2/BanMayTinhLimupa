using Data.Entities;
using Repository.Interface.Client;
using Service.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Client
{
    public interface IPaymentService 
    {
        Task<DonHang> CreateOrder(DonHang model);
        Task<KhachHang> CreateCustomer(KhachHang model);
        Task<ChiTietDonHang> CreateOrderDetail(ChiTietDonHang model);
        Task<Object> GetOrderByCustomerPhone(string phone, int index, int quantity);
        Task<(DonHang, KhachHang, List<ChiTietDonHang>)> AddOrder(KhachHang customer, List<ChiTietDonHang> orderDetail, int price);

    }
}
