using Repository.Interface.Admin;
using Service.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin
{
    public class DashboardService:IDashboardService
    {
        private readonly IDashboardRepository _repository;
        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> OrderDuringDay()
        {
            try
            {
                var result = await _repository.OrderDuringDay();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occurred when calculating order: " + ex.Message);
            }
        }

        public async Task<int> OrderDuringMonth()
        {
            try
            {
                var result = await _repository.OrderDuringMonth();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred when calculating order: " + ex.Message);
            }
        }

        public async Task<int> RevenueDuringDay()
        {
            try
            {
                var result = await _repository.RevenueDuringDay();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred when calculating revenue: " + ex.Message);
            }
        }

        public async Task<int> RevenueDuringMonth()
        {
            try
            {
                var result = await _repository.RevenueDuringMonth();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred when calculating revenue: " + ex.Message);
            }
        }

        public async Task<int> TotalProduct()
        {
            try
            {
                var result = await _repository.TotalProduct();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred when calculating product: " + ex.Message);
            }
        }

        public async Task<int> TotalUser()
        {
            try
            {
                var result = await _repository.TotalUser();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred when calculating user: " + ex.Message);
            }
        }
    }
}
