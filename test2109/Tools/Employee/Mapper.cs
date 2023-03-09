using BusinessAccessLayer.Models.Employee;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using BUSI = BusinessAccessLayer.Models;
using TEST = test2109.Models;

namespace test2109.Tools.Employee
{
    public static class Mapper
    {
        public static BUSI.Employee.DetailedEmployee AddEmployee(this TEST.Employee.DetailEmployed employee)
        {
            
            List<Phone> listPhone = new List<Phone>();
            List<Email> listEmail = new List<Email>();  
            foreach(var emplo in employee.Phone)
            {
                listPhone.Add(emplo._Phone());
            }
            
            foreach(var email in employee.Email)
            {
                listEmail.Add(email._Email());
            }
            
            return new BUSI.Employee.DetailedEmployee
            {
                Id = employee.Id,
                firstName = employee.firstName,
                BirthDate = employee.BirthDate,
                SurName = employee.SurName,
                Vehicle = employee.Vehicle,
                SecurityCard = employee.SecurityCard,
                RegistreNational = employee.RegistreNational,
                EmployeeCardNumber = employee.EmployeeCardNumber,
                EntryService = employee.EntryService,
                Role = employee.Role._Role(),
                Phone = listPhone,
                Email = listEmail,
                Address = employee.Address._Address(),  
            }; 
        }

        private static BUSI.Employee.Address _Address(this TEST.Address form)
        {
            return new BUSI.Employee.Address
            {
                Id= form.Id,
                SreetAddress = form.SreetAddress,
                City = form.City,
                ZipCode = form.ZipCode,
                State = form.State,
                StateId = form.StateId,

            };
        }

        private static BusinessAccessLayer.Models.Role _Role(this TEST.Role model)
        {
            return new BusinessAccessLayer.Models.Role
            {
                DiminName = model.DiminName,
                Name = model.Name,
                roleId = model.roleId,
            };
        }

        private static BUSI.Employee.Phone _Phone(this TEST.Employee.Phone form)
        { 
            return new BUSI.Employee.Phone
            {
                PhoneId = form.PhoneId,
                Number = form.Number,
            };
        }
        private static BUSI.Employee.Email _Email(this TEST.Employee.Email form)
        {
            return new BUSI.Employee.Email
            {
                EmailId = form.EmailId,
                EmailAddress = form.EmailAddress
            };
        }
    }
}
