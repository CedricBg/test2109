using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Employee;
using Microsoft.AspNetCore.Mvc;


namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _Mapper;
        public AddressController(ICountryService countryService , IMapper mapper) 
        {
            _countryService = countryService;
            _Mapper = mapper;
        }
        [HttpGet("allCountrys")]
        public IEnumerable<Countrys> Get()
        {
            return _countryService.GetAllCountrys().Select(e => _Mapper.Map<Countrys>(e)).ToList();

        }
    }
}
