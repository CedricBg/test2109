
using BusinessAccessLayer.Models.Customer;

namespace BusinessAccessLayer.IRepositories
{
    public interface ICustomerService
    {
        List<CustomerAll> All();
        Customers GetCustomer(int id);
    }
}