using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Employees;
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

        public bool PostData(DetailedEmployee employee)
        {

            if (_db.DetailedEmployees is not null)
            {
                _db.DetailedEmployees.Add(new DetailedEmployee
                {
                    Id = employee.Id,
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
                    RoleId = employee.RoleId
                });

                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public IEnumerable<Employee> GetAll()
        {
                if (_db.employees is not null)
                {
                    var requete = _db.DetailedEmployees
                        .Select((employee) => new Employee
                        {
                            Id = employee.Id,
                            firstName = employee.firstName,
                            SurName = employee.SurName
                        });
                    return requete;
                }
                    else
                {
                    throw new Exception();
                }  
        }
    }
}
