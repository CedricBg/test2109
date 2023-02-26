using AutoMapper;
using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Employees;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;


namespace DataAccess.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly SecurityCompanyContext _context;

        private readonly IMapper _Mapper;

        public CountryServices(SecurityCompanyContext context, IMapper mapper)
        {
            _context = context;
            _Mapper = mapper;
        }

        public List<Countrys> GetAllCountrys()
        {
            if (!(_context.Countrys == null))
            {
                List<Countrys> _countries = _context.Countrys.
                    Select((country) => new Countrys
                    {
                        Country = country.Country,
                        Id = country.Id
                    }).ToList();
                return _countries;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
