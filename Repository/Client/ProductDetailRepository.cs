using Application.Models;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Sanpham> GetProductById(int id)
        {
            try
            {
                var query =  _dbContext.Sanpham.
                    Include(g => g.GiaCas).
                    Include(l => l.Loai).
                    Include(n =>n.Nsx).
                    FirstOrDefaultAsync(x => x.SanpId == id);
                var result = await query;
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
