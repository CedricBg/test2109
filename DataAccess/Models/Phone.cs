

using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Phone
    {
        public int? PhoneId { get; set; }

        public string Number { get; set; }

        public int? DetailedEmployeeId { get; set; }

        public DetailedEmployee employee { get; set; }

        public int? CustomerId { get; set; }

        public Customer.Customers CustomerG { get; set; }

        public Customer.Customers CustomerE { get; set; }
    }
}
