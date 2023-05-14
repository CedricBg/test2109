using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Models;
using AutoMapper;
using DataAccess.Repository;
using DATA = DataAccess.Models;
using DataAccess.Services;


namespace BusinessAccessLayer.Services
{
    public class PdfService : IPdfService
    {
        private readonly IMapper _Mapper;
        private readonly IRapportServices _RapportServices;

        public PdfService( IMapper mapper, IRapportServices rapportServices)
        {
            _Mapper = mapper;
            _RapportServices = rapportServices;
        }

        public Pdf CreatePdf(Pdf pdf)
        {
            var pdfSend = _Mapper.Map<DATA.Pdf>(pdf);
            return _Mapper.Map<Pdf>(_RapportServices.CreatePdf(pdfSend));
        }

        public Pdf SaveRapport(Pdf pdf)
        {
            if (pdf == null)
                throw new NullReferenceException();

            var pdfSend = _Mapper.Map<DATA.Pdf>(pdf);
            return _Mapper.Map<Pdf>(_RapportServices.SaveRapport(pdfSend));

        }

        public Pdf checkRapport(int id)
        {
            Pdf pdf =  _Mapper.Map<Pdf>(_RapportServices.checkRapport(id));
            return pdf;
        }

        public List<Pdf> listRapport(int id)
        {
            return _RapportServices.listRapport(id).Select(dr => _Mapper.Map<Pdf>(dr)).ToList();
        }

        public byte[] loadRapport(int id)
        {
            return _RapportServices.loadRapport(id);
        }

    }
}
