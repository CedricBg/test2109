using AutoMapper;
using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using DataAccess.Tools;
using DataAccess.Models.Employees;


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
                        Contact = Client.Contact,
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
                    .Include(x => x.ContactSite).ThenInclude(x=> x.Phone)
                    .Include(x => x.ContactSite).ThenInclude(x=> x.Email)
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

       




        public Site UpdateSite(Site site)
        {
            if (_context.Sites.First().Name != null)
            {
                Language language = _context.Languages.FirstOrDefault(c => c.Id == site.Language.Id);

                Site dBSite = _context.Sites.Where(e => e.SiteId == site.SiteId)
                    .Include(y => y.Address)
                    .Include(x => x.ContactSite).ThenInclude(x => x.Phone)
                    .Include(x => x.ContactSite).ThenInclude(x => x.Email)
                    .Include(x => x.Language)
                    .FirstOrDefault();

                foreach (ContactPerson contact in site.ContactSite)
                {
                    var dBcontact = dBSite.ContactSite.Find(e => e.ContactId == contact.ContactId);
                    if(contact.FirstName != dBcontact.FirstName) dBcontact.FirstName = contact.FirstName;
                    if(contact.LastName != dBcontact.LastName) dBcontact.LastName = contact.LastName;
                    if(contact.responsible != dBcontact.responsible) dBcontact.responsible = contact.responsible;
                    if(contact.EmergencyContact != dBcontact.EmergencyContact) dBcontact.EmergencyContact = contact.EmergencyContact;
                    if(contact.NightContact != dBcontact.NightContact) dBcontact.NightContact = contact.NightContact;

                    foreach (Phone phone in contact.Phone)
                    {
                        var existingPhone = _context.Phones.Find(phone.PhoneId);
                        if (phone != null)
                        {
                            existingPhone.Number = phone.Number;
                        }
                        if (phone.PhoneId == null)
                        {
                            dBcontact.Phone.Add(phone);
                        }
                    }
                    foreach(Email email in contact.Email)
                    {
                        var existingMail = _context.EmailAddresses.Find(email.EmailId);
                        if(email !=null)
                        {
                            existingMail.EmailAddress = email.EmailAddress;
                        }
                        if(email.EmailId == null)
                        {
                            dBcontact.Email.Add(email);
                        }
                    }
                }
                if (dBSite.Language.Id != site.Language.Id) dBSite.Language = language;
                if (dBSite.Name != site.Name) dBSite.Name = site.Name;
                
                
                var existingAdrress = _context.Address.Find(site.Address.AddressId);
                if (existingAdrress != null)
                {
                    existingAdrress.SreetAddress = site.Address.SreetAddress;
                    existingAdrress.StateId = site.Address.StateId;
                    existingAdrress.State = site.Address.State;
                    existingAdrress.City = site.Address.City;
                    existingAdrress.ZipCode = site.Address.ZipCode;
                }
                _context.SaveChanges();
                return dBSite;
            }
            else
            {
                return new Site();
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

        private void insertEmails(List<Email> emails, List<Email> contact)
        {
            foreach (var elt in emails)
            {
                var existingEmail = _context.EmailAddresses.Find(elt.EmailId);
                if (existingEmail != null)
                    existingEmail.EmailAddress = elt.EmailAddress;
                if (existingEmail == null)
                    contact.Add(elt);
            }
        }
    }
}
