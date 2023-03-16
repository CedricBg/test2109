using AutoMapper;
using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly SecurityCompanyContext _context;

        private readonly IMapper _Mapper;

        public CustomerServices(SecurityCompanyContext context, IMapper mapper)
        {
            _context = context;
            _Mapper = mapper;
        }

        public List<CustomerAll> All()
        {
            if (_context.Customers != null)
            {
                List<CustomerAll> customers = _context.Customers
                    .Where(e => e.IsDeleted == false && e.Role.Name == "Client")
                    .Include("EmergencyPhone")
                    .Include("GeneralPhone")
                    .Include("EmergencyEmail")
                    .Include("GeneralEmail")
                    .Include("ContactPerson")
                    .Include("Language")
                    .Select((Client) => new CustomerAll
                    {
                        Id = Client.Id,
                        NameCustomer = Client.NameCustomer,
                        GeneralEmail = Client.GeneralEmail,
                        EmergencyEmail = Client.EmergencyEmail,
                        GeneralPhone = Client.GeneralPhone,
                        EmergencyPhone = Client.EmergencyPhone,
                        Language = Client.Language,
                        ContactPerson = Client.ContactPerson
                    }
                    ).ToList();

                return customers;
            }
            else { return new List<CustomerAll>(); }
        }


    }
}
