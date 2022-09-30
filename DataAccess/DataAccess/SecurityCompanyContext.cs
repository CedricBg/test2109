using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class SecurityCompanyContext : DbContext
    {

        public SecurityCompanyContext(DbContextOptions options) : base(options) { }



        public DbSet<Employee>? Employees { get; set; }


        public DbSet<Address>? Address { get; set; }

        public DbSet<Email>? EmailAddresses { get; set; }

        public DbSet<Customer>? Customers { get; set; }

        public DbSet<Departement>? Departements { get; set; }

        public DbSet<Language>? Languages { get; set; }

        public DbSet<PassageRound>? PassagesRounds { get; set; }

        public DbSet<Rfid>? Rfids { get; set; }

        public DbSet<Rounds>? Rounds { get; set; }   

        public DbSet<ScheduledRound>? ScheduledRounds { get; set; }

        public DbSet<Users>? Users { get; set; }

    }
}
