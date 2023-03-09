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
            foreach(var elt in busi.Phone)
            {
                listPhone.Add(elt._Phone());
            }
            foreach(var elt in busi.Email)
            {
                listEmail.Add(elt._Email());
            }

            return new DATA.Employees.DetailedEmployee
            {
                Id = busi.Id,
                firstName = busi.firstName,
                SurName = busi.SurName,
                RegistreNational = busi.RegistreNational,
                BirthDate = busi.BirthDate,
                SecurityCard = busi.SecurityCard,
                Vehicle = busi.Vehicle,
                EmployeeCardNumber = busi.EmployeeCardNumber,
                Role = busi.Role._Role(),
                Phone = listPhone,
                Email = listEmail,
                Address = busi.Address._address(),
            };
        }

        private static DATA.Address _address(this BUSI.Employee.Address address)
        {
            return new DATA.Address
            {
                Id = address.Id,
                SreetAddress = address.SreetAddress,
                City = address.City,
                State = address.State,
                StateId = address.StateId,
                ZipCode = address.ZipCode,
            };
        }

        private static DATA.Role _Role(this BUSI.Role role)
        {
            return new DATA.Role
            {
                DiminName = role.DiminName,
                Name = role.Name,
                roleId = role.roleId,
            };
        }

        private static DATA.Phone _Phone(this BUSI.Employee.Phone phone)
        {
            return new DATA.Phone
            {
                PhoneId = phone.PhoneId,
                Number = phone.Number,
            };
        }
        private static DATA.Email _Email(this BUSI.Employee.Email phone)
        {
            return new DATA.Email
            {
                EmailId = phone.EmailId,
                EmailAddress = phone.EmailAddress,
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
