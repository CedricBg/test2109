using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{


    public class InformationService : IInformationService
    {
        private readonly IInformationServices _IInformationServices;

        private readonly IMapper _Mapper;

        public InformationService(IInformationServices informationServices, IMapper mapper)
        {
            _IInformationServices = informationServices;
            _Mapper = mapper;
        }

        public List<Role> GetAllRoles()
        {
            return _IInformationServices.GetAllRoles().Select(dr => _Mapper.Map<Role>(dr)).ToList();
        }

        public List<Language> languages()
        {
            return _IInformationServices.GetAllLanguages().Select(dr => _Mapper.Map<Language>(dr)).ToList();
        }
    }
}
