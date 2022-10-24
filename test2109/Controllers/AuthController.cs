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
        [Authorize("authpolicy")]
        [HttpPost("AddLogin")]
        public string Post(AddRegisterForm form)
        {
            try
            {
                return _authService.Post(form.MapRegisterEmployee());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("login")]
        public ConnectedForm Login(LoginForm form)
        {
            try
            {

                ConnectedForm user =  _authService.Login(form.Login()).MapConnect();
                if(user.Id != 0)
                {
                    return user;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
