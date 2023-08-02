using AutoMapper;
using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using DataAccess.Tools;
using System.ComponentModel;
using DataAccess.Models.Employees;
using System.Linq;


namespace DataAccess.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly SecurityCompanyContext _context;
        private readonly IEmployeeServices _employeeServices;

        private readonly IMapper _Mapper;

        //constructeur
        public CustomerServices(SecurityCompanyContext context, IMapper mapper)
        {
            _context = context;
            _Mapper = mapper;

        }

        /// <summary>
        /// Retourne un client par rapport a son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un Customer</returns>
        public Customers GetOne(int id)
        {
            Customers customer = _context.Customers
                .Include(e => e.Contact).ThenInclude(y => y.Phone)
                .Include(e => e.Contact).ThenInclude(y => y.Email)
                .Include(e => e.Site.Where(y=>y.IsDeleted == false))
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
                Customers dBCust = _context.Customers
                    .Include(e => e.Contact).ThenInclude(y => y.Email)
                    .Include(e => e.Contact).ThenInclude(y => y.Phone)
                    .FirstOrDefault(e => e.CustomerId == cust.CustomerId);

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
                    .Include(e => e.Site.Where(y=>y.IsDeleted == false)).Where(e=>e.IsDeleted == false)
                    .ToList();

                return customers;
            }
        }

        /// <summary>
        /// Ne supprime pas mais passe l'attribut a isdeleted true.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>string error "deleted"</returns>
        public string Delete(int id)
        {
            try
            {
                Customers customer = _context.Customers.Find(id);
                customer.IsDeleted = true;
                _context.SaveChanges();

                return "Deleted";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// On passe la veriable a isDeleted pour simuler une suppression
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Le mot Delelted ou le message d'erreur</returns>
        public string SiteDelete(int id)
        {
            try
            {
                Site site = _context.Sites.FirstOrDefault(e => e.SiteId == id);
                site.IsDeleted = true;
                _context.SaveChanges();
                return "Deleted";
            }
            catch (Exception ex) 
            { 
                return ex.Message.ToString();
            }
        }

        /// <summary>
        /// Ajout d'un contact a client à la création d'un client
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public List<Customers> addContact(ContactPerson contact)
        {
            List<Customers> list = _context.Customers.Include(e=>e.Site.Where(y=>y.IsDeleted == false)).Where(y=>y.IsDeleted == false).ToList();
            if (contact == null)
                return list;
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
                            IsDeleted = false
                        };

                        site.ContactSite = new List<ContactPerson>();
                        site.ContactSite.Add(contactPerson);
                        _context.SaveChanges();

                        list = _context.Customers.Include(e => e.Site.Where(y => y.IsDeleted == false)).Where(y=>y.IsDeleted == false).ToList();
                        return list;
                    }
                    else
                    {
                        return list;
                    }

                }
                else
                {
                    return list;
                }
            }
        }

        /// <summary>
        /// Ajout d'un contact avec la mise à jour d'un site
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>un Site pour mise a jour de la vue</returns>
        public Site PostContact(ContactPerson contact)
        {
            if (contact == null)
                return new Site();
            else
            {

                if(_context.Sites.Where(e => e.SiteId == contact.SiteId).Any())
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
                            DayContact = contact.DayContact,
                            Responsible = contact.Responsible,
                            EmergencyContact = contact.EmergencyContact,
                            Created = DateTime.Now,
                            Email = contact.Email,
                            Phone = contact.Phone,
                            IsDeleted = false
                        };

                        site.ContactSite = new List<ContactPerson>();
                        site.ContactSite.Add(contactPerson);
                        _context.SaveChanges();
                        Site sites = _context.Sites
                            .Include(e => e.Address)
                            .Include(e => e.Language)
                            .Include(e => e.ContactSite.Where(y=>y.IsDeleted == false)).ThenInclude(y=>y.Email)          
                            .Include(e => e.ContactSite.Where(y=>y.IsDeleted == false)).ThenInclude(y=>y.Phone)          
                            .FirstOrDefault( e=>e.SiteId == contact.SiteId && e.IsDeleted == false);

                        Countrys countrys = _context.Countrys.Where(e => e.Id == site.Address.StateId).FirstOrDefault();
                        sites.Address.State = countrys.Country;
                        return sites;
                    }
                    else
                    {
                        return new Site();
                    }
                }
                else
                {
                    return new Site();
                }
            }

        }

        /// <summary>
        /// Ajout d'un site sans contact
        /// </summary>
        /// <param name="site"></param>
        /// <returns>Retorune L'id pour controle opu 0 en cas d'échec</returns>
        public int? AddSite(Site site)
        {
            if (site == null)
                return 0;
            else
            {
                if (!(_context.Sites.Where(e => e.Name == site.Name).Any()))
                {
                    Language language = _context.Languages.FirstOrDefault(c => c.Id == site.Language.Id);
                    string name = char.ToUpper(site.Name[0]) + site.Name.Substring(1);
                    _context.Sites.Add(new Site
                    {
                        Name = name,
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

        /// <summary>
        /// Suppresion d'un contact sur une site
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retourne un site pour mise à jour de la vue</returns>
        public Site deleteContact(int id)
        {
            try
            {
                ContactPerson contact = _context.ContactPersons
 
                    .FirstOrDefault(e => e.ContactId == id);
                int? idsite = contact.ContactSiteId;
                
                contact.IsDeleted = true;
                _context.SaveChanges();
                Site site = _context.Sites
                    .Include(e => e.ContactSite).ThenInclude(c => c.Phone)
                    .Include(e => e.ContactSite).ThenInclude(c => c.Email)
                    .Include(e=>e.Address)
                    .Include(e=>e.Language)
                    .FirstOrDefault(e => e.SiteId == idsite);


                Countrys countrys = _context.Countrys.Where(e=>e.Id == site.Address.StateId).FirstOrDefault();
                site.Address.State = countrys.Country;

                site.ContactSite = site.ContactSite.Where(c => c.IsDeleted == false).ToList();
                return site;
            }
            catch (Exception)
            {
                return new Site();
            }
        }

        /// <summary>
        /// Ajout d'un client nom + un contact
        /// </summary>
        /// <param name="customers"></param>
        /// <returns>Retourne l'id ou 0 en cas d'échec</returns>
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

        /// <summary>
        /// retourne liste de clients pour les formulaires
        /// </summary>
        /// <returns>Lists de clients</returns>
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
                        Site = Client.Site.sites()//extension pour passer de sites a AllSites dans le dossier mapping
                    }
                    ).ToList();
            }
            return customers;
        }

        /// <summary>
        /// Retoruen un site par rapport à l'id du Customer(client)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorune unSite</returns>
        public Site Get(int id)
        {
            Site site = _context.Sites
                .Include(y => y.Address)
                .Include(x => x.Language)
                .Include(x => x.ContactSite.Where(e=>e.IsDeleted == false)).ThenInclude(x => x.Phone)
                .Include(x => x.ContactSite.Where(e => e.IsDeleted == false)).ThenInclude(x => x.Email)
                .FirstOrDefault(e => e.SiteId == id && e.IsDeleted == false);


            if (site != null)
            {
                Countrys countrys = Country(site.Address.StateId);
                site.Address.State = countrys.Country;
            }

            return site ?? new Site();
        }

        /// <summary>
        /// Mise jour d'un Site
        /// </summary>
        /// <param name="site"></param>
        /// <returns>Retorune une liste de site pour mise à jour de la vue</returns>
        public Site UpdateSite(Site site)
        {
            if (_context.Sites.First().Name != null)
            {
                Language language = _context.Languages.FirstOrDefault(c => c.Id == site.Language.Id);
                Site dBSite = _context.Sites.Where(e => e.SiteId == site.SiteId )
                    .Include(y => y.Address)
                    .Include(x => x.ContactSite.Where(e => e.IsDeleted == false)).ThenInclude(x => x.Phone)
                    .Include(x => x.ContactSite.Where(e => e.IsDeleted == false)).ThenInclude(x => x.Email)
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
                    dBcontact.DayContact = contact.DayContact;

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

                Site siteSearch = _context.Sites.Where(s => s.Name == site.Name).FirstOrDefault();
                if (siteSearch == null)
                {
                    string name = char.ToUpper(site.Name[0]) + site.Name.Substring(1);
                    dBSite.Name = name;
                }
                _context.SaveChanges();
                return dBSite;
            }
            else
            {
                return new Site();
            }
        }

        /// <summary>
        /// Retourne objet country pour la gestion des pays dans les formulaires
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un Country</returns>
        /// <exception cref="Exception"></exception>
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
