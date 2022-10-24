using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BUSI = BusinessAccessLayer.Models.Auth;
using VIEW = test2109.Models.Auth;


namespace test2109.Tools.Auth
{
    public static class Mapper
    {
        public static BUSI.AddRegisterForm MapRegisterEmployee(this VIEW.AddRegisterForm Form)
        {
            return new BUSI.AddRegisterForm()
            {
                Login = Form.Login,
                Password = Form.Password,
                Id = Form.Id,
            };
        }
        public static BUSI.LoginForm Login(this VIEW.LoginForm form)
        {
            return new BUSI.LoginForm() 
            { 
                Login = form.Login,
                Password = form.Password
            };
        }

        public static VIEW.ConnectedForm MapConnect(this BUSI.ConnectedForm form) 
        {
            return new VIEW.ConnectedForm
            {
                Id = form.Id,
                FirstName = form.FirstName,
                SurName = form.SurName
            };
        }
    }
}
