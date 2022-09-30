using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ScheduledRound
    {
        public int Id { get; set; } 

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }   

        public Rounds? Rounds { get; set; }

        public Employee? Employee { get; set; }
    }
}
