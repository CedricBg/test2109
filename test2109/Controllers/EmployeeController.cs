using AutoMapper;
using BUSI = BusinessAccessLayer.Models;
using BusinessAccessLayer.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Employee;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Text.Json;

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
       

        [HttpPost("UploadFile")]
        public async Task<string> UploadFile(IFormFile file)
        {
            await _employeeService.UploadFile(file);
            return JsonSerializer.Serialize("Fichier téléchargé avec succès!");
        }
    

        /// <summary>Gets this instance.</summary>
        /// <returns>
        ///   <para>retourne une liste d'objet employees</para>
        ///   <para>
        ///   class Employee
        ///   </para>
        /// </returns>
        [Authorize("opspolicy")]
        [HttpGet("all")]
        public IActionResult Get()
        {
            try
            {   
                return Ok(_employeeService.GetAll());
            }
            catch (Exception)
            {
                return Ok(new List<Employee>());
            }
        }


        /// <summary>Création d'un utilisateur</summary>
        /// <param name="form">The form.</param>
        /// <returns>renvoi du status http ou  du message d'erreur</returns>
        [Authorize("opspolicy")]
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

        /// <summary>Gets the one.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <para>Renvoi un objet DetailEmployed si trouvé </para>
        ///   <para>autrement on renvoi false qui est alors geré en angular</para>
        /// </returns>
        [Authorize("opspolicy")]
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

        /// <summary>Deactives the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   on passe la variable Isdelelted a true sur l'id passé ce qui met l'attribut Isdelelted dans la db a true
        /// </returns>
        [Authorize("opspolicy")]
        [HttpDelete("deactiveUser/{id}")]
        public IActionResult Deactive(int id)
        {
            return Ok(_employeeService.Deactive(id));
        }


        /// <summary>Updates the employee.</summary>
        /// <param name="detailedEmployee">The detailed employee.</param>
        /// <returns>
        ///   <para>Renoi un objet detailedEmployee pour la mise a jour dans angular </para>
        ///   <para>Autrement un detailedEmployee vide</para>
        /// </returns>
        [Authorize("opspolicy")]
        [HttpPut("update")]
        public IActionResult UpdateEmployee(DetailEmployed detailedEmployee)
        {
            try
            {
                var detail = _Mapper.Map<BUSI.Employee.DetailedEmployee>(detailedEmployee);
                DetailEmployed employed = _Mapper.Map<DetailEmployed>(_employeeService.UpdateEmployee(detail));
                return Ok(employed);
            }
            catch (Exception)
            {
                return Ok(new DetailEmployed());
            }
           
        }
    }
}
