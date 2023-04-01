using test2109.Models.Employee;

namespace test2109.Models.Customer
{
    public class ContactPerson
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public List<Email> Email { get; set; }
        
        public List<Phone> Phone { get; set; }

        public Boolean? responsible { get; set; }

        public Boolean? EmergencyContact { get; set; }

        public Boolean? NightContact { get; set; }
         
    }
}
