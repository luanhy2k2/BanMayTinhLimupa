using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Admin
{
    public interface IExportInvoiceRepository:IGenericRespository<HoaDonBan>
    {
        public Task<BaseQueryReponseModel<HoaDonBan>> Get(int pageIndex, int pageSize);
    }
}
