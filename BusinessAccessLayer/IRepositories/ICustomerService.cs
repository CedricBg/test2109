
using BusinessAccessLayer.Models.Customers;

namespace BusinessAccessLayer.IRepositories
{
    public interface ICustomerService
    {
        List<Customers> All();
        Customers GetCustomer(int id);
    }
}