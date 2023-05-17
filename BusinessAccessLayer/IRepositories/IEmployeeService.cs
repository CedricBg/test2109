using BusinessAccessLayer.Models.Employee;
using Microsoft.AspNetCore.Http;

namespace BusinessAccessLayer.IRepositories

{
    public interface IEmployeeService
    {
        bool AddEmployee(DetailedEmployee form);
        List<Employee> GetAll();
        public DetailedEmployee GetOne(int id);
        bool Deactive(int id);
        DetailedEmployee UpdateEmployee(DetailedEmployee detailedEmployee);
        Task<string> UploadFile(SendFoto file);
    }
}