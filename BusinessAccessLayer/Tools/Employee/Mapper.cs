using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DATA = DataAccess.Models;
using BUSI = BusinessAccessLayer.Models;
using BusinessAccessLayer.Models.Employee;

namespace BusinessAccessLayer.Tools.Employee
{
    public static class Mapper
    {
        public static DATA.Employees.DetailedEmployee PostAnEmployee(this BUSI.Employee.DetailedEmployee busi)
        {
            List<DATA.Phone> listPhone = new List<DATA.Phone>();
            List<DATA.Email> listEmail = new List<DATA.Email>();
            foreach(var elt in busi.Phones)
            {
                listPhone.Add(elt._Phone());
            }
            foreach(var elt in busi.Emails)
            {
                listEmail.Add(elt._Email());
            }

            return new DATA.Employees.DetailedEmployee
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
                RoleId = busi.RoleId,
                Phones= listPhone,
                Emails= listEmail,
            };
        }

        private static DATA.Phone _Phone(this BUSI.Employee.Phone phone)
        {
            return new DATA.Phone
            {
                Number = phone.Number,
            };
        }
        private static DATA.Email _Email(this BUSI.Employee.Email phone)
        {
            return new DATA.Email
            {
                EmailAddress = phone.address,
            };
        }

        public static BUSI.Employee.Employee GetAllEmployee(this DATA.Employees.Employee data)
        {
            return new BUSI.Employee.Employee
            {
                Id = data.Id,
                firstName = data.firstName,
                SurName = data.SurName,
  
            };
        }
    }
}
