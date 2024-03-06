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
    public class WarehouseService:GenericService<ChiTietKho>, IWarehouseService
    {
        private readonly IWareHouseRepository _repository;
        private readonly IMapper _mapper;
        public WarehouseService(IWareHouseRepository repository, IMapper mapper):base(repository) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseQueryReponseModel<ProductStonkModel>> GetWarehouse(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var data = await _repository.GetWarehouse(pageIndex, pageSize);
                var productStonkModel = _mapper.Map<List<ChiTietKho>, List<ProductStonkModel>>(data.Items);
                var result = new BaseQueryReponseModel<ProductStonkModel>
                {
                    Items = productStonkModel,
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
    }
}
