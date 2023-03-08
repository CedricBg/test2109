using DataAccess.Models;

namespace DataAccess.Repository
{
    public interface IInformationServices
    {
        List<Role> GetAllRoles();
    }
}