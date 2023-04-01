using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Customer
{
    public class Customers
    {
        public int CustomerId { get; set; }

        public string NameCustomer { get; set; }

        public List<Site> Site { get; set; }

        public Role Role { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreationDate { get; set; }

        public ContactPerson? Contact { get; set; } = null!;

    }
}
