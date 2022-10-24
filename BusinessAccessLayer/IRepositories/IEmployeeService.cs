using BusinessAccessLayer.Models;

namespace BusinessAccessLayer.IRepositories

{
    public interface IEmployeeService
    {
        bool AddEmployee(Employees form);
        IEnumerable<Employees> GetAll();
    }
}