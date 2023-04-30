using DataAccess.Models.Customer;
using DataAccess.Models.Employees;


namespace DataAccess.Models.Planning
{
    public class StartEndWorkTime
    {
        public int StartId { get; set; }

        public DateTime? ArrivingTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }
    }
}
