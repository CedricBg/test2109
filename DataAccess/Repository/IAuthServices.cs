using DataAccess.Models;
using DataAccess.Models.Auth;

namespace DataAccess.Repository
{
    public interface IAuthServices
    {
        string RegisterEmployee(AddRegisterForm form);
        ConnectedForm Login(LoginForm form);

    }
}