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
    }
}
