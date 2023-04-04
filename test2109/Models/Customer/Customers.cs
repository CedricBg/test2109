using test2109.Models.Employee;

namespace test2109.Models.Customer
{
    /// <summary>
    /// Classe qui ne sert qu'au retour des infos client apres insertion pour mise a jour des donnèes dans angular
    /// </summary>
    public class Customers
    {
        public int CustomerId { get; set; }

        public string NameCustomer { get; set; }

        public List<Site> Site { get; set; }

        public Role Role { get; set; }

        public bool? IsDeleted { get; set; }

        public ContactPerson? Contact { get; set; } = null!;
    }
}
