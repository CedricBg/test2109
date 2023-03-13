using AutoMapper;
using AutoMapper.Internal;
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
                Role role = _db.Roles.FirstOrDefault(c =>c.roleId == employee.Role.roleId);

                _db.DetailedEmployees.Add(new DetailedEmployee
                {
                    firstName = employee.firstName,
                    SurName = employee.SurName,
                    CreationDate = DateTime.UtcNow,
                    BirthDate = employee.BirthDate,
                    Vehicle = employee.Vehicle,
                    SecurityCard = employee.SecurityCard,
                    EmployeeCardNumber = employee.EmployeeCardNumber,
                    RegistreNational = employee.RegistreNational,
                    Role = role,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    Address = employee.Address,
                    IsDeleted = false
                });
                try
                {
                    _db.SaveChanges();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public DetailedEmployee UpdateEmployee(DetailedEmployee employee)
        {
            if (_db.DetailedEmployees.First().Id != null)
            {
                Role role = _db.Roles.FirstOrDefault(c => c.roleId == employee.Role.roleId);
                DetailedEmployee dBemployee = _db.DetailedEmployees.Where(e=> e.Id == employee.Id)
                    .Include("Email")
                    .Include("Phone")
                    .Include("Address")
                    .Include("Role")
                    .FirstOrDefault();
                
                foreach(var phone in employee.Phone)
                {
                    var existingPhone = _db.Phones.Find(phone.PhoneId);
                    if (existingPhone != null)
                    {
                        existingPhone.Number = phone.Number; 
                    }
                }

                foreach(var email in employee.Email)
                {
                    var existingEmail = _db.EmailAddresses.Find(email.EmailId);
                    if(existingEmail != null)
                    {
                        existingEmail.EmailAddress = email.EmailAddress;
                    }
                }
                var existingAdrress = _db.Address.Find(employee.Address.AddressId);
                    if(existingAdrress != null)
                    {
                        existingAdrress.SreetAddress = employee.Address.SreetAddress;
                        existingAdrress.StateId = employee.Address.StateId;
                        existingAdrress.State = employee.Address.State;
                        existingAdrress.City = employee.Address.City;
                        existingAdrress.ZipCode = employee.Address.ZipCode;
                    }
                        

                    if (dBemployee.Role.roleId != employee.Role.roleId && dBemployee.Id != 1) dBemployee.Role = role;
                if (dBemployee.Email != employee.Email) dBemployee.Email = employee.Email;
                if (dBemployee.Phone != employee.Phone) dBemployee.Phone = employee.Phone;
                if(dBemployee.firstName != employee.firstName) dBemployee.firstName = employee.firstName;
                if(dBemployee.SurName != employee.SurName) dBemployee.SurName = employee.SurName;
                if (dBemployee.EmployeeCardNumber != employee.EmployeeCardNumber) dBemployee.EmployeeCardNumber = employee.EmployeeCardNumber;
                if (dBemployee.SecurityCard != employee.SecurityCard) dBemployee.SecurityCard = employee.SecurityCard;

                _db.SaveChanges();
                return dBemployee;
            }
            else 
            { 
                return null; 
            }

        }
        public List<Employee> GetAll()
        {
                if (_db.employees is not null)
                { 
                    List<Employee> requete = _db.DetailedEmployees
                    .Where(e=>e.IsDeleted == false)
                        .Select((employee) => new Employee
                        {
                            Id = employee.Id,
                            firstName = employee.firstName,
                            SurName = employee.SurName,
                        }).ToList();
                    return requete;
                }
                    else
                {
                    throw new Exception();
                }  
        }


        public DetailedEmployee GetOne(int id)
        {  
            if(_db.DetailedEmployees is not null)
            { 
                try
                {
                    DetailedEmployee person = _db.DetailedEmployees
                                        .Where(e => e.Id == id)
                                        .Include(e => e.Phone)
                                        .Include(e => e.Email)
                                        .Include(e => e.Address)
                                        .Include(e =>e.Role)
                                        .First();
                    Countrys country = _Country(person.Address.StateId);

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
        private Countrys _Country(int? id)
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
        public bool Deactive(int id)
        {
            if(_db.DetailedEmployees.First().Id != null && id != 1)
            {
                DetailedEmployee detailedEmployee =  _db.DetailedEmployees.Where(e => e.Id == id).FirstOrDefault();
                if(detailedEmployee.IsDeleted == true)
                {
                    return false;
                }
                detailedEmployee.IsDeleted = true;
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
