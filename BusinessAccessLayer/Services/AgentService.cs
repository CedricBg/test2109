using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Customers;
using DataAccess.Repository;
using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class AgentService : IAgentService
    {
        private IAgentServices _AgentServices;

        private IMapper _Mapper;

        public AgentService(IAgentServices agentServices, IMapper mapper)
        {
            _AgentServices = agentServices;
            _Mapper = mapper;
        }

        public List<Customers> assignedClients(int id)
        {
            var customers = _AgentServices.assignedClients(id).Select(e => _Mapper.Map<Customers>(e)).ToList();
            return customers;
        }
    }
}
