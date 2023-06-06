using AutoMapper;
using BUSI = BusinessAccessLayer.Models.Rondes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Ronde;
using BusinessAccessLayer.IRepositories;
using Microsoft.Data.SqlClient;

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RondesController : ControllerBase
    {
        private readonly IRondesService _RondesService;

        private readonly IMapper _Mapper;

        public RondesController(IRondesService rondesService, IMapper mapper)
        {
            _RondesService = rondesService;
            _Mapper = mapper;
        }


        [HttpPost("addRfid")]
        [Authorize("opspolicy")]
        public IActionResult AddRfid(List<RfidPatrol> rfidPatrol)
        {
            if(rfidPatrol == null)
            {
                return Ok(false);
            }
            else
            {
                var detail = _Mapper.Map<List<BUSI.RfidPatrol>>(rfidPatrol);
                return Ok(_RondesService.AddRfid(detail));
            }

        }

        /// <summary>
        /// Retourne une liste de Rfid pour les rondes sur base de l'id du site
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetRfid/{id}")]
        public IActionResult GetRfidPatrols(int id)
        {
            try
            {
                return Ok(_RondesService.GetRfidPatrols(id).Select(dr => _Mapper.Map<RfidPatrol>(dr)).ToList());
            }
            catch (Exception)
            {
                return Ok(new List<RfidPatrol>());
            }
        }
    }
}
