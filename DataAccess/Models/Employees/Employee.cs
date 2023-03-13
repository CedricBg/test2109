using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Employees
{
    public class Employee
    {

        public int? Id { get; set; }

        public string firstName { get; set; }

        public string SurName { get; set; }

        public Role Role { get; set; }
    }
}
