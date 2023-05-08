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
using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography.X509Certificates;

namespace BusinessAccessLayer.Services
{
    public class PdfService : IPdfService
    {
        private IWebHostEnvironment _webHostEnvironment;

        public PdfService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void CreatePdf(Pdf pdf)
        {


            string texte = pdf.Content;
            string title = pdf.Title;
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            using (PdfDocument pdfDocument = PdfGenerator.GeneratePdf(texte, PageSize.A4))
            {
                string filename = title+".pdf";
                var filePath = Path.Combine("..","pdf", filename);
                pdfDocument.Save(filePath);
            }
        }
    }
}
