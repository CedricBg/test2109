namespace BusinessAccessLayer.Models.Planning
{
    public class Working
    {
        public int WorkingId { get; set; }

        public int SiteId { get; set; }

        public int EmployeeId { get; set; }
        
        public bool IsWorking { get; set; }
    }
}
