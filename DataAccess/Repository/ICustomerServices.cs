using DataAccess.Models.Customer;
using DataAccess.Services;

namespace DataAccess.Repository
{
    public interface ICustomerServices
    {
        List<AllCustomers> All();
        Site Get(int id);
        Site UpdateSite(Site site);
        int AddCustomer(string customers);
        int? AddSite(Site site);
        int addContact(ContactPerson contact);
        string Delete(int id);
    }
}