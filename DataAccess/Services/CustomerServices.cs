using AutoMapper;
using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using DataAccess.Tools;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly SecurityCompanyContext _context;
        private readonly IEmployeeServices _employeeServices;

        private readonly IMapper _Mapper;

        public CustomerServices(SecurityCompanyContext context, IMapper mapper)
        {
            _context = context;
            _Mapper = mapper;
        }

        public List<AllCustomers> All()
        {
            if (_context.Customers != null)
            {
                List<AllCustomers> customers = _context.Customers
                    .Where(e => e.IsDeleted == false && e.Role.Name == "Client")
                    .Select((Client) => new AllCustomers
                    {
                        
                        NameCustomer = Client.NameCustomer,
                        Id = Client.CustomerId,
                        Site = Client.Site.sites()
                    }
                    ).ToList();

                return customers;
            }
            else { return new List<AllCustomers>(); }
        }

        public Site Get(int id) 
        {
            if(_context.Customers != null)
            {
                Site site =  _context.Sites.Where(e => e.SiteId == id)
                    .Include(y => y.Address)
                    .Include(x => x.Language)
                    .Include(x => x.EmergencyContacts).ThenInclude(x=> x.Phone)
                    .Include(x => x.EmergencyContacts).ThenInclude(x=> x.Email)
                    .Include(x => x.GeneralContacts).ThenInclude(x => x.Phone)
                    .Include(x => x.GeneralContacts).ThenInclude(x => x.Email)

                    .First();

                    Countrys countrys = Country(site.Address.StateId);
                    site.Address.State = countrys.Country;

                return site;
            }
            else
            {
                return new Site();
            }
        }

        public Customers Update(Customers customers)
        {
            if(customers == null)
                return null;

            Customers customers1 = _context.Customers
                .Include (x=>x.Role)
                .Include (x=>x.NameCustomer)
                .FirstOrDefault(c => c.CustomerId == customers.CustomerId);


            return customers1;
        }
        private void insertEmails(List<Email> emails,List<Email> customers1)
        {
            foreach (var elt in emails)
            {
                var existingEmail = _context.EmailAddresses.Find(elt.EmailId);
                if (existingEmail != null)
                    existingEmail.EmailAddress = elt.EmailAddress;
                if (existingEmail == null)
                    customers1.Add(elt);
            }
        }
        private void insertPhones(List<Phone> phones, List<Phone> customers1)
        {
            foreach (var elt in phones)
            {
                var existingPhone = _context.Phones.Find(elt.PhoneId);
                if (existingPhone != null)
                    existingPhone.Number = elt.Number;
                if (existingPhone == null)
                    customers1.Add(elt);
            }
        }
        private Countrys Country(int? id)
        {
            try
            {
                Countrys countrys = _context.Countrys
                    .Where(e => e.Id == id).First();
                return countrys;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
