using BusinessAccessLayer.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Customer
{
    public  class Customers
    {
        public int Id { get; set; }

        public string NameCustomer { get; set; }

        public List<ContactPerson>? ContactPerson { get; set; } 

        public List<Phone>? EmergencyPhone { get; set; }

        public List<Phone>? GeneralPhone { get; set; } 

        public List<Email>? EmergencyEmail { get; set; } 

        public List<Email>? GeneralEmail { get; set; } 

        public string VatNumber { get; set; }

        public DateTime? CreationDate { get; set; }

        public Role Role { get; set; }

        public IList<Address>? Address { get; set; }

        public bool? IsDeleted { get; set; }

        public Language? Language { get; set; }
    }
}
