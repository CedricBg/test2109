using DataAccess.Models;
using DataAccess.Models.Auth;
using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public interface ISecurityCompanyContext
    {
        DbSet<Address> Address { get; set; }
        DbSet<Address> addressCustomers { get; set; }
        DbSet<ConnectedForm> ConnectedForm { get; set; }
        DbSet<ContactPerson> ContactPersons { get; set; }
        DbSet<Countrys> Countrys { get; set; }
        DbSet<Customers> Customers { get; set; }
        DbSet<Departement> Departements { get; set; }
        DbSet<DetailedEmployee> DetailedEmployees { get; set; }
        DbSet<Email> EmailAddresses { get; set; }
        DbSet<Employee> employees { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<PassageRound> PassagesRounds { get; set; }
        DbSet<Phone> Phones { get; set; }
        DbSet<Rfid> Rfids { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Rounds> Rounds { get; set; }
        DbSet<ScheduledRound> ScheduledRounds { get; set; }
        DbSet<Site> Sites { get; set; }
        DbSet<Users> Users { get; set; }
    }
}