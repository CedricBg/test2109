using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Services;
using DataAccess.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private IAgentService _agentService;

        private IMapper _mapper;

        public AgentController(IAgentService agentService, IMapper mapper)
        {
            _agentService = agentService;
            _mapper = mapper;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            List<Site> sites = _agentService.assignedClients(id).Select(e => _mapper.Map<Site>(e)).ToList();
            return Ok(sites);
        }

        /// <summary>
        /// Retourne une list d'agent par rapport au numero de role qui lui à été attribué et pas par l'id !!, 
        /// pour ajouter de nouveau role pour les agents il suffira de monter le numéro du nouveau role, à la création de l'api on est de 1 a 15 (Max 49)
        /// </summary>
        /// <returns>List of guards</returns>
        [HttpGet]
        [Authorize("opspolicy")]
        public IActionResult assignedEmployees()
        {
            try
            {
                return Ok(_agentService.assignedEmployees().Select(dr=> _mapper.Map<Employee>(dr)).ToList());
            }
            catch (Exception ex)
            {
                return Ok(new List<Employee>());
            }
        }

        [HttpGet("GetOne/{id}")]
        public IActionResult GetAGuard(int id)
        {
            try
            {
                return Ok(_mapper.Map<Employee>(_agentService.GetAGuard(id)));
            }
            catch (Exception ex)
            {
                return Ok(new Employee());
            }
        }

        [HttpGet("Customers/{id}")]
        public IActionResult assignedCustomers(int id)
        {
            return Ok(_agentService.assignedCustomers(id).Select(e => _mapper.Map<Customers>(e)).ToList());
        }
    }
}
