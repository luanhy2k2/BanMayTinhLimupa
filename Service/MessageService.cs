using Application.Hubs;
using Application.Models;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.SignalR;
using Repository.Interface;
using Service.Interface;


namespace Service
{
    public class MessageService : GenericService<Message>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _chatHub;
        public MessageService(IMessageRepository repository, IHubContext<ChatHub> chatHub, IMapper mapper) : base(repository)
        {
            _messageRepository = repository;
            _chatHub = chatHub;
            _mapper = mapper;
        }

        public async Task<MessageModel> Create(string userName, CreateMessage model)
        {
            try
            {
                var result = await _messageRepository.Create(userName, model);
                var createdMessageViewModel = _mapper.Map<Message, MessageModel>(result);
                await _chatHub.Clients.Group(model.RoomName).SendAsync("newMessage", createdMessageViewModel);
                return createdMessageViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<BaseQueryReponseModel<MessageModel>> Get(int pageIndex, int pageSize, string name)
        {
            try
            {
                var result = await _messageRepository.Get(pageIndex, pageSize,name);
                var MessageViewModel = _mapper.Map<List<Message>, List<MessageModel>>(result.Items);
                return new BaseQueryReponseModel<MessageModel>
                {
                    Items = MessageViewModel,
                    Total = result.Total,
                    PageIndex = result.PageIndex,
                    PageSize = result.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error while get message", ex);
            }
        }
    }
}
