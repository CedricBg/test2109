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
        public string CreatePdf(Pdf pdf)
        {
            try
            {
                var detail = _Mapper.Map<BusinessAccessLayer.Models.Pdf>(pdf);
                this._pfService.CreatePdf(detail);
                return JsonSerializer.Serialize("Created");
            }
            catch (Exception ex) 
            {
                return JsonSerializer.Serialize(ex.Message);
            }
        }
    }
}
