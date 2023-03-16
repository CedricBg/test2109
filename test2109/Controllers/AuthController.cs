using System;
using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BUSI = BusinessAccessLayer.Models;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Auth;

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly IMapper _Mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _Mapper = mapper;
        }
        
        [HttpPost("AddLogin")]
        public IActionResult Post(AddRegisterForm form)
        {
            try
            {
                var detail = _Mapper.Map<BUSI.Auth.AddRegisterForm>(form);
                return  Ok(_authService.Post(detail));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginForm form)
        {
            try
            {
                var detail = _Mapper.Map<BUSI.Auth.LoginForm>(form);
                ConnectedForm user = _Mapper.Map<ConnectedForm>(_authService.Login(detail));
                if (user.SurName != null) 
                {  
                    return Ok(user);
                }
                return Ok(null);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
