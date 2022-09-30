﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Departement
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        public ICollection<Employee> Employees { get; set; }

        
    }
}
