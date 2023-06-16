using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Rondes
{
    public class RfidRound
    {
        public int RfidRoundId { get; set; }
        public int RoundId { get; set; }
        public int RfidId { get; set; }
    }
}
