using DataAccess.Models;
using DataAccess.Models.Customer;

namespace DataAccess.Repository
{
    public interface IAgentServices
    {
        List<Site> assignedClients(int id);
 
    }
}