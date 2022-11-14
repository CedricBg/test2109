using System;
using BusinessAccessLayer.IRepositories;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Auth;
using test2109.Tools.Auth;

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("AddLogin")]
        public IActionResult Post(AddRegisterForm form)
        {
            try
            {
                return Ok(_authService.Post(form.MapRegisterEmployee()));
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
                ConnectedForm user =  _authService.Login(form.Login()).MapConnect();
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
