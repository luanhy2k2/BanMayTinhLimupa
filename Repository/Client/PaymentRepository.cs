using Microsoft.EntityFrameworkCore;
using Model.Models;
using Model.Models.entity;
using Repository.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Client
{
    public class PaymentRepository : IPaymentRepository
    {
        private QuanlybanhangContext _dbContext;
        public PaymentRepository(QuanlybanhangContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ChiTietDonHang> CreateOrderDetail(ChiTietDonHang model)
        {
            try
            {
                var query = await _dbContext.ChiTietDonHang.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<DonHang> CreateOrder(DonHang model)
        {
            try
            {
                var query = await _dbContext.DonHang.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<KhachHang> CreateCustomer(KhachHang model)
        {
            try
            {
                var query = await _dbContext.KhachHang.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        public async Task<Object> GetOrderByCustomerPhone(string phone, int index, int quantity)
        {
            try
            {
                var getOrder = from order in _dbContext.DonHang join customer in _dbContext.KhachHang
                            on order.MaKhachHang equals customer.MaKhachHang
                            select new
                            {
                                order.MaDonHang, order.NgayDat, order.TrangThai,
                                customer.DiaChi, customer.TenKhachHang, customer.Email, customer.Sdt,

                            };
                var getOrderDetail = from order in _dbContext.DonHang
                                     join orderDetail in _dbContext.ChiTietDonHang
                                     on order.MaDonHang equals orderDetail.MaDonHang
                                     join product in _dbContext.Sanpham
                                     on orderDetail.SanpId equals product.SanpId
                                     select new
                                     {
                                         orderDetail.SoLuong,
                                         orderDetail.GiaMua,
                                         product.SanpName,
                                         product.SanpId,
                                         product.Image
                                     };
                var query = getOrder.Where(x => x.Sdt == phone);
                var orderDetails = getOrder.Where(x => x.Sdt == phone);
                var result = await query.Skip((index-1)*quantity).Take(quantity).ToListAsync();
                var results = await orderDetails.Skip((index - 1) * quantity).Take(quantity).ToListAsync();
                var totalCount = await query.CountAsync();
                return new { resuls = result, orderDetail = results, total = totalCount };
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
