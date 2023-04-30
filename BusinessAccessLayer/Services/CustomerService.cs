using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Customers;
using DataAccess.Repository;
using DataAccess.Services;
using DATA = DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerServices _services;


        public CustomerService(IMapper mapper, ICustomerServices services)
        {
            _mapper = mapper;
            _services = services;
        }

        public Site deleteContact(int id)
        {
            return _mapper.Map<Site>(_services.deleteContact(id));
        }

        public string SiteDelete(int id)
        {
            return _services.SiteDelete(id);
        }

        public Customers GetOne(int id)
        {
            return _mapper.Map<Customers>(_services.GetOne(id));
        }
   
        public List<Customers> UpdateCustomer(AllCustomers customer)
        {
            var detail = _mapper.Map<DATA.Customer.AllCustomers>(customer);
            return _services.UpdateCustomer(detail).Select(dr => _mapper.Map<Customers>(dr)).ToList();
        }

        public string Delete(int id)
        {
            return _services.Delete(id);
        }

        public List<Customers> addContact(ContactPerson contact)
        {
            var detail = _mapper.Map<DATA.Customer.ContactPerson>(contact);
            return _services.addContact(detail).Select(dr => _mapper.Map<Customers>(dr)).ToList();
        }

        public Site PostContact(ContactPerson contact)
        {
            var detail = _mapper.Map<DATA.Customer.ContactPerson>(contact);
            return _mapper.Map<Site>(_services.PostContact(detail));
        }

        public int? AddSite(Site site)
        {
            var detail = _mapper.Map<DATA.Customer.Site>(site);
            return _services.AddSite(detail); 
        }

        public List<AllCustomers> All()
        {
            return _services.All().Select(dr => _mapper.Map<AllCustomers>(dr)).ToList();
        }

        public Site GetCustomer(int id)
        {
            Site site = _mapper.Map<Site>(_services.Get(id));
            return site;                   
        }

        public Site UpdateSite(Site site)
        {
            try
            {
                var detail = _mapper.Map<DATA.Customer.Site>(site);
                return _mapper.Map<Site>(_services.UpdateSite(detail));
            }
            catch (Exception)
            {
                return new Site();
            }
        }

        public int AddCustomer(Customers customers)
        {
            var detail = _mapper.Map<DATA.Customer.Customers>(customers);
            return _services.AddCustomer(detail);
        }
    }
}
