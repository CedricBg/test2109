using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Employee;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{

    public class CountryService : ICountryService
    {
        private readonly ICountryServices _countryServices;
        private readonly IMapper _Mapper;
        public CountryService(ICountryServices countryServices, IMapper mapper)
        {
            _countryServices = countryServices;
            _Mapper = mapper;
        }


        public List<Countrys> GetAllCountrys()
        {
            return _countryServices.GetAllCountrys().Select(e => _Mapper.Map<Countrys>(e)).ToList();
        }
    }
}
