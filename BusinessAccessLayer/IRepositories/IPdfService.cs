﻿using BusinessAccessLayer.Models;

namespace BusinessAccessLayer.IRepositories
{
    public interface IPdfService
    {
        Pdf CreatePdf(Pdf pdf);
        Pdf SaveRapport(Pdf pdf);
        Pdf checkRapport(int id);
        List<Pdf> listRapport(int id);
        byte[] loadRapport(int id);
    }
}