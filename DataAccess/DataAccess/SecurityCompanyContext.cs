using DataAccess.Models;
using DataAccess.Models.Auth;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectedForm>().HasNoKey();
        }

        public DbSet<ConnectedForm> ConnectedForm { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<AddRegisterForm> addRegisterForms { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Email> EmailAddresses { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Departement> Departements { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<PassageRound> PassagesRounds { get; set; }

        public DbSet<Rfid> Rfids { get; set; }

        public DbSet<Rounds> Rounds { get; set; }   

        public DbSet<ScheduledRound> ScheduledRounds { get; set; }

        public DbSet<Users> Users { get; set; }

    }
}
