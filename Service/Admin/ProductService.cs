using Model.Models;
using Model.Models.entity;
using Repository.Interface;
using Repository.Interface.Admin;
using Service.Interface;
using Service.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin
{
    public class ProductService : GenericService<Sanpham>, IProductService
    {
        private IProductRepository _repository;
        public ProductService(IProductRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ProductDetail> CreateProduct(ProductDetail model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.CreateProduct(model);
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

        public  async Task<object> getProduct(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.getProduct(pageIndex, pageSize);
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

        public async Task<object> getProductbyId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.getProductbyId(id);
                if (result == null)
                {
                    throw new InvalidOperationException("GetAll operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get entities", ex);
            }
        }

        public async Task<object> searchProduct(string name, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0 || name == null)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.searchProduct(name, pageIndex, pageSize);
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

        public async Task<ProductDetail> UpdateProduct(ProductDetail model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.UpdateProduct(model);
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
