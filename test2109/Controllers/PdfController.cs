using AutoMapper;
using BusinessAccessLayer.IRepositories;
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

        [HttpPost("saveRapport")]
        public IActionResult SaveRapportPdf(Pdf pdf)
        {
            try
            {
                var detail = _Mapper.Map<BusinessAccessLayer.Models.Pdf>(pdf);
                return Ok(_Mapper.Map<Pdf>(this._pfService.SaveRapport(detail)));
            }
            catch (Exception)
            {
                return Ok(new Pdf());
            }
        }

        //controle si un rapport est en cours
        [HttpGet("checkRapport/{id}")]
        public IActionResult checkRapport(int id) 
        {
            return Ok(_Mapper.Map<Pdf>(_pfService.checkRapport(id)));
        }
    }
}
