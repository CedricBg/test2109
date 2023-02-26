using DataAccess.Models;

namespace DataAccess.Repository
{
    public interface ICountryServices
    {
        List<Countrys> GetAllCountrys();
    }
}