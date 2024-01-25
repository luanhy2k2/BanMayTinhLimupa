using Model.Models;
using Repository.Interface;
using Repository.Interface.Admin;
using Service.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin
{
    public class ExportInvoiceDetailService : GenericService<ChiTietHoaDonBan>, IExportInvoiceDetailService
    {
        private IExportInvoiceDetailRepository _repository;
        public ExportInvoiceDetailService(IExportInvoiceDetailRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
