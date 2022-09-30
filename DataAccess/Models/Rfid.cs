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

        [Key]
        [Required]
        [MaxLength(80)]
        public string RfidNr { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Location { get; set; } = null!;

        [Required]
        public Customer Customer { get; set; } = null!;


    }
}
