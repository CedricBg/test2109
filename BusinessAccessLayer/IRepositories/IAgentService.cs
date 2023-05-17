using BusinessAccessLayer.Models.Customers;

namespace BusinessAccessLayer.IRepositories
{
    public interface IAgentService
    {
        List<Site> assignedClients(int id);
    }
}