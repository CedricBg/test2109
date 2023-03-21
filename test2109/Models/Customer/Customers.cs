﻿using test2109.Models.Employee;

namespace test2109.Models.Customer
{
    public class Customers
    {
        public int Id { get; set; }

        public string NameCustomer { get; set; }

        public List<Site> Site { get; set; }

        public Role Role { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
