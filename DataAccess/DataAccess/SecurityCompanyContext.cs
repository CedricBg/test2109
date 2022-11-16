﻿using DataAccess.Models;
using DataAccess.Models.Auth;
using DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            modelBuilder.Ignore<ConnectedForm>();
            modelBuilder.Entity<ConnectedForm>().HasNoKey();

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
                entity.Property(e=>e.Login).HasMaxLength(20);
                entity.Property(e=>e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<DetailedEmployee>(entity =>
            {
                entity.Property(e=>e.firstName).HasMaxLength(50).IsRequired(true);
                entity.Property(e=>e.SurName).HasMaxLength(50).IsRequired(true);    
                entity.Property(e=>e.BirthDate).IsRequired(true);
                entity.Property(e=>e.Vehicle).IsRequired(true);
                entity.Property(e=>e.SecurityCard).HasMaxLength(100);
                entity.Property(e=>e.EmployeeCardNumber).HasMaxLength(100);
                entity.Property(e=>e.RegistreNational).HasMaxLength(20).IsRequired(true);
                entity.Property(e=>e.CreationDate).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Rfid>(entity =>
            {
                entity.HasKey(e => e.RfidNr);
                entity.Property(e=>e.RfidNr).HasMaxLength(80).HasMaxLength(80).IsRequired(true);
                entity.Property(e=>e.Location).HasMaxLength(50).IsRequired(true);
            });


            modelBuilder.Ignore<Employee>();
        }

        public DbSet<Countrys> Countrys { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<ConnectedForm> ConnectedForm { get; set; }
        
        public DbSet<Employee> employees { get; set; }

        public DbSet<DetailedEmployee> DetailedEmployees { get; set; }

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