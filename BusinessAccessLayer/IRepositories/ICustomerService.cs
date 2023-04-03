
using BusinessAccessLayer.Models.Customers;

namespace BusinessAccessLayer.IRepositories
{
    public interface ICustomerService
    {
        List<AllCustomers> All();
        Site GetCustomer(int id);
        Site UpdateSite(Site site);
        int AddCustomer(string customers);
        int? AddSite(Site site);
    }
}