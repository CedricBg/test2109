using BusinessAccessLayer.Models;

namespace BusinessAccessLayer.IRepositories
{
    public interface IInformationService
    {
        List<Role> GetAllRoles();
    }
}