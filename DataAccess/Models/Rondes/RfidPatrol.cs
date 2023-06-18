using DataAccess.Models.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Rondes
{
    public class RfidPatrol
    {
        public int PatrolId { get; set; }

        public string RfidNr { get; set; } = null!;

        public string Location { get; set; } = null!;

        public int IdSite { get; set; }
        public int Position { get; set; }

    }
}
