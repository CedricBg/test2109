namespace test2109.Models.Ronde
{
    public class RfidPatrol
    {
        public int PatrolId { get; set; }

        public string RfidNr { get; set; } = null!;

        public string Location { get; set; } = null!;

        public int IdSite { get; set; }

        public int Position { get; set; }
    }
}
