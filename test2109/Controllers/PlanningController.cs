using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Customers;
using BusinessAccessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using test2109.Models.Planning;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlanningService _service;

        public PlanningController(IMapper mapper, IPlanningService service)
        {
            _mapper = mapper;
            _service = service;
        }

        
        [HttpPost("startWork")]
        public IActionResult StartWork([FromBody] StartEndTimeWork form)
        {
            try
            {
                var detail = _mapper.Map<BusinessAccessLayer.Models.Planning.StartEndWorkTime>(form);
                Working result = _mapper.Map<Working>(_service.StartWork(detail));
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound(false);
            }
        }

        [HttpGet("endWork/{id}")]
        public IActionResult EndWork( int id)
        {
            try
            {
                Boolean result = _service.EndWork(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomers( int id)
        {
            List<AllCustomers> cust = _service.Customers(id).Select(dr => _mapper.Map<AllCustomers>(dr)).ToList();
            return Ok(cust);
        }

        [HttpGet("working/{id}")]
        public IActionResult IsWorking(  int id)
        {
            Working result = _mapper.Map<Working>(_service.IsWorking(id));
            return Ok(result);
        }
    }
}

