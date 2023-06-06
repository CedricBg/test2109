using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Rondes;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA = DataAccess.Models.Rondes;

namespace BusinessAccessLayer.Services
{
    public class RondesService : IRondesService
    {
        private readonly IRondesServices _service;

        private readonly IMapper _Mapper;

        public RondesService(IRondesServices service, IMapper mapper)
        {
            _service = service;
            _Mapper = mapper;
        }

        public Boolean AddRfid(List<RfidPatrol> rfidPatrol)
        {
            var detail = _Mapper.Map<List<DATA.RfidPatrol>>(rfidPatrol);
            return _service.AddRfid(detail);
        }

        public List<RfidPatrol> GetRfidPatrols(int id)
        {
            return _service.GetRfidPatrols(id).Select(dr => _Mapper.Map<RfidPatrol>(dr)).ToList();
        }
    }
}
