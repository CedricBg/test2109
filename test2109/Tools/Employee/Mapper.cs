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
            BUSI.Employee.DetailedEmployee employee1 = new BUSI.Employee.DetailedEmployee();


            foreach(var emplo in employee.Phones)
            {
                employee1.Phones.Add(emplo._Phone());
            }
            new BUSI.Employee.DetailedEmployee
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
                Phones = employee1.Phones
            };
            return employee1;
        }

        private static BUSI.Employee.Phone _Phone(this TEST.Employee.Phone form)
        { return new BUSI.Employee.Phone
            {
                Id = form.Id,
                Number= form.Number,
            };
        }
    }
}
