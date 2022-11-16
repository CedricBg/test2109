﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Employees

{
    public class DetailedEmployee
    {
        public int? Id { get; set; }

        public string firstName { get; set; } = null!;

        public string SurName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public bool Vehicle { get; set; }

        public string? SecurityCard { get; set; }

        public DateTime EntryService { get; set; }

        public string? EmployeeCardNumber { get; set; }

        public string RegistreNational { get; set; } = null!;

        public bool Actif { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("UserId")]
        public Users? User { get; set; }

        public int? RoleId { get; set; }


    }
}