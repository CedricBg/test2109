using DataAccess.Models;
using DataAccess.Models.Employees;


namespace DataAccess.Repository
{
    public interface IEmployeeServices
    {
        bool PostData(DetailedEmployee employee);
        List<Employee> GetAll();
        DetailedEmployee GetOne(int id);
        bool Deactive(int id);
        DetailedEmployee UpdateEmployee(DetailedEmployee employee);
        Countrys Country(int? id);
        Task<string> UploadFile(SendFoto file);
    }
}