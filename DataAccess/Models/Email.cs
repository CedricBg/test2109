﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Email
    {
        public int? EmailId { get; set; }

        public string EmailAddress { get; set; }
    }
}
