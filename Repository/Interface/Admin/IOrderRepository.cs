using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Admin
{
    public interface IOrderRepository:IGenericRespository<DonHang>
    {
        Task<Object> GetOrder(int id, int pageIndex, int pageSize );
    }
}
