using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Services;
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

        // GET api/<AgentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            List<Site> sites = _agentService.assignedClients(id).Select(e => _mapper.Map<Site>(e)).ToList();
            return Ok(sites);
        }
    }
}
