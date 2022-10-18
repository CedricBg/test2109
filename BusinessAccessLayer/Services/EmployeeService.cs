using System;
using BusinessAccessLayer.Models;
using DataAccess.Services;
using BusinessAccessLayer.Tools.Employee;
using BusinessAccessLayer.Repository;
using DataAccess.Repository;

namespace BusinessAccessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeService(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        public bool AddEmployee(Employees form)
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

        public IEnumerable<Employees> GetAll() 
        {
            return _employeeServices.GetAll().Select(dr => dr.GetAllEmployee());
        }
    }
}
