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
            foreach(var emplo in employee.Phones)
            {
                listPhone.Add(emplo._Phone());
            }
            
            foreach(var email in employee.Emails)
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
                Actif = employee.Actif,
                SecurityCard = employee.SecurityCard,
                RegistreNational = employee.RegistreNational,
                EmployeeCardNumber = employee.EmployeeCardNumber,
                EntryService = employee.EntryService,
                RoleId = employee.RoleId,
                Phones = listPhone,
                Emails= listEmail,
                
            };
            
        }

        private static BUSI.Employee.Phone _Phone(this TEST.Employee.Phone form)
        { 
            return new BUSI.Employee.Phone
            {
                Number = form.Number,
            };
        }
        private static BUSI.Employee.Email _Email(this TEST.Employee.Email form)
        {
            return new BUSI.Employee.Email
            {
                address = form.address
            };
        }
    }
}
