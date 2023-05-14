using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Customers;
using BusinessAccessLayer.Models.Planning;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{

    public class PlanningService : IPlanningService
    {
        IPlanningServices _Services;
        IMapper _Mapper;


        public PlanningService(IPlanningServices services, IMapper mapper)
        {
            _Services = services;
            _Mapper = mapper;
        }

        public Working StartWork(StartEndWorkTime form)
        {
            var detail = _Mapper.Map<DataAccess.Models.Planning.StartEndWorkTime>(form);
            return _Mapper.Map<Working>(_Services.StartWork(detail));
        }

        public Boolean EndWork(int id)
        {

            return _Services.EndWork(id);
        }

        public List<Site> Sites(int id)
        {
            return _Services.Sites(id).Select(dr => _Mapper.Map<Site>(dr)).ToList();
        }

        public Working IsWorking(int id)
        {
           return _Mapper.Map<Working>(_Services.IsWorking(id));
        }
    }
}
