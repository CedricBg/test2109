using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Customers;
using BusinessAccessLayer.Models.Employee;
using DATA = DataAccess.Models.Agents;
using DataAccess.Repository;
using BusinessAccessLayer.Models.Agents;

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

        public List<Site> assignedClients(int id)
        {
            var sites = _AgentServices.assignedClients(id).Select(e => _Mapper.Map<Site>(e)).ToList();
            return sites;
        }

        public List<Employee> assignedEmployees()
        {
            return _AgentServices.assignedEmployees().Select(dr => _Mapper.Map<Employee>(dr)).ToList();
        }

        public Employee GetAGuard(int id)
        {
            return _Mapper.Map<Employee>(_AgentServices.GetAGuard(id));
        }

        public List<Customers> assignedCustomers(int id)
        {
             return _AgentServices.assignedCustomers(id).Select(dr => _Mapper.Map<Customers>(dr)).ToList();

        }

        public List<Site> AddSiteToGuard(AddSites sites)
        {
            var detail = _Mapper.Map<DATA.AddSites>(sites);
            return _AgentServices.AddSiteToGuard(detail).Select(e=> _Mapper.Map<Site>(e)).ToList();
        }

        public List<Site> RemoveSiteToGuard(AddSites sites)
        {
            var detail = _Mapper.Map<DATA.AddSites>(sites);
            return _AgentServices.RemoveSiteToGuard(detail).Select(e=> _Mapper.Map<Site>(e)).ToList();
        }

        public List<Site> DeleteSiteFromGuard(AddSites sites)
        {
            var detail = _Mapper.Map<DATA.AddSites>(sites);
            return _AgentServices.DeleteSiteFromGuard(detail).Select(e => _Mapper.Map<Site>(e)).ToList();
        }
    }
}
