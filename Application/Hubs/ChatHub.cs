using Application.Models;
using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
        public readonly static List<UserModel> _connections = new List<UserModel>();
        private readonly static Dictionary<string, string> _connectionMap = new Dictionary<string, string>();
        private readonly QuanlybanhangContext _context;
        private readonly IMapper _mapper;
        public ChatHub(QuanlybanhangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private string IdentityName
        {
            get { return Context.User.Identity.Name; }
        }
        public async Task SendPrivate(string receiverName, string message)
        {
            if(_connectionMap.TryGetValue(receiverName, out string userId))
            {
                var sender = _connections.Where(x => x.UserName == IdentityName).First();
                if (!string.IsNullOrEmpty(message.Trim())){
                    var messageViewModel = new MessageModel
                    {
                        Content = message,
                        User = sender.hoTen,
                        //Avartar = sender.Avartar,
                        Timestamp = DateTime.Now.ToLongTimeString(),
                    };
                    await Clients.Client(userId).SendAsync("newMessage", messageViewModel);
                    await Clients.Caller.SendAsync("newMessage", messageViewModel);
                }
            }
        }
        public async Task Join(string roomName)
        {
            try
            {
                var user = _connections.Where(x => x.UserName == IdentityName).First();
                if(user != null && user.CurrentRoom != roomName)
                {
                    if (!string.IsNullOrEmpty(user.CurrentRoom))
                        await Clients.OthersInGroup(user.CurrentRoom).SendAsync("removeUser", user);
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.CurrentRoom);
                    await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
                    user.CurrentRoom = roomName;
                    await Clients.OthersInGroup(roomName).SendAsync("addUser", user);
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("onError", "You failed to join the chat room!" + ex.Message);
            }
        }
        public override Task OnConnectedAsync()
        {
            try
            {
                var user = _context.Users.Where(u => u.UserName == IdentityName).FirstOrDefault();
                var userViewModel = _mapper.Map<ApplicationUser, UserModel>(user);
                userViewModel.CurrentRoom = "";

                if (!_connections.Any(u => u.UserName == IdentityName))
                {
                    _connections.Add(userViewModel);
                    _connectionMap.Add(IdentityName, Context.ConnectionId);
                }
                Clients.Caller.SendAsync("getProfileInfo", user.hoTen);
                //Clients.Caller.SendAsync("getProfileInfo", user.hoTen, user.Avartar);
            }
            catch (Exception ex)
            {
                Clients.Caller.SendAsync("onError", "OnConnected:" + ex.Message);
            }
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                var user = _connections.Where(u => u.UserName == IdentityName).First();
                _connections.Remove(user);

                // Tell other users to remove you from their list
                Clients.OthersInGroup(user.CurrentRoom).SendAsync("removeUser", user);

                // Remove mapping
                _connectionMap.Remove(user.UserName);
            }
            catch (Exception ex)
            {
                Clients.Caller.SendAsync("onError", "OnDisconnected: " + ex.Message);
            }

            return base.OnDisconnectedAsync(exception);
        }


        public IEnumerable<UserModel> GetUsers(string roomName)
        {
            return _connections.Where(u => u.CurrentRoom == roomName).ToList();
        }
    }
}
