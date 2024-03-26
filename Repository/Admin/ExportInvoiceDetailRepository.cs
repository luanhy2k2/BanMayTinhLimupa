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
    public class ExportInvoiceDetailRepository : GenericRespository<ChiTietHoaDonBan>, IExportInvoiceDetailRepository
    {
        private readonly QuanlybanhangContext _conext;
        public ExportInvoiceDetailRepository(QuanlybanhangContext dbContext) : base(dbContext)
        {
            _conext = dbContext;
        }
        public async Task<List<ChiTietHoaDonBan>> GetInvoiceDetailById(int id)
        {
            try
            {
                var result = await _conext.ChiTietHoaDonBan.Include(x => x.Sanp).Include(x=>x.Sanp.GiaCas)
                    .Where(x => x.SoHoaDon == id).ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }
    }
}
