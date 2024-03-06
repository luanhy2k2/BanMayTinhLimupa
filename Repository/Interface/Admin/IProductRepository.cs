using Data.Entities;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Admin
{
    public interface IProductRepository:IGenericRespository<Sanpham>
    {
        Task<BaseQueryReponseModel<Sanpham>> getProduct(int pageIndex, int pageSize);
        Task<Sanpham> getProductbyId(int id);
        Task<ProductDetailModel> CreateProduct(ProductDetailModel model);
        Task<ProductDetailModel> UpdateProduct(ProductDetailModel model);
        Task<BaseQueryReponseModel<Sanpham>> searchProduct(string name, int pageIndex, int pageSize);
    }
}
