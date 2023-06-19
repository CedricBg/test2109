using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Rondes
{
    public class PutRfidRounds
    {
        public int IdRound { get; set; }

        public List<RfidPatrol> ListRfid { get; set; }
    }
}
