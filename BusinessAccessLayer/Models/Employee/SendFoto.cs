using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models.Employee
{
    public class SendFoto
    {
        public int IdEmployee { get; set; }

        public IFormFile Foto { get; set; }
    }
}
