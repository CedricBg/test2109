using DataAccess.Models;

namespace test2109.Models.Employee
{
    public class DetailEmployed
    {

        public int? Id { get; set; }

        public string firstName { get; set; } = null!;

        public string SurName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public bool Vehicle { get; set; }

        public string SecurityCard { get; set; }

        public DateTime EntryService { get; set; }

        public string EmployeeCardNumber { get; set; }

        public string RegistreNational { get; set; } = null!;

        public bool? IsDeleted { get; set; }

        public Role Role { get; set; }

        public List<Phone> Phone { get; set; }

        public List<Email> Email { get; set; }

        public Address Address { get; set; }

        public Language Language { get; set; }
    }
}
