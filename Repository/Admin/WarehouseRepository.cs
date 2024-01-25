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
    public class WarehouseRepository : GenericRespository<ChiTietKho>, IWareHouseRepository
    {
        private QuanlybanhangContext _db;
        public WarehouseRepository(QuanlybanhangContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<object> GetWarehouse(int pageIndex, int pageSize)
        {
            try
            {
                var query = from product in _db.Sanpham join warehouse in _db.ChiTietKho
                            on product.SanpId equals warehouse.SanpId
                            select new
                            {
                                product.SanpId, product.SanpName, product.Image, warehouse.SoLuong
                            };
                var result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var total = await query.CountAsync();
                return new { results = result, totalCount = total };
            }
            catch(Exception ex)
            {
                throw new Exception("Error while working in database", ex);
            }
        }
    }
}
