using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BUSI = BusinessAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Employee;
using test2109.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {

        private readonly IInformationService _informationService;
        private readonly IMemoryCache _memoryCache;

        private readonly IMapper _Mapper;

        public InformationController(IInformationService informationService, IMapper mapper, IMemoryCache memoryCache)
        {
            _informationService = informationService;
            _Mapper = mapper;
            _memoryCache = memoryCache;
        }

        /// <summary>Roles this instance.</summary>
        /// <returns>List d'objet role pour les formulaires de mise a jour des accès</returns>
        [Authorize("opspolicy")]
        [HttpGet("Role")]
        public IActionResult Role()
        {
            try
            {
                List<Role> list = new List<Role>();
                if (!_memoryCache.TryGetValue("listRole", out list))
                {
                    list = _informationService.GetAllRoles().Select(d => _Mapper.Map<Role>(d)).ToList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(30));
                    _memoryCache.Set("listRole", list, cacheEntryOptions);
                }
                return Ok(list);
            }
            catch (Exception)
            {
                return Ok(new List<Role>());
            }
        }

        /// <summary>Languages this instance.</summary>
        /// <returns>Retourne une liste d'objet langue pour les differents formulaires</returns>
        [HttpGet("Language")]
        public IActionResult Language()
        {
            try
            {
                List<Language> list = new List<Language>();
                if (!_memoryCache.TryGetValue("listLanguage", out list))
                {
                    list = _informationService.languages().Select(d => _Mapper.Map<Language>(d)).ToList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(30));
                    _memoryCache.Set("listLanguage", list, cacheEntryOptions);
                } 
                return Ok(list);
            }
            catch(Exception)
            {
                return Ok(new List<Language>());
            }
        }
    }
}
