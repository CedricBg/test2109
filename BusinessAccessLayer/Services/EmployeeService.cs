using System;
using DataAccess.Services;
using BusinessAccessLayer.Tools.Employee;
using BusinessAccessLayer.IRepositories;
using DataAccess.Repository;
using BusinessAccessLayer.Models.Employee;

namespace BusinessAccessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeService(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        public bool AddEmployee(DetailedEmployee form)
        {
            try
            {
                _employeeServices.PostData(form.PostAnEmployee());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Employee> GetAll() 
        {
            return _employeeServices.GetAll().Select(dr => dr.GetAllEmployee());
        }
    }
}
