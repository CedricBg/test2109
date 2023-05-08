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


namespace BusinessAccessLayer.Services
{
    public class PdfService : IPdfService
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _Mapper;
        private readonly IAgentServices _AgentServices;

        public PdfService(IWebHostEnvironment webHostEnvironment, IMapper mapper, IAgentServices agentServices)
        {
            _webHostEnvironment = webHostEnvironment;
            _Mapper = mapper;
            _AgentServices = agentServices;
        }
        public Pdf CreatePdf(Pdf pdf)
        {
            if(pdf == null)
            {
                return new Pdf();
            }
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
                return _Mapper.Map<Pdf>(_AgentServices.PdfAdd(pdfSend));
            }
        }
    }
}
