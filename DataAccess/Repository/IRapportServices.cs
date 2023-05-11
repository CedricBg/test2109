using DataAccess.Models;

namespace DataAccess.Repository
{
    public interface IRapportServices
    {
        Pdf PdfAdd(Pdf pdf);
        Pdf checkRapport(int id);
    }
}