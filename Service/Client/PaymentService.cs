using Model.Models;
using Repository.Interface.Client;
using Service.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Client
{
    public class PaymentService:IPaymentService
    {
        private IPaymentRepository _repository;
        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ChiTietDonHang> CreateOrderDetail(ChiTietDonHang model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.CreateOrderDetail(model);
                if (result == null)
                {
                    throw new InvalidOperationException("Create operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while creating the entity.", ex);
            }
        }

        public async Task<DonHang> CreateOrder(DonHang model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.CreateOrder(model);
                if (result == null)
                {
                    throw new InvalidOperationException("Create operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while creating the entity.", ex);
            }
        }

        public async Task<KhachHang> CreateCustomer(KhachHang model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.CreateCustomer(model);
                if (result == null)
                {
                    throw new InvalidOperationException("Create operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while creating the entity.", ex);
            }
        }
        public async Task<(DonHang, KhachHang, List<ChiTietDonHang>)> AddOrder(KhachHang customer, List<ChiTietDonHang> orderDetail, int price)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "customer can not be null");
            }
            if (orderDetail == null)
            {
                throw new ArgumentNullException(nameof(orderDetail), "order detail can not be null");
            }
            try
            {
                var createCustomer = await CreateCustomer(customer);
                var order = new DonHang
                {
                    MaKhachHang = customer.MaKhachHang,
                    NgayDat = DateTime.Now,
                    ToTal = price,
                    TrangThai = "Chưa xác nhận",
                    TrangThaiGiaoHang = "Chưa giao hàng",
                    TrangThaiThanhToan = "Chưa thanh toán"
                };
                var createOrder = await CreateOrder(order);
                foreach (var item in orderDetail)
                {
                    item.MaDonHang = order.MaDonHang;
                    await CreateOrderDetail(item);
                }
                return (createOrder, createCustomer, orderDetail);

            }
            catch (Exception ex) { throw new Exception("Error occured while creating order", ex); }
        }

        public async Task<object> GetOrderByCustomerPhone(string phone, int index, int quantity)
        {
            if (index <= 0 || quantity <= 0 || phone == null)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.GetOrderByCustomerPhone(phone,index,quantity);
                if (result == null)
                {
                    throw new InvalidOperationException("GetAll operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get all entities", ex);
            }
        }
    }
}
