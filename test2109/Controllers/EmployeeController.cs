using BusinessAccessLayer.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Employee;
using test2109.Tools.Employee;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        [Authorize("adminpolicy")]
        [HttpGet("all")]
        public IActionResult Get()
        {
            try
            {

                return Ok(_employeeService.GetAll());
            }
            catch (Exception)
            {
                return Ok(BadRequest());
            }
        }

        
        [HttpPost("insert/")]
        public IActionResult Post(DetailEmployed form)
        {
            try 
            {
                _employeeService.AddEmployee(form.AddEmployee());
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}
