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
    public class ProductDetailRepository : IProductDetailRepository
    {
        private QuanlybanhangContext _dbContext;
        public ProductDetailRepository(QuanlybanhangContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductComment> AddComment(ProductComment comment)
        {
            try
            {
                var query = await _dbContext.ProductComment.AddAsync(comment);
                await _dbContext.SaveChangesAsync();
                return comment;
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<object> GetAllComment(int idProduct, int index, int quantity)
        {
            try
            {
                var query = _dbContext.ProductComment.Where(x => x.SanpId == idProduct);
                var data = await query.Skip((index - 1) * quantity).Take(quantity).ToListAsync();
                var totalCount = await query.CountAsync();
                return new { results = data, total = totalCount };
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<object> GetProductById(int id)
        {
            try
            {
                var query = from sp in _dbContext.Sanpham join gia in _dbContext.GiaCa on sp.SanpId equals gia.SanpId
                            join loaisp in _dbContext.Loaisp on sp.LoaiId equals loaisp.LoaiId
                            join nsx in _dbContext.Nhasx on sp.NsxId equals nsx.NsxId
                            select new
                            {
                                sp.SanpId, sp.SanpName, sp.Cpu, sp.Battery, sp.Card, sp.Ram, sp.Rom, sp.Display,
                                nsx.NsxName, gia.Gia, loaisp.LoaiName, sp.Image, sp.Tomtat, sp.Namsx
                            };
                var result = await query.FirstOrDefaultAsync(x => x.SanpId == id);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
