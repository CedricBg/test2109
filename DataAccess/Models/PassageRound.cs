using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PassageRound
    {
        public int Id { get; set; }

        public Rfid Rfid { get; set; } = null!;

        public Rounds Rounds { get; set; } = null!;  

        public int OrderPAssage { get; set; }

    }
}
