using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IExportInvoiceDetailService:IGenericService<ChiTietHoaDonBan>
    {
        public Task<List<ExportInvoiceDetailModel>> GetInvoiceDetailById(int id);
    }
}
