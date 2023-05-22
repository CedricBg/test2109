using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Models.Auth;
using DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository;
using DataAccess.Models.Planning;
using DataAccess.Models.Rondes;
using DataAccess.Models.Discussion;

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
            modelBuilder.Ignore<Employee>();
            modelBuilder.Ignore<ConnectedForm>();

            modelBuilder.Entity<ConnectedForm>().HasNoKey();

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.MessageId);
                entity.HasIndex(e => e.MessageId).IsUnique();
                entity.Property(e=>e.Text).HasMaxLength(100).IsRequired(true);
            });

                modelBuilder.Entity<Rounds>(entity =>
            {
                entity.HasKey(e =>e.RoundsId);
                entity.HasIndex(c => c.RoundsId).IsUnique();
                entity.Property(e=>e.Name).HasMaxLength(50).IsRequired(true);
            });

                modelBuilder.Entity<Pdf>(entity => {
                entity.HasKey(e => e.IdPdf);
                entity.HasIndex(c => c.IdPdf).IsUnique();
                entity.Property(c => c.Title).HasMaxLength(30);
                entity.Property(c => c.FilePath).HasMaxLength(50);
                entity.Property(e => e.DateCreate).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StartEndWorkTime>(entity =>
            {
                entity.HasKey(c => c.StartId);
                entity.HasIndex(c=>c.StartId).IsUnique();
            });

            modelBuilder.Entity<Working>(entity =>
            {
                entity.Ignore(c => c.IsWorking);
                entity.HasKey(c => c.WorkingId);
                entity.HasIndex(c => c.WorkingId).IsUnique();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(c => c.Login).IsUnique();
                entity.Property(e => e.Login).HasMaxLength(20);
                entity.Property(e => e.Salt).HasMaxLength(100);
                entity.Property(e => e.Password_hash).HasColumnType("varbinary").HasMaxLength(64);

            });
            modelBuilder.Ignore<AddRegisterForm>();

            modelBuilder.Entity<AddRegisterForm>(entity =>
            {
                entity.Property(e => e.Login).HasMaxLength(20).IsRequired(true);
                entity.Property(e => e.Password).HasMaxLength(50).IsRequired(true);
            });

            modelBuilder.Entity<DetailedEmployee>(entity =>
            {
                entity.HasOne(e => e.User).WithMany().OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Role).WithMany().OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.firstName).HasMaxLength(50).IsRequired(true);
                entity.Property(e => e.SurName).HasMaxLength(50).IsRequired(true);
                entity.Property(e => e.PhotoName).HasMaxLength(50);
                entity.Property(e => e.BirthDate).IsRequired(true);
                entity.Property(e => e.Vehicle).IsRequired(true);
                entity.Property(e => e.SecurityCard).HasMaxLength(100);
                entity.Property(e => e.EmployeeCardNumber).HasMaxLength(100);
                entity.Property(e => e.RegistreNational).HasMaxLength(20).IsRequired(true);
                entity.Property(e => e.CreationDate).ValueGeneratedOnAdd();
                entity.HasOne(e => e.Address).WithMany().OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Language).WithMany().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Rounds>(entity =>
            {
                entity.HasKey(e => e.RoundsId);
                entity.HasIndex(e => e.RoundsId).IsUnique();
            });

            modelBuilder.Entity<Control>(entity =>
            {
                entity.HasKey(e => e.ControlId);
                entity.HasIndex(e => e.ControlId).IsUnique();
            });

            modelBuilder.Entity<RfidPatrol>(entity =>
            {
                entity.HasKey(e => e.PatrolId);
                entity.HasIndex(e => e.PatrolId).IsUnique();
                entity.Property(e => e.RfidNr).HasMaxLength(80).IsRequired(true);
                entity.Property(e => e.Location).HasMaxLength(50).IsRequired(true);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
                entity.HasIndex(c => c.CustomerId).IsUnique();
                entity.HasOne(e => e.Role).WithMany().OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.NameCustomer).HasMaxLength(30).IsRequired(true);
                entity.Property(e => e.CreationDate).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasOne(e => e.Customer).WithMany(e => e.Site).HasPrincipalKey(e => e.CustomerId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Name).HasMaxLength(30).IsRequired(true);
                entity.Property(e => e.VatNumber).HasMaxLength(30).IsRequired(true);
                entity.Ignore(e => e.CustomerIdCreate);
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.HasKey(e => e.ContactId);
                entity.HasIndex(c => c.ContactId).IsUnique();
                entity.Property(e => e.LastName).HasMaxLength(30).IsRequired(true);
                entity.Property(e => e.FirstName).HasMaxLength(30).IsRequired(true);
                entity.HasOne(e => e.ContactSite).WithMany(s => s.ContactSite).HasForeignKey(p => p.ContactSiteId).OnDelete(DeleteBehavior.Restrict);
                entity.Ignore(e => e.SiteId);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.EmailAddress).HasMaxLength(30);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Number).HasMaxLength(30);
            });

            modelBuilder.Entity<Address>(Entity =>
            {
                Entity.Property(e => e.SreetAddress).HasMaxLength(50);
                Entity.Property(e => e.City).HasMaxLength(50);
                Entity.Property(e => e.ZipCode).HasMaxLength(50);
                Entity.Ignore(e => e.State);
            });

            modelBuilder.Entity<Countrys>(Entity =>
            {
                Entity.Property(e => e.Country).HasMaxLength(50);
            });

            modelBuilder.Entity<Language>(Entity =>
            {
                Entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Role>(Entity =>
            {
                Entity.Property(e => e.Name).HasMaxLength(40);
                Entity.Property(e => e.DiminName).HasMaxLength(5);
            });

            modelBuilder.Entity<FotoDb>(Entity =>
            {
                Entity.Property(e => e.NameFoto).HasMaxLength(70);
            });
        }

        public DbSet<Countrys> Countrys { get; set; }

        public DbSet<Message> Message { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Employee> employees { get; set; }

        public DbSet<DetailedEmployee> DetailedEmployees { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Email> EmailAddresses { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<Departement> Departements { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<RfidPatrol> RfidPatrol { get; set; }

        public DbSet<Rounds> Rounds { get; set; }
        
        public DbSet<Control> Control { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<ContactPerson> ContactPersons { get; set; }

        public DbSet<Address> addressCustomers { get; set; }

        public DbSet<Site> Sites { get; set; }

        public DbSet<StartEndWorkTime> StartEndWorkTime { get; set;}

        public DbSet<Working> Working { get; set; }

        public DbSet<Pdf> Pdf { get; set; }

        public DbSet<FotoDb> Foto { get; set; }   
    }
}
