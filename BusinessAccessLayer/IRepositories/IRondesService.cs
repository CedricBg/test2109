using BusinessAccessLayer.Models.Rondes;

namespace BusinessAccessLayer.IRepositories
{
    public interface IRondesService
    {
        Boolean AddRfid(List<RfidPatrol> rfidPatrol);
        List<RfidPatrol> GetRfidPatrols(int id);
        List<RfidPatrol> UpdateRfid(RfidPatrol rfid);
        List<RfidPatrol> DeleteRfid(RfidPatrol rfid);
        Boolean CheckRoundexist(Rounds round);
        List<Rounds> GetRounds(int id);
        List<RfidPatrol> GetRfidRounds(Rounds round);
        List<RfidPatrol> PutRound(PutRfidRounds putRfid);
        List<Rounds> updateRoundName(Rounds rounds);
    }
}