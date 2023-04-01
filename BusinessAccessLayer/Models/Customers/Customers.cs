using BusinessAccessLayer.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Customers
{
    public  class Customers
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
