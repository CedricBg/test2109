using BusinessAccessLayer.Models.Rondes;

namespace BusinessAccessLayer.IRepositories
{
    public interface IRondesService
    {
        Boolean AddRfid(List<RfidPatrol> rfidPatrol);
        List<RfidPatrol> GetRfidPatrols(int id);
    }
}