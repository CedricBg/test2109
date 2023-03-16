using DataAccess.Models.Customer;

namespace BusinessAccessLayer.IRepositories
{
    public interface ICustomerService
    {
        List<CustomerAll> All();
    }
}