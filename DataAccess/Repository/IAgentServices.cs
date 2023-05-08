using DataAccess.Models;
using DataAccess.Models.Customer;

namespace DataAccess.Repository
{
    public interface IAgentServices
    {
        List<Customers> assignedClients(int id);

        Pdf PdfAdd(Pdf pdf);
    }
}