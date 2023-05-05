using DataAccess.Models.Customer;

namespace DataAccess.Repository
{
    public interface IAgentServices
    {
        List<Customers> assignedClients(int id);
    }
}