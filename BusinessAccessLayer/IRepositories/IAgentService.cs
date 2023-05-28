using BusinessAccessLayer.Models.Agents;
using BusinessAccessLayer.Models.Customers;
using BusinessAccessLayer.Models.Employee;

namespace BusinessAccessLayer.IRepositories
{
    public interface IAgentService
    {
        List<Site> assignedClients(int id);
        List<Employee> assignedEmployees();
        Employee GetAGuard(int id);
        List<Customers> assignedCustomers(int id);
        List<Site> AddSiteToGuard(AddSites sites);
    }
}