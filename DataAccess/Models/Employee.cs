using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Employee
    {
        public int? Id { get; set; }

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

        [Column("UserId")]
        public Users? User { get; set; }

        [Required]
        public List<Address> Addresses { get; set; } = new List<Address>();

        public List<Email> Emails { get; set; } = new List<Email>();

        public List<Customer>? customers { get; set; } = new List<Customer>();

        public List<Language> Languages { get; set; } = new List<Language>();

        public List<Departement>? Departements { get; set; } = new List<Departement>();

    }
}
