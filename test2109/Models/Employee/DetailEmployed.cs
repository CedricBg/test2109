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

        public bool Actif { get; set; }

        public Role Role { get; set; }

        public List<Phone> Phones { get; set; }

        public List<Email> Emails { get; set; } 

        public Address Address { get; set; }    
    }
}
