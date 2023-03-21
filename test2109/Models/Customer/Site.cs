using DataAccess.Models;

namespace test2109.Models.Customer
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

        public Users Users { get; set; }

        public bool? IsDeleted { get; set; }

        public Language? Language { get; set; }

        public Address customer { get; set; }

        public List<ContactPerson>? contacts { get; set; }
    }
}
