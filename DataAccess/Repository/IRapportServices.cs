using DataAccess.Models;

namespace DataAccess.Repository
{
    public interface IRapportServices
    {
        Pdf CreatePdf(Pdf pdf);
        Pdf checkRapport(int id);
        List<Pdf> listRapport(int id);
        byte[] loadRapport(int id);
        Pdf SaveRapport(Pdf pdf);
    }
}