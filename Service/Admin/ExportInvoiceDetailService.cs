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
    public class ExportInvoiceDetailService : GenericService<ChiTietHoaDonBan>, IExportInvoiceDetailService
    {
        private IExportInvoiceDetailRepository _repository;
        private readonly IMapper _mapper;
        public ExportInvoiceDetailService(IExportInvoiceDetailRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ExportInvoiceDetailModel>> GetInvoiceDetailById(int id)
        {
            try
            {
                if(id <= 0)
                {
                    throw new ArgumentException("id không phù hợp");
                }
                var invoice = await _repository.GetInvoiceDetailById(id);
                var result = _mapper.Map<List<ChiTietHoaDonBan>, List<ExportInvoiceDetailModel>>(invoice);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while getting invoice",ex);
            }
        }
    }
}
