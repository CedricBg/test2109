using AutoMapper;
using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Employees;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly SecurityCompanyContext _db;

        private readonly ICountryServices _country;

        private readonly IMapper _Mapper;

        public EmployeeServices(SecurityCompanyContext context, IMapper mapper, ICountryServices country)
        {
            _db = context;
            _Mapper = mapper;
            _country = country;
        }

        public bool PostData(DetailedEmployee employee)
        {
            if (_db.DetailedEmployees is not null)
            {

                Role role = _db.Roles.FirstOrDefault(c =>c.Id == employee.Role.Id);

                _db.DetailedEmployees.Add(new DetailedEmployee
                {
                    Id = employee.Id,
                    firstName = employee.firstName,
                    SurName = employee.SurName,
                    CreationDate = DateTime.Now,
                    BirthDate = employee.BirthDate,
                    Vehicle = employee.Vehicle,
                    SecurityCard = employee.SecurityCard,
                    EmployeeCardNumber = employee.EmployeeCardNumber,
                    RegistreNational = employee.RegistreNational,
                    Actif = employee.Actif,
                    Role = role,
                    Phones = employee.Phones,
                    Emails = employee.Emails,
                    Address = employee.Address,
                });

                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
      /// <summary>
      /// le données de detaieldemplyee.db
      /// </summary>
      /// <returns></returns>
      /// <exception cref="Exception"></exception>
        public List<Employee> GetAll()
        {
                if (_db.employees is not null)
                { 
                    List<Employee> requete = _db.DetailedEmployees
                        .Select((employee) => new Employee
                        {
                            Id = employee.Id,
                            firstName = employee.firstName,
                            SurName = employee.SurName
                        }).ToList();
                    return requete;
                }
                    else
                {
                    throw new Exception();
                }  
        }
        /// <summary>
        /// Renvoi de l'utilisateur on ajoute le nom du pays avec l'aide de l'id stocké dans Address.db
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DetailedEmployee GetOne(int id)
        {
            
            if(_db.DetailedEmployees is not null)
            { 
                try
                {
                    DetailedEmployee person = _db.DetailedEmployees
                                        .Where(e => e.Id == id)
                                        .Include(e => e.Phones)
                                        .Include(e => e.Emails)
                                        .Include(e => e.Address)
                                        .Include(e =>e.Role)
                                        .First();

                    Countrys country = _AllCountrys(person.Address.StateId);

                    person.Address.State = country.Country;
                    person.Address.StateId = country.Id;
                    return person;
                }
                catch(Exception) 
                {
                    return new DetailedEmployee();
                }  
            }
            else
            {
                return new DetailedEmployee();
            }

        }
        private Countrys _AllCountrys(int? id)
        {
            try
            {
                Countrys countrys = _db.Countrys
                    .Where(e => e.Id == id).First();
                return countrys;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}