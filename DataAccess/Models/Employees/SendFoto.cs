using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Employees
{
    public class SendFoto
    {
        public int? Id { get; set; }

        public int IdEmployee { get; set; }

        public IFormFile Foto { get; set; }
    }
}
