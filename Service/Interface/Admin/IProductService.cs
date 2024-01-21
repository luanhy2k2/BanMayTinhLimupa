using Model.Models;
using Model.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IProductService:IGenericService<Sanpham>
    {
        Task<Object> getProduct(int pageIndex, int pageSize);
        Task<Object> getProductbyId(int id);
        Task<ProductDetail> CreateProduct(ProductDetail model);
        Task<ProductDetail> UpdateProduct(ProductDetail model);
        Task<Object> searchProduct(string name, int pageIndex, int pageSize);
    }
}
