using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Admin
{
    public interface IOrderRepository:IGenericRespository<DonHang>
    {
        Task<Object> GetAllOrder(int pageIndex, int pageSize);
        Task<Object> GetOrderById(int id);
        Task<Object> GetOrderDetailById(int id);
        Task<Object> GetOrder(string phone, int pageIndex, int pageSize );
        Task<List<ChiTietDonHang>> GetOrderDetail(int id);
        Task<List<ChiTietDonHang>> UpdateProductQuantity(List<ChiTietDonHang> orderDetails);
        Task<DonHang> UpdateStatus(int id,string status);
        Task<DonHang> UpdateDelivery(int id, string delivery);
        Task<DonHang> UpdatePaymentStatus(int id, string status);

    }
}
