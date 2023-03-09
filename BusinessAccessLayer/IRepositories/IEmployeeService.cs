using BusinessAccessLayer.Models.Employee;

namespace BusinessAccessLayer.IRepositories

{
    public interface IEmployeeService
    {
        bool AddEmployee(DetailedEmployee form);
        List<Employee> GetAll();
        public DetailedEmployee GetOne(int id);
        bool Deactive(int id);
        DetailedEmployee UpdateEmployee(DetailedEmployee detailedEmployee);
    }
}