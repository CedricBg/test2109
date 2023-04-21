using BusinessAccessLayer.Models;

namespace BusinessAccessLayer.IRepositories
{
    public interface IPdfService
    {
        void CreatePdf(Pdf pdf);
    }
}