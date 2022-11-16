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

        public string Login { get; set; }

        public string Password_hash { get; set; }

        public string Salt { get; set; }
    }
}
