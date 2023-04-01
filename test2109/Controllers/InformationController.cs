
using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;


namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {

        private readonly IInformationService _informationService;

        private readonly IMapper _Mapper;

        public InformationController(IInformationService informationService, IMapper mapper)
        {
            _informationService = informationService;
            _Mapper = mapper;
        }

        [HttpGet("Role")]
        public IActionResult Role()
        {
            return Ok(_informationService.GetAllRoles().Select(d => _Mapper.Map<Role>(d)).ToList());

        }
        [HttpGet("Language")]
        public IActionResult Language()
        {
            List<Language> list = _informationService.languages().Select(d => _Mapper.Map<Language>(d)).ToList();
            return Ok(list);
        }




    }
}
