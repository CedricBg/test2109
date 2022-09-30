using BUSI = BusinessAccessLayer.Models;
using TEST = test2109.Models;

namespace test2109.Tools.Employee
{
    public static class Mapper
    {
        public static BUSI.Employees AddEmployee(this TEST.Employee employee)
        {
            return new BUSI.Employees
            {
                firstName = employee.firstName,
                BirthDate = employee.BirthDate,
                SurName = employee.SurName,
                Vehicle = employee.Vehicle,
                Actif = employee.Actif,
                SecurityCard = employee.SecurityCard,
                RegistreNational = employee.RegistreNational,
                EmployeeCardNumber = employee.EmployeeCardNumber,
                EntryService = employee.EntryService,
            };
        }
    }
}
