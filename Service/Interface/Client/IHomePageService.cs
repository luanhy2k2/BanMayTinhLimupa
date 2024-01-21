using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Client
{
    public interface IHomePageService
    {
        Task<Object> SellingProduct(int index, int quantity);
        Task<Object> NewProduct(int index, int quantity);
        Task<Object> GetProductByCategory(int categoryId, int pageIndex, int pageSize);
        Task<Object> GetProductByCompany(int companyId, int pageIndex, int pageSize);
    }
}
