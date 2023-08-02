using AutoMapper;
using BusinessAccessLayer.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using test2109.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pfService;
        private readonly IMapper _Mapper;

        public PdfController(IPdfService pfService,IMapper mapper )
        {
            _pfService = pfService;
            _Mapper = mapper;
        }

        [Authorize("agentpolicy")]
        [HttpPost]
        public IActionResult CreatePdf(Pdf pdf)
        {
            try
            {
                var detail = _Mapper.Map<BusinessAccessLayer.Models.Pdf>(pdf);
                return Ok(_Mapper.Map<Pdf>(this._pfService.CreatePdf(detail)));
            }
            catch (Exception) 
            {
                return Ok(new Pdf());
            }
        }

        [Authorize("agentpolicy")]
        [HttpPost("saveRapport")]
        public IActionResult SaveRapportPdf(Pdf pdf)
        {
            try
            {
                var detail = _Mapper.Map<BusinessAccessLayer.Models.Pdf>(pdf);
                Pdf pdf1 = _Mapper.Map<Pdf>(this._pfService.SaveRapport(detail));
                return Ok(pdf1); 
            }
            catch (Exception)
            {
                return Ok(new Pdf());
            }
        }

        /// <summary>
        /// controle si un rapport est en cours
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One Pdf if exist</returns>
        [Authorize("agentpolicy")]
        [HttpGet("checkRapport/{id}")]
        public IActionResult checkRapport(int id) 
        {
            return Ok(_Mapper.Map<Pdf>(_pfService.checkRapport(id)));
        }

        /// <summary>
        /// On va chercher les rapports d'un agent bien précis
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Pdf</returns>
        [Authorize("agentpolicy")]
        [HttpGet("listRapport/{id}")]
        public IActionResult listRapport(int id)
        {
            return Ok(_pfService.listRapport(id).Select(dr => _Mapper.Map<Pdf>(dr)).ToList());
        }

        /// <summary>
        /// On télécharge un rapport via l'id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize("agentpolicy")]
        [HttpGet("loadRapport/{id}")]
        public IActionResult loadRapport(int id)
        {
            try
            {
                byte[] pdfData = _pfService.loadRapport(id);
                string pdfFileName = $"pdf_{id}.pdf";
                return File(pdfData, "application/pdf", pdfFileName);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
