using BusinessAccessLayer.Models.Customers;
using BusinessAccessLayer.Models.Planning;

namespace BusinessAccessLayer.IRepositories
{
    public interface IPlanningService
    {
        Working StartWork(StartEndWorkTime form);
        Boolean EndWork(int id);
        List<AllCustomers> Customers(int id);
        Working IsWorking(int id);
    }
}