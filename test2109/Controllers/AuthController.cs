using System;
using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BUSI = BusinessAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2109.Models.Auth;
using System.Text.Json;

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly IMapper _Mapper;

        public AuthController()
        {

        }

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _Mapper = mapper;
        }

        /// <summary>Ajout d'un login a un utilisateur déjà existant</summary>
        /// <param name="form">The form.</param>
        /// <returns>
        ///   retourne un string "Created" ou le message d'erreur , creer dans le service DataAccess
        /// </returns>
        [HttpPost("AddLogin")]
        public string Post(AddRegisterForm form)
        {
            try
            {
                var detail = _Mapper.Map<BUSI.Auth.AddRegisterForm>(form);
                return JsonSerializer.Serialize(_authService.Post(detail));
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(ex.Message);
            }
        }

        /// <summary>Logins with the specified form</summary>
        /// <param name="form">The form.</param>
        /// <returns>
        ///   si le mot de passe et l'utilisateur sont reconnu on renvoi le token, nom, prénom, role = string et dimin  en string
        /// </returns>
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
