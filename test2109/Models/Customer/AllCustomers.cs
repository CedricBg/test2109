namespace test2109.Models.Customer
{
    public class AllCustomers
    {
        public int Id { get; set; }

        public string NameCustomer { get; set; }

        public List<AllSites> Site { get; set; }

        public ContactPerson Contact { get; set; }
    }
}
