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

        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [MaxLength(20)]
        public string GeneralPhone { get; set; } = null!;

        [MaxLength (50)]
        public string? EmergencyEmail { get; set; }

        [MaxLength (40)]
        public string? EmergencyPhoneNumber { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationDate { get; set; }

        public Users? UserId { get; set; }

        public ICollection<Rounds>? Rounds { get; set; }

        public ICollection<Employee>? Employees { get; set; }

        public ICollection<Language>? Languages { get; set; }

    }
}
