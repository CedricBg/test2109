using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BUSI = BusinessAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using API = test2109.Models;
using test2109.Models.Employee;

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerService.All().Select(d => _mapper.Map<BUSI.Customer.CustomerAll>(d)).ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<API.Customer.Customers>(_customerService.GetCustomer(id)));
        }


        [HttpPut]
        public API.Customer.Customers Put(API.Customer.Customers customer)
        {
            return new API.Customer.Customers();
        }
    }
}
