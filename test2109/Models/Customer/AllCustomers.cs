namespace test2109.Models.Customer
{
    /// <summary>
    /// Utilisé dans CustomerController pour récuperé une liste minimaliste de customer
    /// </summary>
    public class AllCustomers
    {
        public int CustomerId { get; set; }

        public string NameCustomer { get; set; }

        public List<AllSites> Site { get; set; }

        public ContactPerson Contact { get; set; }
    }
}
