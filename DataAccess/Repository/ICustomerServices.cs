using DataAccess.Models.Customer;
using DataAccess.Services;

namespace DataAccess.Repository
{
    public interface ICustomerServices
    {
        List<AllCustomers> All();
        Site Get(int id);
    }
}