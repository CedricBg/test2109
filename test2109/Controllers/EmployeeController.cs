﻿using AutoMapper;
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
        private IEmployeeService _employeeService;

        private readonly IMapper _Mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper) 
        {
            _employeeService = employeeService;
            _Mapper = mapper;
        }

        
        [HttpGet("all")]
        public async Task<IActionResult> Get()
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
        [HttpGet("GetOne")] 
        public IActionResult Get(int id) 
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

    }
}
