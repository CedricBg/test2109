using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DATA = DataAccess.Models;
using BUSI = BusinessAccessLayer.Models;

namespace BusinessAccessLayer.Tools.Employee
{
    public static class Mapper
    {
        public static DATA.Employee PostAnEmployee(this BUSI.Employees busi)
        {
            return new DATA.Employee
            {
                firstName = busi.firstName,
                SurName = busi.SurName,
                RegistreNational = busi.RegistreNational,
                BirthDate = busi.BirthDate,
                Actif = busi.Actif,
                SecurityCard = busi.SecurityCard,   
                Vehicle = busi.Vehicle, 
                EmployeeCardNumber = busi.EmployeeCardNumber,
                EntryService = busi.EntryService,

                
            };
        }

        public static BUSI.Employees GetAllEmployee(this DATA.Employee data)
        {
            return new BUSI.Employees
            {
                Id = data.Id,
                firstName = data.firstName,
                SurName = data.SurName,
                RegistreNational = data.RegistreNational,
                BirthDate = data.BirthDate,
                Actif = data.Actif,
                SecurityCard = data.SecurityCard,
                Vehicle = data.Vehicle,
                EmployeeCardNumber = data.EmployeeCardNumber,
                EntryService = data.EntryService,
    };
        }
    }
}
