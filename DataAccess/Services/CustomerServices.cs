using AutoMapper;
using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using DataAccess.Tools;
using System.ComponentModel;
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

        public Customers GetOne(int id)
        {
            Customers customer = _context.Customers
                .Include(e => e.Contact).ThenInclude(y => y.Phone)
                .Include(e => e.Contact).ThenInclude(y => y.Email)
                .Include(e => e.Site)
                .FirstOrDefault(e => e.CustomerId == id);
            if (customer != null)
            {
                return customer;
            }
            else
            {
                return new Customers();
            }
        }

        /// <summary>
        /// Mise a jour du nom du client ou de la personne de contact pour le Customer pas les sites !!!
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>
        /// le nom du client
        /// </returns>
        public List<Customers> UpdateCustomer(AllCustomers cust)
        {
            if (cust == null) return new List<Customers>();
            else
            {
                Customers dBCust = _context.Customers.Where(e => e.CustomerId == cust.CustomerId)
                    .Include(e => e.Contact).ThenInclude(y => y.Email)
                    .Include(e => e.Contact).ThenInclude(y => y.Phone)
                    .FirstOrDefault();

                if (dBCust == null) return new List<Customers>();
                else
                {
                    if (dBCust.Contact != null)
                    {
                        dBCust.NameCustomer = cust.NameCustomer;
                        dBCust.Contact.FirstName = cust.Contact.FirstName;
                        dBCust.Contact.LastName = cust.Contact.LastName;
                        dBCust.Contact.Responsible = cust.Contact.Responsible;
                        dBCust.Contact.EmergencyContact = cust.Contact.EmergencyContact;
                        dBCust.Contact.NightContact = cust.Contact.NightContact;
                   
                    var emailIdsToRemove = dBCust.Contact.Email
                       .Where(email => !cust.Contact.Email.Any(e => e.EmailId == email.EmailId))
                       .Select(email => email.EmailId)
                       .ToList();

                    foreach (var emailId in emailIdsToRemove)
                    {
                        var emailToRemove = _context.EmailAddresses.Find(emailId);
                        _context.EmailAddresses.Remove(emailToRemove);
                    }

                    var phonesIdsToRemove = dBCust.Contact.Phone
                        .Where(phone => !cust.Contact.Phone.Any(e => e.PhoneId == phone.PhoneId))
                        .Select(phone => phone.PhoneId)
                        .ToList();

                    foreach (var phoneId in phonesIdsToRemove)
                    {
                        var phoneToRemove = _context.Phones.Find(phoneId);
                        _context.Phones.Remove(phoneToRemove);
                    }

                    foreach (Phone phone in cust.Contact.Phone)
                    {
                        var existingPhone = _context.Phones.Find(phone.PhoneId);
                        if (phone != null && existingPhone != null)
                        {
                            existingPhone.Number = phone.Number;
                        }
                        if (phone.PhoneId == null || existingPhone == null)
                        {
                            dBCust.Contact.Phone.Add(phone);
                        }
                    }
                    foreach (Email email in cust.Contact.Email)
                    {
                        var existingMail = _context.EmailAddresses.Find(email.EmailId);
                        if (email != null && existingMail != null)
                        {
                            existingMail.EmailAddress = email.EmailAddress;
                        }
                        if (email.EmailId == null || existingMail == null)
                        {
                            dBCust.Contact.Email.Add(email);
                        }
                    }
                    }
                    else
                    {
                        ContactPerson contactPerson = new ContactPerson
                        {
                            FirstName = cust.Contact.FirstName,
                            LastName = cust.Contact.LastName,
                            NightContact = cust.Contact.NightContact,
                            Responsible = cust.Contact.Responsible,
                            EmergencyContact = cust.Contact.EmergencyContact,
                            Created = DateTime.Now,
                            Email = cust.Contact.Email,
                            Phone = cust.Contact.Phone,
                        };
                        dBCust.Contact = contactPerson;
                    }
                    _context.SaveChanges();
                }
                List<Customers> customers = _context.Customers
                    .Include(e => e.Contact).ThenInclude(e => e.Phone)
                    .Include(e => e.Contact).ThenInclude(e => e.Email)
                    .ToList();

                return customers;
            }
        }

        /// <summary>
        /// Ne supprime pas mais passe l'attribut a isdeleted true.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>string error "deleted"</returns>
        ///
        public string Delete(int id)
        {
            try
            {
                Customers customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
                customer.IsDeleted = true;
                _context.SaveChanges();

                return "Deleted";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public int addContact(ContactPerson contact)
        {
            if (contact == null)
                return 0;
            else
            {

                if (_context.Sites.Where(e => e.SiteId == contact.SiteId).Any())
                {
                    Site site = _context.Sites.FirstOrDefault(c => c.SiteId == contact.SiteId);
                    ContactPerson contact1 = _context.ContactPersons.Where(e => e.LastName == contact.LastName && e.FirstName == contact.FirstName && e.ContactSiteId == contact.SiteId).FirstOrDefault();
                    if (contact1 == null)
                    {
                        ContactPerson contactPerson = new ContactPerson
                        {
                            FirstName = contact.FirstName,
                            LastName = contact.LastName,
                            NightContact = contact.NightContact,
                            Responsible = contact.Responsible,
                            EmergencyContact = contact.EmergencyContact,
                            Created = DateTime.Now,
                            Email = contact.Email,
                            Phone = contact.Phone,
                        };

                        site.ContactSite = new List<ContactPerson>();
                        site.ContactSite.Add(contactPerson);
                        _context.SaveChanges();
                        ContactPerson contact2 = _context.ContactPersons.Where(e => e.LastName == contact.LastName && e.ContactSiteId == contact.SiteId).First();
                        return contact2.ContactId;
                    }
                    else
                    {
                        return 0;
                    }

                }
                else
                {
                    return 0;
                }
            }
        }

        public int? AddSite(Site site)
        {
            if (site == null)
                return 0;
            else
            {
                if (!(_context.Sites.Where(e => e.Name == site.Name).Any()))
                {
                    Language language = _context.Languages.FirstOrDefault(c => c.Id == site.Language.Id);
                    _context.Sites.Add(new Site
                    {
                        Name = site.Name,
                        Address = site.Address,
                        IsDeleted = false,
                        Language = language,
                        CustomersId = site.CustomerIdCreate,
                        VatNumber = site.VatNumber,
                        CreationDate = DateTime.Now

                    });
                    _context.SaveChanges();
                    Site site1 = _context.Sites.Where(e => e.Name == site.Name).First();
                    return site1.SiteId;
                }
                return 0;
            }
        }

        public int AddCustomer(Customers customers)
        {
            if (customers != null && !(_context.Customers.Where(e => e.NameCustomer == customers.NameCustomer).Any()))
            {
                Role role = _context.Roles.FirstOrDefault(c => c.roleId == 21);
                customers.Role = role;
                customers.CreationDate = DateTime.Now;
                customers.IsDeleted = false;
                _context.Customers.Add(customers);

                _context.SaveChanges();

                Customers IdNewCustomer = _context.Customers.Where(e => e.NameCustomer == customers.NameCustomer).First();
                return IdNewCustomer.CustomerId;
            }
            return 0;
        }

        public List<AllCustomers> All()
        {
            List<AllCustomers> customers = new List<AllCustomers>();
            if (_context.Customers != null)
            {
                customers = _context.Customers
                    .Where(e => e.IsDeleted == false && e.Role.Name == "Client")
                    .Select((Client) => new AllCustomers
                    {
                        NameCustomer = Client.NameCustomer,
                        CustomerId = Client.CustomerId,
                        Contact = Client.Contact,
                        Site = Client.Site.sites()
                    }
                    ).ToList();
            }
            return customers;
        }

        public Site Get(int id)
        {
            Site site = _context.Sites.Where(e => e.SiteId == id)
                .Include(y => y.Address)
                .Include(x => x.Language)
                .Include(x => x.ContactSite).ThenInclude(x => x.Phone)
                .Include(x => x.ContactSite).ThenInclude(x => x.Email)
                .FirstOrDefault();

            if (site != null)
            {
                Countrys countrys = Country(site.Address.StateId);
                site.Address.State = countrys.Country;
            }

            return site ?? new Site();
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
                    dBcontact.FirstName = contact.FirstName;
                    dBcontact.LastName = contact.LastName;
                    dBcontact.Responsible = contact.Responsible;
                    dBcontact.EmergencyContact = contact.EmergencyContact;
                    dBcontact.NightContact = contact.NightContact;

                    var emailIdsToRemove = dBcontact.Email
                   .Where(email => !contact.Email.Any(e => e.EmailId == email.EmailId))
                   .Select(email => email.EmailId)
                   .ToList();

                    foreach (var emailId in emailIdsToRemove)
                    {
                        var emailToRemove = _context.EmailAddresses.Find(emailId);
                        _context.EmailAddresses.Remove(emailToRemove);
                    }
                    var phonesIdsToRemove = dBcontact.Phone
                    .Where(phone => !contact.Phone.Any(e => e.PhoneId == phone.PhoneId))
                    .Select(phone => phone.PhoneId)
                    .ToList();

                    foreach (var phoneId in phonesIdsToRemove)
                    {
                        var phoneToRemove = _context.Phones.Find(phoneId);
                        _context.Phones.Remove(phoneToRemove);
                    }

                    foreach (Phone phone in contact.Phone)
                    {
                        var existingPhone = _context.Phones.Find(phone.PhoneId);
                        if (phone != null && existingPhone != null)
                        {
                            existingPhone.Number = phone.Number;
                        }
                        if (phone.PhoneId == null || existingPhone == null)
                        {
                            dBcontact.Phone.Add(phone);
                        }
                    }
                    foreach (Email email in contact.Email)
                    {
                        var existingMail = _context.EmailAddresses.Find(email.EmailId);
                        if (email != null && existingMail != null)
                        {
                            existingMail.EmailAddress = email.EmailAddress;
                        }
                        if (email.EmailId == null || existingMail == null)
                        {
                            dBcontact.Email.Add(email);
                        }
                    }
                }
                dBSite.Language = language;
                dBSite.VatNumber = site.VatNumber;
                var existingAdrress = _context.Address.Find(site.Address.AddressId);
                existingAdrress.SreetAddress = site.Address.SreetAddress;
                existingAdrress.StateId = site.Address.StateId;
                existingAdrress.State = site.Address.State;
                existingAdrress.City = site.Address.City;
                existingAdrress.ZipCode = site.Address.ZipCode;

                var siteSearch = _context.Sites.Where(s => s.Name == site.Name).FirstOrDefault();
                if (siteSearch == null)
                {
                    dBSite.Name = site.Name;
                }
                _context.SaveChanges();
                return dBSite;
            }
            else
            {
                return new Site();
            }
        }

        private Countrys Country(int? id)
        {
            try
            {
                return _context.Countrys
                    .FirstOrDefault(e => e.Id == id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
