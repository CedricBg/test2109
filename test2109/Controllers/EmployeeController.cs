using AutoMapper;
using BUSI = BusinessAccessLayer.Models;
using BusinessAccessLayer.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Employee;



namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        private readonly IMapper _Mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _Mapper = mapper;
        }

        
        [HttpGet("all")]
        public IActionResult Get()
        {
            try
            {   
                return Ok(_employeeService.GetAll());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        
        [HttpPost("insert/")]
        public IActionResult Posts(DetailEmployed form)
        {
            try
            {
                var detail = _Mapper.Map<BUSI.Employee.DetailedEmployee>(form);
                _employeeService.AddEmployee(detail);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return Ok(BadRequest(ex.Message));
            }
        }
        
        [HttpGet("GetOne/{id}")]
        public IActionResult GetOne(int id) 
        {
            DetailEmployed employed = _Mapper.Map<DetailEmployed>(_employeeService.GetOne(id));
            if(employed.Id != null)
            {
                return Ok(employed);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpDelete("deactiveUser/{id}")]
        public IActionResult Deactive(int id)
        {
            return Ok(_employeeService.Deactive(id));
        }

        [HttpPut("update")]
        public IActionResult UpdateEmployee(DetailEmployed detailedEmployee)
        {
            var detail = _Mapper.Map<BUSI.Employee.DetailedEmployee>(detailedEmployee);
            DetailEmployed employed =  _Mapper.Map<DetailEmployed>(_employeeService.UpdateEmployee(detail));
            return Ok(employed);
        }
    }
}
