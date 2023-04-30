using BusinessAccessLayer.Models.Customers;
using BusinessAccessLayer.Models.Planning;

namespace BusinessAccessLayer.IRepositories
{
    public interface IPlanningService
    {
        Boolean StartWork(StartEndWorkTime form);
        Boolean EndWork(int id);
        List<AllCustomers> Customers(int id);
        Boolean IsWorking(int id);
    }
}