using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } 

        public string GeneralPhone { get; set; } 

        public string? EmergencyEmail { get; set; }

        public string? EmergencyPhoneNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public Users? UserId { get; set; }

        public ICollection<Rounds>? Rounds { get; set; }
        
        public string? Role { get; set; }

    }
}
