using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    
    public class CountryService
    {
        private readonly ICountryServices _countryServices;
        public CountryService(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }
    }
}
