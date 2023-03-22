
using BusinessAccessLayer.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Customers
{
    public class Site
    {
        public int SiteId { get; set; }

        public string Name { get; set; }

        public List<Phone>? EmergencyPhone { get; set; } = null!;

        public List<Phone>? GeneralPhone { get; set; } = null!;

        public List<Email>? EmergencyEmail { get; set; } = null!;

        public List<Email>? GeneralEmail { get; set; } = null!;

        public string VatNumber { get; set; }

        public DateTime? CreationDate { get; set; }

        public bool? IsDeleted { get; set; }

        public Language? Language { get; set; }

        public Address adress { get; set; }

        public List<ContactPerson>? contacts { get; set; }
    }
}
