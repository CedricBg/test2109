using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class RapportServices : IRapportServices
    {
        SecurityCompanyContext _context;

        public RapportServices(SecurityCompanyContext context)
        {
            _context = context;
        }

        public Pdf PdfAdd(Pdf pdf)
        {
            Pdf pdf1 = _context.Pdf.FirstOrDefault(e => e.Title == pdf.Title);
            if (pdf1 == null)
            {
                Pdf pdf2 = new Pdf
                {
                    IdPdf = pdf.IdPdf,
                    Content = pdf.Content,
                    FilePath = pdf.FilePath,
                    Customer = pdf.Customer,
                    IdEmployee = pdf.IdEmployee,
                    Title = pdf.Title,
                };
                _context.Pdf.Add(pdf2);
                _context.SaveChanges();
                return pdf2;
            }
            else
            {
                pdf1.Content = pdf.Content;
                pdf1.FilePath = pdf.FilePath;
                _context.SaveChanges();
                return pdf1;
            }
        }

        public Pdf checkRapport(int id)
        {
            Pdf pdf = _context.Pdf.OrderBy(e=>e.IdPdf).LastOrDefault(e => e.IdEmployee == id && e.FilePath == null);
            return pdf;
        }

    }
}
