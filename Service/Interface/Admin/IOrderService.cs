using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IOrderService:IGenericService<DonHang>
    {
        Task<Object> GetOrder(string phone, int pageIndex, int pageSize);
        Task<Object> GetOrderDetailById(int id);
        Task<Object> GetOrderById(int id);
        Task<DonHang> UpdateDelivery(int id, string delivery);
        Task<BaseQueryReponseModel<OrderModel>> GetAllOrder(int pageIndex, int pageSize);
        Task<List<ChiTietDonHang>> GetOrderDetail(int id);
        Task<List<ChiTietDonHang>> UpdateProductQuantity(List<ChiTietDonHang> orderDetails);
        Task<object> ConfirmOrder(int id);
        Task<DonHang> UpdatePaymentStatus(int id, string status);
        Task<DonHang> UpdateStatus(int id, string status);
    }
}
