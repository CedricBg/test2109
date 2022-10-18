using BusinessAccessLayer.Models;

namespace BusinessAccessLayer.Repository
{
    public interface IEmployeeService
    {
        bool AddEmployee(Employees form);
        IEnumerable<Employees> GetAll();
    }
}