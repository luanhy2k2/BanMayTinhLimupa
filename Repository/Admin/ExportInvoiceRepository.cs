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
    public class ExportInvoiceRepository : GenericRespository<HoaDonBan>, IExportInvoiceRepository
    {
        private readonly QuanlybanhangContext _context;
        public ExportInvoiceRepository(QuanlybanhangContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<BaseQueryReponseModel<HoaDonBan>> Get(int pageIndex, int pageSize)
        {
            try
            {
                var query = await _context.HoaDonBan
                    .Include(x => x.MaKhachHangNavigation).ToListAsync();
                var result = new BaseQueryReponseModel<HoaDonBan>
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Items = query,
                    Total = query.Count()
                };
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }
        public override async Task<HoaDonBan> getById(int id)
        {
            try
            {
                var result = await _context.HoaDonBan.Include(x=>x.MaKhachHangNavigation).FirstOrDefaultAsync(x => x.SoHoaDon == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }
    }
}
