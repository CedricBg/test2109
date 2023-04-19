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

namespace BusinessAccessLayer.Services
{
    public class PdfService : IPdfService
    {
        public void CreatePdf()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);


            const string texte = "<h1>Rapport de cedric bogaert</h1><p><b><u>Nr; de carte minist&#233;rielle</u></b> : </p><br><p><b>19/04/2023</b></p><br>&#10;<br>&#10;&#10; <table>&#10; <thead>&#10; <tr>&#10; <th><u>Heure de d&#233;but</u></th>&#10; <th><u>Heure de fin</u></th>&#10; <th><u>Message</u></th>&#10; </tr>&#10; </thead>&#10; <tbody>&#10; <tr>&#10; <td>08h00</td>&#10; <td>09h00</td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td>09h00</td>&#10; <td>10h00</td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; <tr>&#10; <td></td>&#10; <td></td>&#10; <td></td>&#10; </tr>&#10; </tbody>&#10; </table>";
            using (var stream = new MemoryStream())
            {
                PdfDocument pdfDocument = PdfGenerator.GeneratePdf(texte, PageSize.A4);

                const string filename = "HelloWorld.pdf";
                var filePath = Path.Combine("Images/", filename);
                pdfDocument.Save(filePath);
            }
            
            
            

        }

    }
}
