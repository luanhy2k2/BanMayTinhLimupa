using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IExportInvoiceService:IGenericService<HoaDonBan>
    {
        public Task<BaseQueryReponseModel<ExportInvoiceModel>> Get(int pageIndex, int pageSize);
        public Task<ExportInvoiceModel> GetById(int id);
    }
}
