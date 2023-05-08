using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class AgentServices : IAgentServices
    {
        private readonly SecurityCompanyContext _context;

        public AgentServices(SecurityCompanyContext context)
        {
            _context = context;
        }

        public List<Customers> assignedClients(int id)
        {
            var clients = _context.Working
                     .Where(w => w.EmployeeId == id)
                     .Join(
                        _context.Customers,
                        w => w.CustomerId,
                        c => c.CustomerId,
                        (w, c) => c
                     );

            return clients.ToList();

        }

        public Pdf PdfAdd(Pdf pdf)
        {
            Pdf pdf1 = _context.Pdf.FirstOrDefault(e=>e.IdPdf == pdf.IdPdf);
            
            if(pdf1 == null)
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
                _context.SaveChanges();
                return pdf1;
            }
        }

    }
}
