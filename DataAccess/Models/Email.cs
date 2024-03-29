﻿using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Email
    {
  
        public int? EmailId { get; set; }

        public string EmailAddress { get; set; }

        public int? DetailedEmployeeId { get; set; }

        public DetailedEmployee employee { get; set; }

        public int? ContactId { get; set; }
        [JsonIgnore]
        public ContactPerson Sender { get; set; }

    }
}
