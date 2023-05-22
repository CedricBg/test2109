using AutoMapper;
using BusinessAccessLayer.IRepositories;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
