using DataAccess.Models;

namespace DataAccess.Repository
{
    public interface IEmployeeServices
    {
        bool PostData(Employee employee);
        List<Employee> GetAll();
    }
}