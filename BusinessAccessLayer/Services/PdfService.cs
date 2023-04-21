using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.IRepositories;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using HtmlRendererCore.PdfSharp;
using PdfSharpCore;
using BusinessAccessLayer.Models;

namespace BusinessAccessLayer.Services
{
    public class PdfService : IPdfService
    {
        public void CreatePdf(Pdf pdf)
        {
            string texte = pdf.Content;
            string title = pdf.Title;
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            using (var stream = new MemoryStream())
            {
                PdfDocument pdfDocument = PdfGenerator.GeneratePdf(texte, PageSize.A4);

                string filename = title+".pdf";
                var filePath = Path.Combine("Pdf/", filename);
                pdfDocument.Save(filePath);
            }
        }
    }
}
