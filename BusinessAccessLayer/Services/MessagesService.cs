using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Discussion;

using DataAccess.Repository;

namespace BusinessAccessLayer.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IMapper _Mapper;

        private readonly IMessagesServices _messagesServices;

        public MessagesService(IMapper mapper, IMessagesServices messagesServices)
        {
            _Mapper = mapper;
            _messagesServices = messagesServices;
        }

        public List<string> GetMessages(int id)
        {
            List<string> list = _messagesServices.GetMessages(id).Select(dr => _Mapper.Map<string>(dr)).Take(5).ToList();
            return list;
        }

         public List<string> AddMessage(Messages message)
        {
            var detail = _Mapper.Map<DataAccess.Models.Discussion.Message>(message);
            List<string> list = _messagesServices.AddMessage(detail);
            return list;
        }
    }
}
