using DataAccess.Models;

namespace test2109.Models.Employee
{
    public class Employee
    {
        public int? Id { get; set; }

        public string firstName { get; set; }

        public string SurName { get; set; }

        public Role Role { get; set; }

        public Language Language { get; set; }
    }
}
