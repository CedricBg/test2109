using DataAccess.Models;
using DataAccess.Models.Employees;


namespace DataAccess.Repository
{
    public interface IEmployeeServices
    {
        bool PostData(DetailedEmployee employee);
        List<Employee> GetAll();
        DetailedEmployee GetOne(int id);
    }
}