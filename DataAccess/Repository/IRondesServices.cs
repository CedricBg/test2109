using DataAccess.Models.Rondes;

namespace DataAccess.Repository
{
    public interface IRondesServices
    {
        Boolean AddRfid(List<RfidPatrol> rfidPatrol);
        List<RfidPatrol> GetRfidPatrols(int id);
        List<RfidPatrol> UpdateRfid(RfidPatrol rfid);
        Boolean CheckRoundexist(Rounds round);
        List<RfidPatrol> DeleteRfid(RfidPatrol rfid);
        List<RfidPatrol> GetRfidRounds(Rounds round);
        List<RfidPatrol> PutRound(PutRfidRounds putRfid);
        List<Rounds> GetRounds(int id);

    }
}