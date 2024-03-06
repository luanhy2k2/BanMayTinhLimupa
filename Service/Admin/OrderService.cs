using Application.Models;
using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Interface;
using Repository.Interface.Admin;
using Service.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Admin
{
    public class OrderService : GenericService<DonHang>, IOrderService
    {
        private IOrderRepository _repository;
        private readonly IMapper _mapper;
        private QuanlybanhangContext _db;
        public OrderService(IOrderRepository repository, IMapper mapper, QuanlybanhangContext db) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
            _db = db;
        }

        public async Task<object> ConfirmOrder(int id)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var orderDetails = await GetOrderDetail(id);
                    await UpdateProductQuantity(orderDetails);
                    await UpdateStatus(id, "Đã xác nhận");
                    await transaction.CommitAsync();
                    return orderDetails;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Error transaction", ex);
                }
            }
        }

        public async Task<BaseQueryReponseModel<OrderModel>> GetAllOrder(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var data = await _repository.GetAllOrder(pageIndex, pageSize);
                var orderViewModel = _mapper.Map<List<DonHang>, List<OrderModel>>(data.Items);
                var result = new BaseQueryReponseModel<OrderModel>
                {
                    Items = orderViewModel,
                    PageIndex = data.PageIndex,
                    Total = data.Total,
                    PageSize = data.PageSize

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

        public async Task<object> GetOrder(string phone, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0 || phone == null)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.GetOrder(phone, pageIndex, pageSize);
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

        public async Task<object> GetOrderById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.GetOrderById(id);
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

        public async Task<List<ChiTietDonHang>> GetOrderDetail(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.GetOrderDetail(id);
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

        public async Task<object> GetOrderDetailById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.GetOrderDetailById(id);
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

        public async Task<DonHang> UpdateDelivery(int id, string delivery)
        {
            if (id <= 0 || delivery == null)
            {
                throw new ArgumentNullException("Entity cannot be null.");
            }
            try
            {
                var result = await _repository.UpdateDelivery(id, delivery);
                if (result == null)
                {
                    throw new InvalidOperationException("Update operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while updating the entity.", ex);
            }
        }
        public async Task<DonHang> UpdatePaymentStatus(int id, string status)
        {
            if (id <= 0 || status == null)
            {
                throw new ArgumentNullException("Entity cannot be null.");
            }
            try
            {
                var result = await _repository.UpdatePaymentStatus(id, status);
                if (result == null)
                {
                    throw new InvalidOperationException("Update operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while updating the entity.", ex);
            }
        }
        public async Task<List<ChiTietDonHang>> UpdateProductQuantity(List<ChiTietDonHang> orderDetails)
        {
            if (orderDetails == null)
            {
                throw new ArgumentNullException(nameof(orderDetails), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.UpdateProductQuantity(orderDetails);
                if (result == null)
                {
                    throw new InvalidOperationException("Update operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while updating the entity.", ex);
            }
        }
        public async Task<DonHang> UpdateStatus(int id, string status)
        {
            if (id <= 0 || status == null)
            {
                throw new ArgumentNullException(nameof(id), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.UpdateStatus(id, status);
                if (result == null)
                {
                    throw new InvalidOperationException("Update operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while updating the entity.", ex);
            }
        }
    
    }
}
