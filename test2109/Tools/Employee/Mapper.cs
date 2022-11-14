using BusinessAccessLayer.Models.Employee;
using BUSI = BusinessAccessLayer.Models;
using TEST = test2109.Models;

namespace test2109.Tools.Employee
{
    public static class Mapper
    {
        public static BUSI.Employee.DetailedEmployee AddEmployee(this TEST.Employee.DetailEmployed employee)
        {
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
                RoleId = employee.RoleId
    };
        }
    }
}
