using Microsoft.EntityFrameworkCore;
using Model.Models;
using Repository.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Client
{
    public class HomePageRepository : IHomePageRepository
    {
        private QuanlybanhangContext _dbContext;
        public HomePageRepository(QuanlybanhangContext _dbContextContext)
        {
            _dbContext = _dbContextContext;
        }
        public async Task<object> SellingProduct(int index, int quantity)
        {
            try
            {
                var query = from sanPham in _dbContext.Sanpham
                            join chiTietHoaDonBan in _dbContext.ChiTietHoaDonBan on sanPham.SanpId equals chiTietHoaDonBan.SanpId
                            join giaCa in _dbContext.GiaCa on sanPham.SanpId equals giaCa.SanpId
                            group new
                            {
                                chiTietHoaDonBan,
                                sanPham,
                                giaCa
                            } by new
                            {
                                chiTietHoaDonBan.SanpId,
                                sanPham.SanpName,
                                sanPham.LoaiId,
                                sanPham.NsxId,
                                sanPham.Tomtat,
                                sanPham.Namsx,
                                sanPham.Image,
                                giaCa.Gia
                            } into g
                            select new
                            {
                                g.Key.SanpId,
                                g.Key.SanpName,
                                g.Key.LoaiId,
                                g.Key.NsxId,
                                g.Key.Tomtat,
                                g.Key.Namsx,
                                g.Key.Image,
                                g.Key.Gia,
                                SL = g.Sum(x => x.chiTietHoaDonBan.SoLuong)
                            }
                            into grouped
                            orderby grouped.SL descending
                            select grouped;
                var data = await query.Skip((index - 1) * quantity).Take(quantity).ToListAsync();
                var totalCount = await query.CountAsync();
                return new { results = data, total = totalCount };
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<object> NewProduct(int index, int quantity)
        {
            try
            {
                var query = from cthdn in _dbContext.ChiTietHoaDonNhap
                            join sp in _dbContext.Sanpham on cthdn.SanpId equals sp.SanpId
                        join hdn in _dbContext.HoaDonNhap on cthdn.SoHoaDon equals hdn.SoHoaDon join gia in _dbContext.GiaCa on sp.SanpId equals gia.SanpId
                        group new
                        {
                            cthdn, hdn, sp
                        }
                        by new
                        {
                            sp.SanpId, sp.SanpName, sp.Image, 
                            sp.Namsx,sp.Card,sp.Cpu,sp.Ram,sp.Rom,
                            sp.Display,sp.Battery, gia.Gia, hdn.NgayNhap

                         } into g
                         select new
                         {
                             g.Key.SanpId, g.Key.SanpName,
                             g.Key.Namsx,
                             g.Key.Card,
                             g.Key.Cpu,
                             g.Key.Ram,
                             g.Key.Rom,
                             g.Key.Display,
                             g.Key.Battery, g.Key.Image, g.Key.Gia, g.Key.NgayNhap
                          }
                          into grouped orderby grouped.NgayNhap descending
                          select grouped;

                var data = await query.Skip((index - 1) * quantity).Take(quantity).ToListAsync();
                var totalCount = await query.CountAsync();
                return new { results = data, total = totalCount };
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<Object> GetProductByCategory(int categoryId, int pageIndex, int pageSize)
        {
            try
            {
                var query = _dbContext.Sanpham.Where(x => x.LoaiId == categoryId);
                var data = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var totalCount = await query.CountAsync();
                return new { results = data, total = totalCount };
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<Object> GetProductByCompany(int companyId, int pageIndex, int pageSize)
        {
            try
            {
                var query = _dbContext.Sanpham.Where(x => x.NsxId == companyId);
                var data = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var totalCount = await query.CountAsync();
                return new { results = data, total = totalCount };
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        public async Task<List<Sanpham>> GetFilteredProducts(string[] ram, string[] rom)
        {
            var query = _dbContext.Sanpham.AsQueryable();

            if (ram != null && ram.Any())
            {
                query = query.Where(p => ram.Contains(p.Ram));
            }

            if (rom != null && rom.Any())
            {
                query = query.Where(p => rom.Contains(p.Rom));
            }

            var result = await query.ToListAsync();
            return result;
        }
    }
}
