using Application.Models;
using AutoMapper;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDetailModel> CreateProduct(ProductDetailModel model)
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
       
        public  async Task<BaseQueryReponseModel<ProductModel>> getProduct(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var products = await _repository.getProduct(pageIndex, pageSize);
                var productsViewModel = _mapper.Map<List<Sanpham>, List<ProductModel>>(products.Items);
             
                var result = new BaseQueryReponseModel<ProductModel>
                {
                    PageIndex = products.PageIndex,
                    PageSize = products.PageSize,
                    Items = productsViewModel,
                    Total = products.Total
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

        public async Task<ProductDetailModel> getProductbyId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var product = await _repository.getProductbyId(id);
                var result = _mapper.Map<Sanpham, ProductDetailModel>(product);
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

        public async Task<BaseQueryReponseModel<ProductModel>> searchProduct(string name, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0 || name == null)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var products = await _repository.searchProduct(name, pageIndex, pageSize);
                var productViewModel = _mapper.Map<List<Sanpham>, List<ProductModel>>(products.Items);
                var result = new BaseQueryReponseModel<ProductModel>
                {
                    PageIndex = products.PageIndex,
                    PageSize = products.PageSize,
                    Items = productViewModel,
                    Total = products.Total
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

        public async Task<ProductDetailModel> UpdateProduct(ProductDetailModel model)
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
