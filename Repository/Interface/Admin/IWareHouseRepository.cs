using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Admin
{
    public interface IWareHouseRepository: IGenericRespository<ChiTietKho>
    {
        Task<BaseQueryReponseModel<ChiTietKho>> GetWarehouse(int pageIndex, int pageSize);
    }
}
