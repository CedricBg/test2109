using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Auth
{
    [NotMapped]
    public class AddRegisterForm
    {
        
        public int Id {  get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }

        public int Role { get; set; }
    }
}
