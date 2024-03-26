using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IMessageRepository : IGenericRespository<Message>
    {
        public Task<Message> Create(string userName, CreateMessage model);
        public Task<BaseQueryReponseModel<Message>> Get(int pageIndex, int pageSize,string name);
    }
}
