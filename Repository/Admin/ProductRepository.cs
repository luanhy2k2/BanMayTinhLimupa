using Application.Models;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ProductDetailModel> CreateProduct(ProductDetailModel model)
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
                    Gia = model.Price,
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

        public async Task<BaseQueryReponseModel<Sanpham>> getProduct(int pageIndex, int pageSize)
        {
            try
            {
                // Apply paging
                var query = _db.Sanpham.Include(g => g.GiaCas).Include(l => l.Loai).Include(n => n.Nsx);
                var paginatedResult = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

                // You might also want to return the total count for client-side pagination
                var totalCount = await query.CountAsync();
                var result = new BaseQueryReponseModel<Sanpham>
                {
                    Total = totalCount,
                    Items = paginatedResult,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw new Exception("An error occurred while fetching products.", ex);
            }
        }
        public async Task<Sanpham> getProductbyId(int id)
        {
            try
            {
                var query = _db.Sanpham.Include(g => g.GiaCas).Include(l => l.Loai).Include(n => n.Nsx);
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

        

        public async Task<BaseQueryReponseModel<Sanpham>> searchProduct(string name, int pageIndex, int pageSize)
        {
            try
            {
                var query = _db.Sanpham.Include(g => g.GiaCas).Include(l => l.Loai).Include(n => n.Nsx);
                var model = query.Where(x => x.SanpName.Contains(name)); 
                var result = await model.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var totalCount = await model.CountAsync();
                return new BaseQueryReponseModel<Sanpham>
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Items = result,
                    Total = totalCount
                };
            }
            catch(Exception ex)
            {
                throw new Exception("err", ex);
            }
        }
      

        public async Task<ProductDetailModel> UpdateProduct(ProductDetailModel model)
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
                price.Gia = model.Price;
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
