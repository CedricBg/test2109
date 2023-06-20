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
        [Authorize("opspolicy")]
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

        [HttpPut("updateRfid")]
        [Authorize("opspolicy")]
        public IActionResult UpdateRfid(RfidPatrol rfid)
        {
            try
            {
                var detail = _Mapper.Map<BUSI.RfidPatrol>(rfid);
                return Ok(_RondesService.UpdateRfid(detail).Select(dr => _Mapper.Map<RfidPatrol>(dr)).ToList());
            }
              catch(Exception)
            {
                return Ok(new List<RfidPatrol>());
            }

        }

        /// <summary>
        /// Suppression définitive d'une pastille sur base de l'id du site et de la pastille
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        [HttpPut("deleteRfid")]
        [Authorize("opspolicy")]
        public IActionResult DeleteRfid(RfidPatrol rfid)
        {
            try
            {
                var detail = _Mapper.Map<BUSI.RfidPatrol>(rfid);
                return Ok(_RondesService.DeleteRfid(detail).Select(dr => _Mapper.Map<RfidPatrol>(dr)).ToList());
            }
            catch
            {
                return Ok(new List<RfidPatrol>());
            }

        }

        /// <summary>
        /// On controle si la ronde éxiste si oui on renvoi les pastilles correspondante
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        [HttpPut("CheckRound")]
        [Authorize("opspolicy")]
        public IActionResult CheckRoundexist(Rounds round)
        {
            try
            {
                var detail = _Mapper.Map<BUSI.Rounds>(round);
                return Ok(_RondesService.CheckRoundexist(detail));
            }
            catch(Exception)
            {
                return Ok(false);
            }
        }

        /// <summary>
        /// Reourne une liste de ronde sur base de l'id du site
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetRounds/{id}")]
        [Authorize("opspolicy")]
        public IActionResult GetRounds(int id)
        {
            try
            {
                return Ok(_RondesService.GetRounds(id).Select(e=> _Mapper.Map<Rounds>(e)).ToList());
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPost("GetRfidRounds")]
        [Authorize("opspolicy")]
        public IActionResult GetRfidRounds(Rounds round)
        {
            try
            {
                var detail =_Mapper.Map<BUSI.Rounds>(round);
                return Ok(_RondesService.GetRfidRounds(detail).Select(e => _Mapper.Map<RfidPatrol>(e)).ToList());
            }
            catch(Exception)
            {
                return NoContent();
            }
        }


        //On met a jour les pastilles pour une ronde donnée
        [HttpPut("PutRfidRounds")]
        [Authorize("opspolicy")]
        public IActionResult PutRound(PutRfidRounds putRfid)
        {
            
            try
            {
                var detail = _Mapper.Map<BUSI.PutRfidRounds>(putRfid);
                return Ok(_RondesService.PutRound(detail).Select(e=>_Mapper.Map<RfidPatrol>(e)).ToList());
            }
            catch
            {
                return Ok(new List<RfidPatrol>());
            }
        }

        /// <summary>
        /// on change le nom d'une ronde
        /// </summary>
        /// <param name="rounds"></param>
        /// <returns></returns>
        [HttpPut("ChangeName")]
        [Authorize("opspolicy")]
        public IActionResult  updateRoundName(Rounds rounds)
        {
            try
            {
                var detail = _Mapper.Map<BUSI.Rounds>(rounds);
                return Ok(_RondesService.updateRoundName(detail).Select(e => _Mapper.Map<Rounds>(e)).ToList());
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
