using DataAccess.Models;
using DataAccess.Models.Employees;


namespace DataAccess.Repository
{
    public interface IEmployeeServices
    {
        bool AddEmployee(DetailedEmployee employee);
        List<Employee> GetAll();
        DetailedEmployee GetOne(int id);
        bool Deactive(int id);
        DetailedEmployee UpdateEmployee(DetailedEmployee employee);
        Countrys Country(int? id);
        Task<string> UploadFile(SendFoto file);
        Task<byte[]> LoadFoto(int id);
    }
}