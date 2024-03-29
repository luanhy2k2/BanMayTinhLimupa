﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Client
{
    public interface IHomePageRepository
    {
        Task<Object> SellingProduct(int index, int quantity);
        Task<Object> NewProduct(int index, int quantity);
        Task<Object> GetProductByCategory(int categoryId, int pageIndex, int pageSize);
        Task<Object> GetProductByCompany(int companyId, int pageIndex, int pageSize);
        Task<object> GetFilteredProducts(string[] ram, string[] rom, int pageIndex, int pageSize);
    }
}
