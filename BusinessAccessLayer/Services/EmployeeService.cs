using System;
using DataAccess.Services;
using BusinessAccessLayer.Tools.Employee;
using BusinessAccessLayer.IRepositories;
using DataAccess.Repository;
using BusinessAccessLayer.Models.Employee;
using AutoMapper;

namespace BusinessAccessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeServices _employeeServices;

        private readonly IMapper _Mapper;

        public EmployeeService(IEmployeeServices employeeServices, IMapper mapper)
        {
            _employeeServices = employeeServices;
            _Mapper = mapper;
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

        public List<Employee> GetAll() 
        {
            return _employeeServices.GetAll().Select(dr => _Mapper.Map<Employee>(dr)).ToList();
        }

        public DetailedEmployee GetOne(int id) 
        {
            DetailedEmployee employee = _Mapper.Map<DetailedEmployee>(_employeeServices.GetOne(id));
            return employee;
        }
    }
}
