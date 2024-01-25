using Model.Models;
using Repository.Interface.Client;
using Service.Interface.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Client
{
    public class HomePageService : IHomePageService
    {
        private readonly IHomePageRepository _res;
        public HomePageService(IHomePageRepository res)
        {
            _res = res;
        }

        public async Task<object> NewProduct(int index, int quantity)
        {
            if (index <= 0 || quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _res.NewProduct(index, quantity);
                if (result == null)
                {
                    throw new InvalidOperationException("NewProduct operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get new product entities", ex);
            }
        }

        public async Task<object> SellingProduct(int index, int quantity)
        {
            if (index <= 0 || quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _res.SellingProduct(index, quantity);
                if (result == null)
                {
                    throw new InvalidOperationException("SellingProduct operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get selling product entities", ex);
            }
        }
        public async Task<object> GetProductByCategory(int categoryId, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0 || categoryId <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _res.GetProductByCategory(categoryId,pageIndex, pageSize);
                if (result == null)
                {
                    throw new InvalidOperationException("operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get product entities", ex);
            }
        }

        

        public async Task<object> GetProductByCompany(int companyId, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0 || companyId <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _res.GetProductByCompany(companyId, pageIndex, pageSize);
                if (result == null)
                {
                    throw new InvalidOperationException("operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get product entities", ex);
            }
        }

        public async Task<List<Sanpham>> GetFilteredProducts(string[] ram, string[] rom)
        {
            if (ram == null || rom == null)
            {
                throw new ArgumentOutOfRangeException("input canot be null");
            }
            try
            {
                var result = await _res.GetFilteredProducts(ram,rom);
                if (result == null)
                {
                    throw new InvalidOperationException("operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get product entities", ex);
            }
        }
    }
}
