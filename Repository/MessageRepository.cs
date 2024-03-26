using Application.Models;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository
{
    public class MessageRepository : GenericRespository<Message>, IMessageRepository
    {
        private readonly QuanlybanhangContext _db;
        public MessageRepository(QuanlybanhangContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<Message> Create(string userName, CreateMessage model)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(u => u.UserName == userName);
                if(user == null)
                {
                    throw new ArgumentNullException("user is null");
                }
                var room = _db.Room.FirstOrDefault(r => r.User.Id == model.RoomName);
                if (room == null)
                    return null;

                var msg = new Message()
                {
                    Content = Regex.Replace(model.Content, @"<.*?>", string.Empty),
                    User = user,
                    Room = room,
                    TimeStamp = DateTime.Now
                };

                await _db.Message.AddAsync(msg);
                await _db.SaveChangesAsync();
                return msg;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while manipulating the database", ex);
            }
        }

        public async Task<BaseQueryReponseModel<Message>> Get(int pageIndex, int pageSize, string name)
        {
            try
            {
                var result = await _db.Message.Where(x =>x.Room.User.Id == name)
                    .Include(x =>x.User).Include(x =>x.Room)
                    
                    .Skip((pageIndex - 1) * pageSize).ToListAsync();
                var total = await _db.Message.CountAsync();
                return new BaseQueryReponseModel<Message>
                {
                    Items = result,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Total = total
                };
            }
            catch(Exception ex)
            {
                throw new Exception("Error while manipulating the database", ex);
            }
        }
    }
}
