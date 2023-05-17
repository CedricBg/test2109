using AutoMapper;
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
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using HtmlRendererCore.PdfSharp;
using PdfSharpCore;
using System.Net;
using System.Reflection.Metadata;

namespace DataAccess.Services
{
    public class RapportServices : IRapportServices
    {
        SecurityCompanyContext _context;

        public RapportServices(SecurityCompanyContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// On créé le pdf et on sauvegarde la route dans la table pdf
        /// </summary>
        public Pdf CreatePdf(Pdf pdf)
        {
            try
            {
                if (pdf == null)
                    return new Pdf();
                string site = _context.Sites.Where(c=>c.SiteId == pdf.SiteId).Select(e=>e.Name).First();

                string folderPath = CreateFolder("..\\pdf\\" + site);

                string texte = pdf.Content;
                string title = pdf.Title;
                PdfDocument document = new PdfDocument();

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                using (PdfDocument pdfDocument = PdfGenerator.GeneratePdf(texte, PageSize.A4))
                {
                    string filename = title + ".pdf";
                    var filePath = Path.Combine(folderPath, filename);
                    pdfDocument.Save(filePath);
                    pdf.FilePath = filePath;
                }
                Pdf pdf1 = SaveRapport(pdf);
                return pdf1; 
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// On sauvegarde le rapport si c'est à la création de
        /// </summary>
        /// <param name="pdf"></param>
        /// <returns></returns>
        public Pdf SaveRapport(Pdf pdf)
        {
            try
            {
                Pdf pdf1 = _context.Pdf.FirstOrDefault(e => e.Title == pdf.Title);
                if (pdf1 == null)
                {
                    pdf1 = new Pdf
                    {
                        Title = pdf.Title,
                        Content = pdf.Content,
                        SiteId = pdf.SiteId,
                        DateCreate = DateTime.Now,
                        IdEmployee = pdf.IdEmployee,
                    };
                    _context.Add(pdf1);
                    _context.SaveChanges();
                    return pdf1;
                }
                else
                {
                    pdf1.Content = pdf.Content;
                    pdf1.FilePath = pdf.FilePath;
                    _context.SaveChanges();
                    return pdf1;
                }
            }
            catch(Exception) { 
                return new Pdf(); 
            }
        }

        public Pdf checkRapport(int id)
        {
            Pdf pdf = _context.Pdf.OrderBy(e=>e.IdPdf).LastOrDefault(e => e.IdEmployee == id && e.FilePath == null);
            return pdf;
        }

        public List<Pdf> listRapport(int id)
        {
            if (id == 0)
                return new List<Pdf>();
            try
            { 
                List<Pdf> list = _context.Pdf
                    .Where(e => e.IdEmployee == id)
                    .Select(p => new Pdf
                    {
                        Title = p.Title,
                        IdPdf = p.IdPdf,
                    })
                    .ToList();
                 return list;
            }
            catch(Exception)
            {
                return new List<Pdf>();
            }
        }

        public byte[] loadRapport(int id)
        {
            string pdfFilePath = GetFilePath(id);
            if (pdfFilePath == null)
                throw new FileNotFoundException($"Le fichier PDF avec l'ID {id} n'a pas été trouvé.");
            byte[] pdfData = File.ReadAllBytes(pdfFilePath);
            return pdfData;
        }

        

        private string GetFilePath(int id)
        {
            string FilePath = _context.Pdf
                .Where(e => e.IdPdf == id).Select(c => c.FilePath).FirstOrDefault();
            return FilePath;
        }

        private string CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
    }
}
