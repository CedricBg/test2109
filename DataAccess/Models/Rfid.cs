using DataAccess.Models.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Rfid
    {
        public string RfidNr { get; set; } = null!;

        public string Location { get; set; } = null!;

        public Customers Customer { get; set; }


    }
}
