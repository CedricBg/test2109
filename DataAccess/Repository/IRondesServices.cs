using DataAccess.Models.Rondes;

namespace DataAccess.Repository
{
    public interface IRondesServices
    {
        Boolean AddRfid(List<RfidPatrol> rfidPatrol);
        List<RfidPatrol> GetRfidPatrols(int id);
    }
}