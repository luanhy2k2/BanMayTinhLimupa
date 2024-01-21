using Model.Models;
using Repository.Interface.Client;
using Service.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Client
{
    public class ProductDetailService : IProductDetailService
    {
        private IProductDetailRepository _res;
        public ProductDetailService(IProductDetailRepository res)
        {
            _res = res;
        }

        public async Task<ProductComment> AddComment(ProductComment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment), "comment cannot be null.");
            }
            try
            {
                var result = await _res.AddComment(comment);
                if (result == null)
                {
                    throw new InvalidOperationException("Create operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while creating the entity.", ex);
            }
        }

        public async Task<object> GetAllComment(int idProduct, int index, int quantity)
        {
            if (index <= 0 || quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _res.GetAllComment(idProduct ,index, quantity);
                if (result == null)
                {
                    throw new InvalidOperationException("Get comment operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get all comment", ex);
            }
        }

        public async Task<object> GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _res.GetProductById(id);
                if (result == null)
                {
                    throw new InvalidOperationException("operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get entities", ex);
            }
        }
    }
}
