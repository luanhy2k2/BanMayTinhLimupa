using Data;
using Data.Entities;
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
        public ExportInvoiceRepository(QuanlybanhangContext dbContext) : base(dbContext)
        {
        }
    }
}
