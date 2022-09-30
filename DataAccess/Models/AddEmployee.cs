using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AddEmployee
    {
        [Required]
        [MaxLength(50)]
        public string firstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string SurName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool Vehicle { get; set; }

        [MaxLength(100)]
        public string? SecurityCard { get; set; }

        public DateTime EntryService { get; set; }

        [MaxLength(100)]
        public string? EmployeeCardNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string RegistreNational { get; set; } = null!;

        public bool Actif { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationDate { get; set; }
    }
}
