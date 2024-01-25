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
    public class ExportInvoiceService : GenericService<HoaDonBan>, IExportInvoiceService
    {
        private IExportInvoiceRepository _repository;
        public ExportInvoiceService(IExportInvoiceRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
