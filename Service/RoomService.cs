using Application.Hubs;
using Application.Models;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.SignalR;
using Repository.Interface;
using Repository.Interface.Admin;
using Service.Interface;
using Service.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RoomService: GenericService<Room>, IRoomService
    {
        private IRoomRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;
        public RoomService(IRoomRepository repository, IHubContext<ChatHub> hubContext, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _hubContext = hubContext;
            _mapper = mapper;
        }

        public async Task<Room> Create(string roomName, string adminUserName)
        {
            try
            {
                var result = await _repository.Create(roomName, adminUserName);
                await _hubContext.Clients.All.SendAsync("addChatRoom", new { id = result.Id, name = result.Name });
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<Room> Edit(string adminUsername, RoomModel roomViewModel)
        {
            try
            {
                var result = await _repository.Edit(adminUsername, roomViewModel);
                await _hubContext.Clients.All.SendAsync("updateChatRoom", new { id = result.Id, result.Name });
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<BaseQueryReponseModel<RoomModel>> Get(int pageIndex, int pageSize)
        {
            try
            {
                var result = await _repository.GetRoom(pageIndex, pageSize);
                var roomViewModel = _mapper.Map<List<Room>, List<RoomModel>>(result.Items);
                return new BaseQueryReponseModel<RoomModel>
                {
                    Items = roomViewModel,
                    PageIndex = result.PageIndex,
                    PageSize = result.PageSize,
                    Total = result.Total
                };
            }
            catch(Exception ex)
            {
                throw new Exception("Error while get room", ex);
            }
        }

        public async Task<Room> GetRomByUser(string userId)
        {
            
                if(userId == null)
                {
                    throw new ArgumentNullException("userId");
                }
                var result = await _repository.GetRoomByUser(userId);
                if(result == null)
                {
                    return null;
                }
                //var roomModel = _mapper.Map<Room, RoomModel>(result);
                return result;
            
            
        }
    }
}
