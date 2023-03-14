using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Customer
{
    public class ContactPerson
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Address { get; set; }

        public int CustomerId { get; set; }

        public Customers customers { get; set; }
    }
}
