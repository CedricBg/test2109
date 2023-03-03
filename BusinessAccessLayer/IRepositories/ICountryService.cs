using BusinessAccessLayer.Models.Employee;

namespace BusinessAccessLayer.IRepositories
{
    public interface ICountryService
    {
        List<Countrys> GetAllCountrys();
    }
}