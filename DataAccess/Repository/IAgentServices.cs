using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Models.Employees;

namespace DataAccess.Repository
{
    public interface IAgentServices
    {
        List<Site> assignedClients(int id);
        List<Employee> assignedEmployees();
        Employee GetAGuard(int id);
        List<Customers> assignedCustomers(int id);
    }
}