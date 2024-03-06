using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IProductService:IGenericService<Sanpham>
    {
        Task<BaseQueryReponseModel<ProductModel>> getProduct(int pageIndex, int pageSize);
        Task<ProductDetailModel> getProductbyId(int id);
        Task<ProductDetailModel> CreateProduct(ProductDetailModel model);
        Task<ProductDetailModel> UpdateProduct(ProductDetailModel model);
        Task<BaseQueryReponseModel<ProductModel>> searchProduct(string name, int pageIndex, int pageSize);
    }
}
