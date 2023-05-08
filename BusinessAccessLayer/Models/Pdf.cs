namespace BusinessAccessLayer.Models
{
    public class Pdf
    {
        public int IdPdf { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int IdEmployee { get; set; }

        public string FilePath { get; set; }

        public string Customer { get; set; }
    }
}
