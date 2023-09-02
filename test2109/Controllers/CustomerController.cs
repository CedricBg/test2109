using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BUSI = BusinessAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using API = test2109.Models;
using test2109.Models.Customer;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using test2109.Services;
using System.Collections.Generic;

namespace test2109.Controllers;

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

    /// <summary>
    /// Suppresion d'un contact sur une site
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retourne un site pour mise à jour de la vue</returns>
    [Authorize("opspolicy")]
    [HttpDelete("deleteContact/{id}")]
    public IActionResult deleteContact(int id)
    {
        try
        {
            return Ok(_mapper.Map<Site>(_customerService.deleteContact(id)));
        }
        catch (Exception)
        {
            return Ok(new Site());
        }

    }

    /// <summary>
    /// On passe la variable a isDeleted pour simuler une suppression
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Le mot Delelted ou le message d'erreur</returns>
    [Authorize("opspolicy")]
    [HttpDelete("deleteSite/{id}")]
    public string SiteDelete(int id)
    {
        try
        {
           
            return JsonSerializer.Serialize(_customerService.SiteDelete(id));
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(ex.Message);
        }
         
    }

    /// <summary>
    /// Retourne un client par rapport a son Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Un Customer</returns>
    [Authorize("opspolicy")]
    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        try
        {
            return Ok(_mapper.Map<Customers>(_customerService.GetOne(id)));
        }
        catch(Exception ex)
        {
            return Ok(new Customers());
        }
        
    }

    /// <summary>
    /// Mise a jour du nom du client ou de la personne de contact pour le Customer pas les sites !!!
    /// </summary>
    /// <param name="customer">The customer.</param>
    /// <returns>
    /// le nom du client
    /// </returns>
    [Authorize("opspolicy")]
    [HttpPut]
    public IActionResult UpdateCustomer(AllCustomers customer)
    {
        var detail = _mapper.Map<BUSI.Customers.AllCustomers>(customer);
        //mise a jour de la liste apres changements ,donc si on recharge la liste de site apres cette action on charge celle en cache
        return Ok(_customerService.UpdateCustomer(detail).Select(dr => _mapper.Map<Customers>(dr)));
    }

    /// <summary>
    /// passe la variable is deleted a true mais ne supprime pas le client
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [Authorize("opspolicy")]
    [HttpPut("delete/{id}")]
    public string Delete(int id)
    {
        string response = (_customerService.Delete(id));
        
        return JsonSerializer.Serialize(response);
    }

    /// <summary></summary>
    /// <returns>
    /// Retourne list d'objet Allcustomers qui contient des infos minimaliste sur les utilisateurs ou une liste vide
    /// </returns>
    [Authorize("opspolicy")]
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_customerService.All().Select(d => _mapper.Map<AllCustomers>(d)).ToList());
        }
        catch(Exception)
        { 
            return Ok(new List<AllCustomers>());
        }  
    }

    /// <summary>Retourne un site par son id</summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Retourne un site par son id</returns>
    [Authorize("agentpolicy")]
    [HttpGet("site/{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            return Ok(_mapper.Map<API.Customer.Site>(_customerService.GetCustomer(id)));
        }
        catch (Exception)
        {
            return Ok(new Site());
        }
    }

    /// <summary>Mise a jour d'un site</summary>
    /// <param name="site"></param>
    /// <returns>The created site</returns>
    [Authorize("opspolicy")]
    [HttpPut("site")]
    public IActionResult Put(API.Customer.Site site)
    {
        try
        {
            var detail = _mapper.Map<BUSI.Customers.Site>(site);
            return Ok(_mapper.Map<Site>(_customerService.UpdateSite(detail)));
        }
        catch (Exception ex)
        {
            return Ok(ex.Message);
        }
    }

    /// <summary>>Creation d'un client avec juste un nom de société</summary>
    /// <param name="customer">The customer.</param>
    /// <returns>Created Customer</returns>
    [Authorize("opspolicy")]
    [HttpPost("addCustomer")] 
    public IActionResult Post([FromBody] Customers customer) 
    {
        try
        {
            var detail = _mapper.Map<BUSI.Customers.Customers>(customer);
            return Ok(_customerService.AddCustomer(detail));
        }
        catch
        {
            return Ok(0);
        }
    }

    /// <summary>Posts the specified site.</summary>
    /// <param name="site">Creation d'un site</param>
    /// <returns>Created Site</returns>
    [Authorize("opspolicy")]
    [HttpPost("AddSite")]
    public IActionResult Post([FromBody] API.Customer.Site site)
    {
        if(site == null)
            return Ok(new Site());
        else
        {
            var detail = _mapper.Map<BUSI.Customers.Site>(site);
            return Ok(_customerService.AddSite(detail));
        }
    }

    /// <summary>
    /// Ajout d'un contact a client à la création d'un client
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    [Authorize("opspolicy")]
    [HttpPost("addContact")]
    public IActionResult Post(ContactPerson contact)
    {  
        try
        {
            var detail = _mapper.Map<BUSI.Customers.ContactPerson>(contact);
            return Ok(_customerService.addContact(detail).Select(dr => _mapper.Map<Customers>(dr)));
        }
        catch (Exception) { }
        {
            return Ok(new List<Customers>());
        }
    }

    /// <summary>
    /// Ajout d'un contact avec la mise à jour d'un site
    /// </summary>
    /// <param name="contact"></param>
    /// <returns>un Site pour mise a jour de la vue</returns>
    [Authorize("opspolicy")]
    [HttpPost("addContactsite")]
    public IActionResult PostContact(ContactPerson contact)
    {
        try
        {
            var detail = _mapper.Map<BUSI.Customers.ContactPerson>(contact);
            Site site = _mapper.Map<Site>(_customerService.PostContact(detail));
            return Ok(site);
        }
        catch (Exception) { }
        {
            return Ok(new List<Customers>());
        }
    }
}
