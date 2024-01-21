using Microsoft.EntityFrameworkCore;
using Model.Models;
using Model.Models.entity;
using Repository.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Admin
{
    public class ProductRepository : GenericRespository<Sanpham>, IProductRepository
    {
        private readonly QuanlybanhangContext _db;
        public ProductRepository(QuanlybanhangContext _dbContext) : base(_dbContext)
        {
            _db = _dbContext;
        }

        public async Task<ProductDetail> CreateProduct(ProductDetail model)
        {
            try
            {
                var product = new Sanpham
                {
                    SanpName = model.SanpName,
                    Ram = model.Ram,
                    Rom = model.Rom,
                    Display = model.Display,
                    Card = model.Card,
                    Battery = model.Battery,
                    Cpu = model.Cpu,
                    Namsx = model.Namsx,
                    LoaiId = model.LoaiId,
                    NsxId = model.NsxId,
                    Image = model.Image,
                    Tomtat = model.Tomtat
                };
                await _db.Sanpham.AddAsync(product);
                await _db.SaveChangesAsync();
                var price = new GiaCa
                {
                    Gia = model.gia,
                    SanpId = model.SanpId,
                    NgayBatDau = DateTime.Now
                };
                await _db.GiaCa.AddAsync(price);
                await _db.SaveChangesAsync();
                return model;
            }
            catch(Exception ex)
            {
                throw new Exception("error", ex);
            }
        }

        public async Task<object> getProduct(int pageIndex, int pageSize)
        {
            try
            {
                var query = from sp in _db.Sanpham
                            join gia in _db.GiaCa on sp.SanpId equals gia.SanpId
                            join loai in _db.Loaisp on sp.LoaiId equals loai.LoaiId
                            join nsx in _db.Nhasx on sp.NsxId equals nsx.NsxId
                            select new
                            {
                                sp.SanpId,
                                sp.SanpName,
                                sp.Image,
                                sp.Ram,
                                sp.Rom,
                                sp.Card,
                                sp.Display,
                                sp.Cpu,
                                sp.Battery,
                                sp.Namsx,
                                nsx.NsxName,
                                loai.LoaiName,
                                gia.Gia,
                                sp.LoaiId,
                                sp.NsxId
                            };

                // Apply paging
                var paginatedResult = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

                // You might also want to return the total count for client-side pagination
                var totalCount = await query.CountAsync();

                return new { TotalCount = totalCount, results = paginatedResult };
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw new Exception("An error occurred while fetching products.", ex);
            }
        }
        public async Task<Object> getProductbyId(int id)
        {
            try
            {
                var query = from sp in _db.Sanpham
                            join gia in _db.GiaCa on sp.SanpId equals gia.SanpId
                            select new
                            {
                                sp.SanpId,
                                sp.SanpName,
                                sp.Image,
                                sp.Ram,
                                sp.Rom,
                                sp.Card,
                                sp.Display,
                                sp.Cpu,
                                sp.Battery,
                                sp.Namsx,
                                sp.NsxId,
                                sp.LoaiId,
                               sp.Tomtat,
                                gia.Gia,
                              
                            };

                // Apply paging
                var result = await query.FirstOrDefaultAsync(x => x.SanpId == id);
                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw new Exception("An error occurred while fetching products.", ex);
            }
        }

        

        public async Task<object> searchProduct(string name, int pageIndex, int pageSize)
        {
            try
            {
                var query = from sp in _db.Sanpham
                            join gia in _db.GiaCa on sp.SanpId equals gia.SanpId
                            join loai in _db.Loaisp on sp.LoaiId equals loai.LoaiId
                            join nsx in _db.Nhasx on sp.NsxId equals nsx.NsxId
                            select new
                            {
                                sp.SanpId,
                                sp.SanpName,
                                sp.Image,
                                sp.Ram,
                                sp.Rom,
                                sp.Card,
                                sp.Display,
                                sp.Cpu,
                                sp.Battery,
                                sp.Namsx,
                                nsx.NsxName,
                                loai.LoaiName,
                                gia.Gia,
                                sp.LoaiId,
                                sp.NsxId
                            };
                var model = query.Where(x => x.SanpName.Contains(name)); 
                var result = await model.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var totalCount = await model.CountAsync();
                return new { results = result, total = totalCount };
            }
            catch(Exception ex)
            {
                throw new Exception("err", ex);
            }
        }

        public async Task<ProductDetail> UpdateProduct(ProductDetail model)
        {
            try
            {
                var product = await _db.Sanpham.FirstOrDefaultAsync(x => x.SanpId == model.SanpId);
                product.SanpName = model.SanpName;
                product.Namsx = model.Namsx;
                product.Ram = model.Ram;
                product.NsxId = model.NsxId;
                product.Rom = model.Rom;
                product.Display = model.Display;
                product.Image = model.Image;
                product.Battery = model.Battery;
                product.Cpu = model.Cpu;
                product.Card = model.Card;
                product.LoaiId = model.LoaiId;
                product.Tomtat = model.Tomtat;
                await _db.SaveChangesAsync();
                var price = await _db.GiaCa.FirstOrDefaultAsync(x => x.SanpId == model.SanpId);
                price.Gia = model.gia;
                await _db.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
    }
}
