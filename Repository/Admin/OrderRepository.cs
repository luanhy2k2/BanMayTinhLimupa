using Microsoft.EntityFrameworkCore;
using Model.Models;
using Repository.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Admin
{
    public class OrderRepository : GenericRespository<DonHang>, IOrderRepository
    {
        private QuanlybanhangContext _dbContext;
        public OrderRepository(QuanlybanhangContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<object> GetOrder(string phone,int pageIndex, int pageSize)
        {
            try
            {

                var query = from order in _dbContext.DonHang 
                            join customer in _dbContext.KhachHang on order.MaKhachHang equals customer.MaKhachHang
                          
                            select new
                            {
                                order.MaDonHang,
                                order.TrangThai,
                                order.TrangThaiGiaoHang,
                                order.TrangThaiThanhToan,
                                order.NgayDat,
                                chiTietDonHangs = order.ChiTietDonHangs.Select(c => new
                                {
                                    maChiTietDonHang = c.MaChiTietDonHang,
                                    maDonHang = c.MaDonHang,
                                    sanp = new
                                    {
                                        sanpId = c.Sanp.SanpId,
                                        sanpName = c.Sanp.SanpName,
                                        image = c.Sanp.Image
                                        // Thêm các thuộc tính khác của SanPham bạn muốn trả về
                                    },
                                    soLuong = c.SoLuong,
                                    giaMua = c.GiaMua,
                                }),
                                customer.DiaChi,
                                customer.TenKhachHang,
                                customer.Sdt,
                                customer.Email
                            };
                var data = query.Where(x => x.Sdt == phone);
                var result = await data.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var totalCount = await data.CountAsync();
                return new {results = result, total = totalCount };
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        public async Task<DonHang> UpdateStatus(int id, string status)
        {
            try
            {
                var query = await _dbContext.DonHang.FirstOrDefaultAsync(x => x.MaDonHang == id);
                query.TrangThai = status;
                await _dbContext.SaveChangesAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }

        public async Task<List<ChiTietDonHang>> GetOrderDetail(int id)
        {
            try
            {
                var query = await _dbContext.ChiTietDonHang.Where(x => x.MaDonHang == id).ToListAsync();
                return query;
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<List<ChiTietDonHang>> UpdateProductQuantity(List<ChiTietDonHang> orderDetail)
        {
            try
            {
                foreach(var item in orderDetail)
                {
                    var productQuantity = await _dbContext.ChiTietKho.FirstOrDefaultAsync(x => x.SanpId == item.SanpId);
                    productQuantity.SoLuong = productQuantity.SoLuong - item.SoLuong;
                    await _dbContext.SaveChangesAsync();
                }
                return orderDetail;
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        public async Task<object> GetOrderDetailById(int id)
        {
            try
            {
                var query = from orderDetail in _dbContext.ChiTietDonHang
                            join product in _dbContext.Sanpham
                            on orderDetail.SanpId equals product.SanpId
                            select new
                            {
                               orderDetail.SanpId, orderDetail.MaDonHang, orderDetail.MaChiTietDonHang, orderDetail.SoLuong,
                               orderDetail.GiaMua, product.SanpName, product.Image
                            };
                var data = await query.Where(x =>x.MaDonHang == id).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<object> GetOrderById(int id)
        {
            try
            {
                var query = from order in _dbContext.DonHang
                            join customer in _dbContext.KhachHang
                            on order.MaKhachHang equals customer.MaKhachHang
                            select new
                            {
                                order.MaDonHang,
                                order.NgayDat,
                                order.TrangThai,
                                order.TrangThaiThanhToan,
                                order.TrangThaiGiaoHang,
                                customer.Email,
                                customer.MaKhachHang,
                                customer.Sdt,
                                customer.DiaChi,
                                order.ToTal,
                                customer.TenKhachHang
                            };
                var data = await query.FirstOrDefaultAsync(x=>x.MaDonHang == id);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<object> GetAllOrder(int pageIndex, int pageSize)
        {
            try
            {
                var query = from order in _dbContext.DonHang join customer in _dbContext.KhachHang
                            on order.MaKhachHang equals customer.MaKhachHang
                            select new
                            {
                                order.MaDonHang, order.NgayDat, order.TrangThaiGiaoHang, order.TrangThai, order.TrangThaiThanhToan,
                                order.ToTal, customer.TenKhachHang
                            };
                var data = await query.OrderByDescending(x=>x.MaDonHang).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var totalCount = await query.CountAsync();
                return new { results = data, total = totalCount };
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task<DonHang> UpdateDelivery(int id, string delivery)
        {
            try
            {
                var order = await _dbContext.DonHang.FirstOrDefaultAsync(x => x.MaDonHang == id);
                order.TrangThaiGiaoHang = delivery;
                await _dbContext.SaveChangesAsync();
                return order;
            }
            catch(Exception ex)
            {
                throw new Exception("error when manipulating database", ex);
            }
        }

        public async Task<DonHang> UpdatePaymentStatus(int id, string status)
        {
            try
            {
                var order = await _dbContext.DonHang.FirstOrDefaultAsync(x => x.MaDonHang == id);
                order.TrangThaiThanhToan = status;
                await _dbContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception("error when manipulating database", ex);
            }
        }
    }
}
