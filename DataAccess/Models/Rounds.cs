﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Rounds
    {
        [Key]
        public int RondsId { get; set; }

        public int Name { get; set;}

    }
}