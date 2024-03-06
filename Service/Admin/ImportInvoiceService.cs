using Application.Models;
using AutoMapper;
using Data.Entities;
using Repository.Interface.Admin;
using Service.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin
{
    public class ImportInvoiceService : IImportInvoiceService
    {
        private readonly IImportInvoiceRepository _repository;
        private readonly IMapper _mapper;
        public ImportInvoiceService(IImportInvoiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HoaDonNhap> createInvoice(HoaDonNhap entity)
        {
            if(entity == null){
                throw new ArgumentNullException("entity can not be null");
            }
            try
            {
                var data = await _repository.createInvoice(entity);
                return data;
            }
            catch(Exception ex)
            {
                throw new Exception("error while creating the entity", ex);
            }
        }

        public async Task<ChiTietHoaDonNhap> createInvoiceDetail(ChiTietHoaDonNhap detail)
        {
            if (detail == null)
            {
                throw new ArgumentNullException("entity can not be null");
            }
            try
            {
                var data = await _repository.createInvoiceDetail(detail);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("error while creating the entity", ex);
            }
        }

        public async Task<BaseQueryReponseModel<ImportInvoiceModel>> getAllInvoice(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var data = await _repository.getAllInvoice(pageIndex, pageSize);
                var invoiceModel = _mapper.Map<List<HoaDonNhap>, List<ImportInvoiceModel>>(data.Items);
                var result = new BaseQueryReponseModel<ImportInvoiceModel>
                {
                    Items = invoiceModel,
                    PageIndex = data.PageIndex,
                    PageSize = data.PageSize,
                    Total = data.Total
                };
                if (result == null)
                {
                    throw new InvalidOperationException("GetAll operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get all entities", ex);
            }
        }

        public async Task<ImportInvoiceModel> getInvoiceById(int id)
        {
            if (id <= 0 )
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var data = await _repository.getInvoiceById(id);
                var result = _mapper.Map<HoaDonNhap, ImportInvoiceModel>(data);
                if (result == null)
                {
                    throw new InvalidOperationException("GetAll operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get all entities", ex);
            }
        }

        public async Task<List<ImportInvoiceDetailModel>> getInvoiceDetailById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var data = await _repository.getInvoiceDetailById(id);
                var result = _mapper.Map<List<ChiTietHoaDonNhap>, List<ImportInvoiceDetailModel>>(data);
                if (result == null)
                {
                    throw new InvalidOperationException("GetAll operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get all entities", ex);
            }
        }
    }
}
