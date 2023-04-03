using DataAccess.Models;

namespace test2109.Models.Customer
{
    public class Site
    {
        public int? SiteId { get; set; }

        public string Name { get; set; }

        public string? VatNumber { get; set; }

        public bool? IsDeleted { get; set; }

        public List<ContactPerson>? ContactSite { get; set; }

        public DateTime? CreationDate { get; set; }

        public Language? Language { get; set; }

        public Address Address { get; set; }

        public int? CustomerIdCreate { get; set; }
    }
}
