using System;
using DataAccess.Services;
using BusinessAccessLayer.Tools.Employee;
using BusinessAccessLayer.IRepositories;
using DataAccess.Repository;
using BusinessAccessLayer.Models.Employee;
using AutoMapper;
using DATA = DataAccess.Models.Employees;
using System.Text.Json;
using System.IO;
using Microsoft.AspNetCore.Http;



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

        public EmployeeService()
        {

        }

        public async Task<string> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "retoruné une image valide";
            }

            var filePath = Path.Combine("Images/", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return JsonSerializer.Serialize("Fichier téléchargé avec succès!");
        }

        public Boolean AddEmployee(DetailedEmployee form)
        {
            try
            {
                var detail = _Mapper.Map<DATA.DetailedEmployee>(form);
                _employeeServices.PostData(detail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Employee> GetAll() 
        {
            return  _employeeServices.GetAll().Select(dr => _Mapper.Map<Employee>(dr)).ToList();
        }

        public DetailedEmployee GetOne(int id) 
        {
            DetailedEmployee employee = _Mapper.Map<DetailedEmployee>(_employeeServices.GetOne(id));
            return employee;
        }

        public bool Deactive(int id)
        {
            return _employeeServices.Deactive(id);
        }

        public DetailedEmployee UpdateEmployee(DetailedEmployee detailedEmployee)
        {
            var detail = _Mapper.Map<DATA.DetailedEmployee>(detailedEmployee);
            DetailedEmployee employee = _Mapper.Map<DetailedEmployee>(_employeeServices.UpdateEmployee(detail));
            return employee;
        }


    }
}
