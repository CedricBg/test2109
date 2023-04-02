using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BUSI = BusinessAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using API = test2109.Models;
using test2109.Models.Employee;
using test2109.Models.Customer;

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
            List<AllCustomers> list = _customerService.All().Select(d => _mapper.Map<AllCustomers>(d)).ToList();
            return Ok(list);
        }

        [HttpGet("site/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Site site = _mapper.Map<API.Customer.Site>(_customerService.GetCustomer(id));
                return Ok(site);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("site")]
        public IActionResult Put(API.Customer.Site site)
        {
            try
            {
                var detail = _mapper.Map<BUSI.Customers.Site>(site);
                API.Customer.Site sites = _mapper.Map<Site>(_customerService.UpdateSite(detail));
                return Ok(sites);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
