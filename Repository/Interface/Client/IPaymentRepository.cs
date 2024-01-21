using Model.Models;
using Model.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Client
{
    public interface IPaymentRepository
    {
        Task<DonHang> CreateOrder(DonHang model);
        Task<KhachHang> CreateCustomer(KhachHang model);
        Task<ChiTietDonHang> CreateOrderDetail(ChiTietDonHang model);
        Task<Object> GetOrderByCustomerPhone(string phone, int index, int quantity);

    }
}
