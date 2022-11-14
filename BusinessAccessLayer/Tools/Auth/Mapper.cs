using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA = DataAccess.Models.Auth;
using BUSI = BusinessAccessLayer.Models.Auth;

namespace BusinessAccessLayer.Tools.Auth
{
    public static class Mapper
    {
        public static DATA.AddRegisterForm MapregistEmployeeToData(this BUSI.AddRegisterForm form)
        {
            return new DATA.AddRegisterForm()
            {
                Login = form.Login,
                Password = form.Password,
                Id = form.Id,
                Role = form.Role,
            };
        }

        public static DATA.LoginForm MapLoginForm(this BUSI.LoginForm form)
        {
            return new DATA.LoginForm()
            {
                Login = form.Login,
                Password = form.Password,

            };
        }

        public static BUSI.ConnectedForm MapConnectedForm(this DATA.ConnectedForm form)
        {
            return new BUSI.ConnectedForm()
            {
                SurName = form.SurName,
                FirstName = form.FirstName,
                Id = form.Id,
                Role = form.Role,
            };
        }
    }
}
