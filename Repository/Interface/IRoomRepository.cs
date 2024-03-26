using Application.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRoomRepository: IGenericRespository<Room>
    {
        public Task<Room> Create(string roomName, string adminUserName);
        public Task<Room> Edit(string adminUsername, RoomModel roomViewModel);
        public Task<BaseQueryReponseModel<Room>> GetRoom(int pageIndex, int pageSize);
        public Task<Room> GetRoomByUser (string userId);
    }
}
