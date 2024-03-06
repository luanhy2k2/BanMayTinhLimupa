using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Client
{
    public interface IProductDetailService
    {
        Task<ProductModel> GetProductById(int id);
        Task<ProductComment> AddComment(ProductComment comment);
        Task<Object> GetAllComment(int idProduct, int index, int quantity);
    }
}
