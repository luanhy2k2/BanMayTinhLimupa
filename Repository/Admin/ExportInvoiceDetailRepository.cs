using Model.Models;
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
        public ExportInvoiceDetailRepository(QuanlybanhangContext dbContext) : base(dbContext)
        {
        }
    }
}
