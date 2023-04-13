using DataAccess.Models.Customer;
using DataAccess.Services;

namespace DataAccess.Repository
{
    public interface ICustomerServices
    {
        List<AllCustomers> All();
        Site Get(int id);
        Site UpdateSite(Site site);
        int AddCustomer(Customers customers);
        int? AddSite(Site site);
        List<Customers> addContact(ContactPerson contact);
        string Delete(int id);
        List<Customers> UpdateCustomer(AllCustomers cust);
        Customers GetOne(int id);
    }
}