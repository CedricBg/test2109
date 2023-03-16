using DataAccess.Models.Customer;
using DataAccess.Services;

namespace DataAccess.Repository
{
    public interface ICustomerServices
    {
        List<CustomerAll> All();
    }
}