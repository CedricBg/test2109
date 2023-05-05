using BusinessAccessLayer.Models.Customers;

namespace BusinessAccessLayer.IRepositories
{
    public interface IAgentService
    {
        List<Customers> assignedClients(int id);
    }
}