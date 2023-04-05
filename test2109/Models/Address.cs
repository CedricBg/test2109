using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2109.Models
{
    /// <summary>Class qui sert a afficher et creer des adresses</summary>
    public class Address
    {
        public int AddressId { get; set; }

        public string? SreetAddress { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public int? StateId { get; set; }

        public string? ZipCode { get; set; }
    }
}
