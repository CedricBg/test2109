using BusinessAccessLayer.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IPdfService _pfService;

        public ValuesController(IPdfService pfService)
        {
            _pfService = pfService;
        }


        [HttpGet]
        public void CreatePdf()
        {
            this._pfService.CreatePdf();
        }

 
    }
}
