using DataAccess.Models.Employees;
using test2109.Models.Customer;

namespace test2109.Models.Planning
{
    public class StartEndTimeWork
    {
        public int StartId { get; set; }

        public DateTime? ArrivingTime { get; set; } = DateTime.Now;

        public DateTime? EndTime { get; set; } = null;

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }
    }
}
