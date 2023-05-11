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
using AutoMapper;
using DataAccess.Repository;
using DATA = DataAccess.Models;
using DataAccess.Services;


namespace BusinessAccessLayer.Services
{
    public class PdfService : IPdfService
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _Mapper;
        private readonly IRapportServices _RapportServices;

        public PdfService(IWebHostEnvironment webHostEnvironment, IMapper mapper, IRapportServices rapportServices)
        {
            _webHostEnvironment = webHostEnvironment;
            _Mapper = mapper;
            _RapportServices = rapportServices;
        }

        public Pdf CreatePdf(Pdf pdf)
        {
            if(pdf == null)
                return new Pdf();

            string folderPath = "..\\pdf\\"+pdf.Customer;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
                
            string texte = pdf.Content;
            string title = pdf.Title;
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            using (PdfDocument pdfDocument = PdfGenerator.GeneratePdf(texte, PageSize.A4))
            {
                string filename = title+".pdf";
                var filePath = Path.Combine(folderPath, filename);
                pdfDocument.Save(filePath);
                pdf.FilePath = filePath;
                var pdfSend = _Mapper.Map<DATA.Pdf>(pdf);
                return _Mapper.Map<Pdf>(_RapportServices.PdfAdd(pdfSend));
            }
        }

        public Pdf SaveRapport(Pdf pdf)
        {
            if (pdf == null)
                return new Pdf();

            string folderPath = "..\\pdf\\" + pdf.Customer;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var pdfSend = _Mapper.Map<DATA.Pdf>(pdf);
            return _Mapper.Map<Pdf>(_RapportServices.PdfAdd(pdfSend));

        }

        public Pdf checkRapport(int id)
        {
            Pdf pdf =  _Mapper.Map<Pdf>(_RapportServices.checkRapport(id));
            return pdf;
        }
    }
}
