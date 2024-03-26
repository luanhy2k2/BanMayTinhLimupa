using Application.Models;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoomRepository : GenericRespository<Room>, IRoomRepository
    {
        private readonly QuanlybanhangContext _db;
        public RoomRepository(QuanlybanhangContext _dbContext) :base(_dbContext)
        {
            _db = _dbContext;
        }
        public async Task<Room> Create(string roomName, string adminUserName)
        {
            if (_db.Room.Any(r => r.Name == roomName))
                throw new Exception("Invalid room name or room already exists");

            var user = _db.Users.FirstOrDefault(u => u.UserName == adminUserName);
            var room = new Room()
            {
                Name = roomName,
                User = user
            };

            _db.Room.Add(room);
            await _db.SaveChangesAsync();


            return room;
        }
        public async Task<Room> Edit(string adminUsername, RoomModel roomViewModel)
        {
            if (_db.Room.Any(r => r.Name == roomViewModel.Name))
                throw new Exception("Invalid room name or room already exists");

            var room = await _db.Room
                .Include(r => r.User)
                .Where(r => r.Id == roomViewModel.ID && r.User.UserName == adminUsername)
                .FirstOrDefaultAsync();

            if (room == null)
                throw new Exception();

            room.Name = roomViewModel.Name;
            await _db.SaveChangesAsync();

            return room;
        }

        public async Task<BaseQueryReponseModel<Room>> GetRoom(int pageIndex, int pageSize)
        {
            try
            {
                var item = await _db.Room.Include(x =>x.Messages).Include(x =>x.User).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var total = await _db.Room.CountAsync();
                return new BaseQueryReponseModel<Room>
                {
                    Items = item,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Total = total
                };
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Room> GetRoomByUser(string userId)
        {
            try
            {
                var room = await _db.Room.Where(x => x.User.Id == userId).FirstOrDefaultAsync();
                
                return room;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while get room in database", ex);
            }
        }
    }
}
