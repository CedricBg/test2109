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

        public Customers Get(int id) 
        {
            if(_context.Customers != null)
            {
                Customers customer =  _context.Customers
                    .Where(e => e.Id == id)
                    .Include(x=>x.Address)
                    .Include(x=>x.Language)
                    .Include(x=>x.Role)
                    .Include(x=>x.EmergencyPhone)
                    .Include(x=>x.GeneralPhone)
                    .Include(x=>x.EmergencyEmail)
                    .Include(x=>x.GeneralEmail)
                    .Include(x=>x.ContactPerson)
                    .First();
               
                foreach(var elt in customer.Address)
                {
                    Countrys country = Country(elt.StateId);
                    elt.State = country.Country;
                }
                   
                return customer;
            }
            else
            {
                return new Customers();
            }
        }

        public Customers Update(Customers customers)
        {
            if(customers == null)
                return null;

            Customers customers1 = _context.Customers
                .Include(x=>x.Address)
                .Include(x=>x.Language)
                .Include (x=>x.Role)
                .Include(x=>x.EmergencyEmail)
                .Include(x=>x.GeneralPhone)
                .Include(x=>x.ContactPerson)
                .Include(x=>x.GeneralEmail)
                .Include(x=>x.EmergencyPhone)
                .FirstOrDefault(c => c.Id == customers.Id);


            insertEmails(customers.EmergencyEmail, customers1.EmergencyEmail);
            insertEmails(customers.GeneralEmail, customers1.GeneralEmail);
            insertPhones(customers.GeneralPhone, customers1.GeneralPhone);
            insertPhones(customers.EmergencyPhone, customers1.EmergencyPhone);

            foreach(var elt in customers.ContactPerson)
            {
                var existingPerson = _context.ContactPersons.Find(elt.Id);
                if (existingPerson != null)
                    existingPerson.FirstName = elt.FirstName;
                if(existingPerson == null)
                    customers1.ContactPerson.Add(elt);
            }

            foreach (var elt in customers.Address)
            {
                var existingPerson = _context.Address.Find(elt.AddressId);
                if (existingPerson != null)
                    existingPerson.SreetAddress = elt.SreetAddress;
                    existingPerson.City = elt.City;
                    existingPerson.StateId = elt.StateId;
                    existingPerson.ZipCode = elt.ZipCode;
                    

                if (existingPerson == null)
                    customers1.Address.Add(elt);
            }

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
