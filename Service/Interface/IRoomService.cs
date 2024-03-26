using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRoomService:IGenericService<Room>
    {
        public Task<Room> Create(string roomName, string adminUserName);
        public Task<Room> Edit(string adminUsername, RoomModel roomViewModel);
        public Task<Room> GetRomByUser(string userId);
        public Task<BaseQueryReponseModel<RoomModel>> Get(int pageIndex, int pageSize);
    }
}
