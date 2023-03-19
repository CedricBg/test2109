using test2109.Models.Employee;

namespace test2109.Models.Customer
{
    public class Customers
    {
        public int Id { get; set; }

        public string NameCustomer { get; set; }

        public List<ContactPerson> ContactPerson { get; set; } = null!;

        public List<Phone> EmergencyPhone { get; set; } = null!;

        public List<Phone> GeneralPhone { get; set; } = null!;

        public List<Email> EmergencyEmail { get; set; } = null!;

        public List<Email> GeneralEmail { get; set; } = null!;

        public string VatNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public Role Role { get; set; }

        public List<Address> Address { get; set; }

        public bool? IsDeleted { get; set; }

        public Language Language { get; set; }
    }
}
