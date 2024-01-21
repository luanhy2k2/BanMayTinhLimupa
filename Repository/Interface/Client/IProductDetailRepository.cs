﻿using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Client
{
    public interface IProductDetailRepository
    {
        Task<Object> GetProductById(int id);
        Task<ProductComment> AddComment(ProductComment comment);
        Task<Object> GetAllComment(int idProduct, int index, int quantity);
        
    }
}
