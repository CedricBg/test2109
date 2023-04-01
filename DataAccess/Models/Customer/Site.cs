using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Models.Customer
{
    public class Site
    {
        public int SiteId { get; set; }

        public string Name { get; set; }

        public string VatNumber { get; set; }

        public bool? IsDeleted { get; set; }
        [JsonIgnore]
        public  List<ContactPerson>? ContactSite { get; set; }

        public DateTime? CreationDate { get; set; }

        public Language? Language { get; set; }

        public Address Address { get; set; }

        public Users Users { get; set; }
        [JsonIgnore]
        public int CustomersId { get; set; }
        [JsonIgnore]
        public Customers Customer { get; set; }

        



    }
}
