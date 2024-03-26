using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IMessageService:IGenericService<Message>
    {
        public Task<MessageModel> Create(string userName, CreateMessage model);
        public Task<BaseQueryReponseModel<MessageModel>> Get(int pageIndex, int pageSize, string name);
    }
}
