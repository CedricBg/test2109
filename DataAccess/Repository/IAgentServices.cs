using DataAccess.Models;
using DataAccess.Models.Agents;
using DataAccess.Models.Customer;
using DataAccess.Models.Employees;

namespace DataAccess.Repository
{
    public interface IAgentServices
    {
        List<Site> assignedClients(int id);
        List<Employee> assignedEmployees();
        Employee GetAGuard(int id);
        List<Site> AddSiteToGuard(AddSites sites);

    }
}