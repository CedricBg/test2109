using BUSI = BusinessAccessLayer.Models.Auth;
using API = test2109.Models.Auth;

namespace test2109.Tools;


public static class Mapper
{
    public static BUSI.LoginForm MapLoginForm(this API.LoginForm form)
    {
        return new BUSI.LoginForm()
        {
            Login = form.Login,
            Password = form.Password,

        };
    }

    public static API.ConnectedForm MapConnectedForm(this BUSI.ConnectedForm form)
    {
        return new API.ConnectedForm()
        {
            SurName = form.SurName,
            FirstName = form.FirstName,
            Id = form.Id,
            Role = form.Role,
            Dimin = form.Dimin,
            Token = form.Token,
        };
    }
}
