using DataAccess.Models.Customer;
using DataAccess.Models.Planning;

namespace DataAccess.Repository
{
    public interface IPlanningServices
    {

        Boolean EndWork(int id);
        List<Customers> Customers(int id);
        Working IsWorking(int id);
        Working StartWork(StartEndWorkTime form);
    }
}