using DataAccess.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Rondes
{
    public class Rounds
    {
        public int RoundsId { get; set; }

        public string Name { get; set; }

        public Site Site { get; set; }
    }
}
