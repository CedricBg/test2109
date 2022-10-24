using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Auth;
using BusinessAccessLayer.Tools.Auth;
using DataAccess.Repository;
using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthServices _authService;

        public AuthService(IAuthServices auth)
        {
            _authService = auth;
        }
        
        public string Post(AddRegisterForm form)
        {
            try
            {
                return _authService.RegisterEmployee(form.MapregistEmployeeToData());
            }
            catch (Exception ex)
            {
                return(ex.Message);
            }
        }

        public ConnectedForm Login(LoginForm form) 
        {
            try
            {
                return _authService.Login(form.MapLoginForm()).MapConnectedForm();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

    }
}
