using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BUSI = BusinessAccessLayer.Models.Agents;
using BusinessAccessLayer.Services;
using DataAccess.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Customer;
using test2109.Models.Agents;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using test2109.Services;

namespace test2109.Controllers;

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

    /// <summary></summary>
    /// <param name="id"></param>
    /// <returns>Retournt une liste de site par id du client</returns>
    [HttpGet("{id}")]
    [Authorize("agentpolicy")]
    public IActionResult Get(int id)
    {
        List<Site> liste = new();
        string stringId = id.ToString()+"Site";
        liste = _agentService.assignedClients(id).Select(e => _mapper.Map<Site>(e)).ToList();
            
        return Ok(liste);
    }

    /// <summary>
    /// Retourne une list d'agent par rapport au numero de role qui lui à été attribué et pas par l'id !!, 
    /// pour ajouter de nouveau role pour les agents il suffira de monter le numéro du nouveau role, a la création de l'api on est de 1 a 15 (Max 49)
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
    [Authorize("opspolicy")]
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


    [HttpPost("AddSites")]
    [Authorize("opspolicy")]
    public IActionResult AddSiteToGuard(AddSites sites)
    {
        try
        {
            var detail = _mapper.Map<BUSI.AddSites>(sites);
            
            return Ok(_agentService.AddSiteToGuard(detail).Select(e=> _mapper.Map<Site>(e)).ToList());
        }
        catch (Exception)
        {
            return Ok(new List<Site>());
        }
    }



}
