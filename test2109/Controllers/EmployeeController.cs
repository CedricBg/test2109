﻿using BusinessAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using test2109.Models;
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
        // GET: api/<EmployeeController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}



        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post(Employee form)
        {
            try 
            {
                _employeeService.AddEmployee(form.AddEmployee());
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception )
            {
                return BadRequest();
            }
           
        }

    }
}
