using BusinessAccessLayer.Models.Employee;

namespace BusinessAccessLayer.IRepositories

{
    public interface IEmployeeService
    {
        bool AddEmployee(DetailedEmployee form);
        IEnumerable<Employee> GetAll();
    }
}