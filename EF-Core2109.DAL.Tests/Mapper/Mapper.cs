using DataAccess.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tools.Mapper
{
    public static class Mapper
    {
        public static AllCustomers Allcust(this Customers customers)
        {
            return new AllCustomers
            {
                Contact = customers.Contact,
                NameCustomer = customers.NameCustomer,
                Id = customers.CustomerId
            };
        }
    }
}
