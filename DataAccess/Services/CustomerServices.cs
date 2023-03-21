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

        public List<Customers> All()
        {
            if (_context.Customers != null)
            {
                List<Customers> customers = _context.Customers
                    .Where(e => e.IsDeleted == false && e.Role.Name == "Client")
                    .Select((Client) => new Customers
                    {
                        NameCustomer = Client.NameCustomer,
                        Id = Client.Id,
                        Role = Client.Role,
                    }
                    ).ToList();

                return customers;
            }
            else { return new List<Customers>(); }
        }

        public Customers Get(int id) 
        {
            if(_context.Customers != null)
            {
                Customers customer =  _context.Customers
                    .Where(e => e.Id == id)
                    .Include(x=>x.Site).ThenInclude(y=>y.Adress)
                    .Include(y=>y.Site).ThenInclude(x=>x.Language)
                    .Include(y=>y.Site).ThenInclude(x=>x.contacts)
                    .Include(y=>y.Site).ThenInclude(x=>x.GeneralEmail)
                    .Include(y=>y.Site).ThenInclude(x=>x.EmergencyEmail)
                    .Include(y=>y.Site).ThenInclude(x=>x.GeneralPhone)
                    .Include(y=>y.Site).ThenInclude(x=>x.EmergencyPhone)

                    .First();
                 
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
                .Include (x=>x.Role)
                .Include (x=>x.NameCustomer)
                .FirstOrDefault(c => c.Id == customers.Id);


            //insertEmails(customers.EmergencyEmail, customers1.EmergencyEmail);
            //insertEmails(customers.GeneralEmail, customers1.GeneralEmail);
            //insertPhones(customers.GeneralPhone, customers1.GeneralPhone);
            //insertPhones(customers.EmergencyPhone, customers1.EmergencyPhone);


            //foreach (var elt in customers.Address)
            //{
            //    var existingPerson = _context.Address.Find(elt.AddressId);
            //    if (existingPerson != null)
            //        existingPerson.SreetAddress = elt.SreetAddress;
            //        existingPerson.City = elt.City;
            //        existingPerson.StateId = elt.StateId;
            //        existingPerson.ZipCode = elt.ZipCode;
                    

            //    if (existingPerson == null)
            //        customers1.Address.Add(elt);
            //}

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
