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

        public async Task<object> GetOrder(int id,int pageIndex, int pageSize)
        {
            try
            {

                var query = await _dbContext.KhachHang.Where(x => x.MaKhachHang == id).SelectMany(x=>x.DonHangs).Include(x=>x.ChiTietDonHangs).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
    }
}
