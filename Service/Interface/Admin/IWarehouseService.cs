using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IWarehouseService:IGenericService<ChiTietKho>
    {
        Task<BaseQueryReponseModel<ProductStonkModel>> GetWarehouse(int pageIndex, int pageSize);
    }
}
