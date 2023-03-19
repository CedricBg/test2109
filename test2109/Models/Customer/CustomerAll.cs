using test2109.Models.Employee;

namespace test2109.Models.Customer
{
    public class CustomerAll
    {
        public int Id { get; set; }

        public string NameCustomer { get; set; }

        public List<ContactPerson> ContactPerson { get; set; } = null!;

        public List<Phone> EmergencyPhone { get; set; } = null!;

        public List<Phone> GeneralPhone { get; set; } = null!;

        public List<Email> EmergencyEmail { get; set; } = null!;

        public List<Email> GeneralEmail { get; set; } = null!;

        public Language Language { get; set; }
    }
}
