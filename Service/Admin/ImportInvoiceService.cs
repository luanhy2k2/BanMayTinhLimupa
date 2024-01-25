using Model.Models;
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
        private IImportInvoiceRepository _repository;
        public ImportInvoiceService(IImportInvoiceRepository repository)
        {
            _repository = repository;
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

        public async Task<object> getAllInvoice(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.getAllInvoice(pageIndex, pageSize);
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

        public async Task<object> getInvoiceById(int id)
        {
            if (id <= 0 )
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.getInvoiceById(id);
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

        public async Task<object> getInvoiceDetailById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.getInvoiceDetailById(id);
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
