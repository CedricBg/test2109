using DataAccess.Models.Customer;
using DataAccess.Models.Planning;

namespace DataAccess.Repository
{
    public interface IPlanningServices
    {

        Boolean EndWork(int id);
        List<AllCustomers> Customers(int id);
        Boolean IsWorking(int id);
        Boolean StartWork(StartEndWorkTime form);
    }
}