using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Rondes
{
    public class Control
    {
        public int ControlId { get; set; }

        public Rounds Rounds { get; set; }

        public RfidPatrol Patrol { get; set; }
    }
}
