using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IOrderService:IGenericService<DonHang>
    {
        Task<Object> GetOrder(int id, int pageIndex, int pageSize);
    }
}
