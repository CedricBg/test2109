using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Auth
{
    public class AddRegisterForm
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
