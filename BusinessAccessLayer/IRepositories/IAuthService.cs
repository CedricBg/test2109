using BusinessAccessLayer.Models.Auth;

namespace BusinessAccessLayer.IRepositories
{
    public interface IAuthService
    {
        string Post(AddRegisterForm form);
        ConnectedForm Login(LoginForm form);
        
    }
}