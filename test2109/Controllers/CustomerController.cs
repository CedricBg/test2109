﻿using AutoMapper;
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

        /// <summary>Gets this instance.</summary>
        /// <returns>
        ///   <para>Retourne list d'objet Allcustomers qui contient des infosminimaliste sur les utilisateurs</para>
        ///   <para>
        ///     ou une liste vide
        ///   </para>
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<AllCustomers> list = _customerService.All().Select(d => _mapper.Map<AllCustomers>(d)).ToList();
                return Ok(list);
            }
            catch 
            { 
                return Ok(new List<AllCustomers>());
            }

            
        }

        /// <summary>Gets the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Retourne un site par son id</returns>
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
                return Ok(new Site());
            }
        }

        /// <summary>Puts the specified site.</summary>
        /// <param name="site">The site.</param>
        /// <returns>Mise a jour d'un site</returns>
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


        /// <summary>Create a customer</summary>
        /// <param name="customer">The customer.</param>
        /// <returns>Creation d'un client avec juste un nom de société</returns>
        [HttpPost("addCustomer")] 
        public IActionResult Post([FromBody] string customer) 
        {
            return Ok(_customerService.AddCustomer(customer));
        }

        [HttpPost("AddSite")]
        public IActionResult Post([FromBody] API.Customer.Site site)
        {
            if(site == null)
                return Ok(0);
            else
            {
                var detail = _mapper.Map<BUSI.Customers.Site>(site);
                return Ok(_customerService.AddSite(detail));
            }
        }
        
        [HttpPost("addContact")]
        public IActionResult Post( ContactPerson contact)
        {

            if (contact == null)
                return Ok(0);
            else
            {
                var detail = _mapper.Map<BUSI.Customers.ContactPerson>(contact);
                return Ok(_customerService.addContact(detail));
            }
        }
    }
}
