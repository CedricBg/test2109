using DataAccess.Models.Customer;
using DataAccess.Models.Planning;

namespace DataAccess.Repository
{
    public interface IPlanningServices
    {

        Boolean EndWork(int id);
        List<Site> Sites(int id);
        Working IsWorking(int id);
        Working StartWork(StartEndWorkTime form);
    }
}