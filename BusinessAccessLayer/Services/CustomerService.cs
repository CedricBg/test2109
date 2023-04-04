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

        public int addContact(ContactPerson contact)
        {
            var detail = _mapper.Map<DATA.Customer.ContactPerson>(contact);
            return _services.addContact(detail);
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
        public int AddCustomer(string customers)
        {
            return _services.AddCustomer(customers);
        }
    }
}
