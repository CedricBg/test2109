using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Users
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string? Login { get; set; }

        [MaxLength (64)]
        [Column(TypeName = "varbinary(64)")]
        public string? Password_hash { get; set; }

        [MaxLength(100)]
        public string? Salt { get; set; }
    }
}
