using Application.Models;
using AutoMapper;
using Data.Entities;
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
        private readonly IExportInvoiceRepository _repository;
        private readonly IMapper _mapper;
        public ExportInvoiceService(IExportInvoiceRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseQueryReponseModel<ExportInvoiceModel>> Get(int pageIndex, int pageSize)
        {
            try
            {
                var Invoice = await _repository.Get(pageIndex, pageSize);
                var InvoiceViewModel = _mapper.Map<List<HoaDonBan>, List<ExportInvoiceModel>>(Invoice.Items);
                var result = new BaseQueryReponseModel<ExportInvoiceModel>
                {
                    Items = InvoiceViewModel,
                    PageIndex = Invoice.PageIndex,
                    PageSize = Invoice.PageSize,
                    Total = Invoice.Total
                };
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while getting inovice", ex);
            }
        }

        public async Task<ExportInvoiceModel> GetById(int id)
        {
            try
            {
                var Invoice = await _repository.getById(id);
                var InvoiceViewModel = _mapper.Map<HoaDonBan, ExportInvoiceModel>(Invoice);
                return InvoiceViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting inovice", ex);
            }
        }
    }
}
