using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Admin
{
    public interface IExportInvoiceDetailRepository:IGenericRespository<ChiTietHoaDonBan>
    { 
        public Task<List<ChiTietHoaDonBan>> GetInvoiceDetailById(int id);
    }
}
