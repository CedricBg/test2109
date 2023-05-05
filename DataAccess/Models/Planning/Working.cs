using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Planning
{
    public class Working
    {
        public int WorkingId { get; set; }

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public bool IsWorking { get; set; }

    }
}
