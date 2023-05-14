using BusinessAccessLayer.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Planning
{
    public class StartEndWorkTime
    {
        public int StartId { get; set; }

        public DateTime? ArrivingTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int SiteId { get; set; }

        public int EmployeeId { get; set; }
    }
}
