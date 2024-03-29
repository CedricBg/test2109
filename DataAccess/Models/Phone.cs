﻿

using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Models
{
    public class Phone
    {
        public int? PhoneId { get; set; }

        public string Number { get; set; }

        public int? DetailedEmployeeId { get; set; }

        public DetailedEmployee employee { get; set; }
        [JsonIgnore]
        public int? ContactId { get; set; }
        [JsonIgnore]
        public ContactPerson Sender { get; set; }


    }
}
