﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Customer
{
    public class AllCustomers
    {
        public int CustomerId { get; set; }

        public string NameCustomer { get; set; }

        public List<AllSites> Site { get; set; }

        public ContactPerson Contact { get; set; }

    }
}
