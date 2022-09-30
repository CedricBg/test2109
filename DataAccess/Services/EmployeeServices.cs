using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace DataAccess.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly SecurityCompanyContext _db;

        public EmployeeServices(SecurityCompanyContext context)
        {
            _db = context;
        }

        public bool PostData(Employee employee)
        {
           
            if (employee is not null)
            {

                    _db.Employees.Add(new Employee
                    {
                        firstName = employee.firstName,
                        SurName = employee.SurName,
                        CreationDate = DateTime.Now,
                        BirthDate = employee.BirthDate,
                        Vehicle = employee.Vehicle,
                        SecurityCard = employee.SecurityCard,
                        EntryService = employee.EntryService,
                        EmployeeCardNumber = employee.EmployeeCardNumber,
                        RegistreNational = employee.RegistreNational,
                        Actif = employee.Actif,
                    });

                    _db.SaveChanges();
                    return true;
                
                
            }
            else
            {
                return false;
            }
                
            
        }

    }
}
