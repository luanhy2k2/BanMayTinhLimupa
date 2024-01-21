using Model.Models;
using Repository.Interface;
using Repository.Interface.Admin;
using Service.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Admin
{
    public class OrderService : GenericService<DonHang>, IOrderService
    {
        private IOrderRepository _repository;
        public OrderService(IOrderRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<object> GetOrder(int id, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0 || id == null)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.GetOrder(id, pageIndex, pageSize);
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
