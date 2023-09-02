using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test2109.Controllers
{
    [Route("api")]
    [ApiController]
    public class StartController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");
        }
    }
}
