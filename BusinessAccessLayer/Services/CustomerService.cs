using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Customers;
using DataAccess.Repository;
using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA = DataAccess.Models;

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

        public List<Customers> All()
        {
            return _services.All().Select(dr => _mapper.Map<Customers>(dr)).ToList();
        }

        public Customers GetCustomer(int id)
        {
            Customers customer = _mapper.Map<Customers>(_services.Get(id));
              return customer;                   
        }
    }
}
