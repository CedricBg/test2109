using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models.Rondes;
using DataAccess.Repository;
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

        public List<RfidPatrol> UpdateRfid(RfidPatrol rfid)
        {
            var detail = _Mapper.Map<DATA.RfidPatrol>(rfid);
            return _service.UpdateRfid(detail).Select(dr => _Mapper.Map<RfidPatrol>(dr)).ToList();
        }

        public List<RfidPatrol> DeleteRfid(RfidPatrol rfid)
        {
            var detail = _Mapper.Map<DATA.RfidPatrol>(rfid);
            return _service.DeleteRfid(detail).Select(dr => _Mapper.Map<RfidPatrol>(dr)).ToList();
        }

        public Boolean CheckRoundexist(Rounds round)
        {
            var detail = _Mapper.Map<DATA.Rounds>(round);
            return _service.CheckRoundexist(detail);
        }

        public List<Rounds> GetRounds(int id)
        {
            return _service.GetRounds(id).Select(e => _Mapper.Map<Rounds>(e)).ToList();
        }

        public List<RfidPatrol> GetRfidRounds(Rounds round)
        {
            var detail = _Mapper.Map<DATA.Rounds>(round);
            return _service.GetRfidRounds(detail).Select(e=>_Mapper.Map<RfidPatrol>(e)).ToList();
        }

        public List<RfidPatrol> PutRound(PutRfidRounds putRfid)
        {
            var detail = _Mapper.Map<DATA.PutRfidRounds>(putRfid);
            return _service.PutRound(detail).Select(e => _Mapper.Map<RfidPatrol>(e)).ToList();
        }

    }
}
