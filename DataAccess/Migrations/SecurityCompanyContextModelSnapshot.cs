﻿// <auto-generated />
using System;
using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(SecurityCompanyContext))]
    partial class SecurityCompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerEmployee", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("customersId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "customersId");

                    b.HasIndex("customersId");

                    b.ToTable("CustomerEmployee");
                });

            modelBuilder.Entity("DataAccess.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("SreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DataAccess.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("EmergencyEmail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmergencyPhoneNumber")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("GeneralPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("UserIdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserIdId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataAccess.Models.Departement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("DataAccess.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("DataAccess.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Actif")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeCardNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EntryService")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistreNational")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SecurityCard")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserIdId")
                        .HasColumnType("int");

                    b.Property<bool>("Vehicle")
                        .HasColumnType("bit");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserIdId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DataAccess.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("DataAccess.Models.PassageRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderPAssage")
                        .HasColumnType("int");

                    b.Property<string>("RfidNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("RoundsRondsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RfidNr");

                    b.HasIndex("RoundsRondsId");

                    b.ToTable("PassagesRounds");
                });

            modelBuilder.Entity("DataAccess.Models.Rfid", b =>
                {
                    b.Property<string>("RfidNr")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RfidNr");

                    b.HasIndex("CustomerId");

                    b.ToTable("Rfids");
                });

            modelBuilder.Entity("DataAccess.Models.Rounds", b =>
                {
                    b.Property<int>("RondsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RondsId"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("RondsId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("DataAccess.Models.ScheduledRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoundsRondsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoundsRondsId");

                    b.ToTable("ScheduledRounds");
                });

            modelBuilder.Entity("DataAccess.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("Password_hash")
                        .HasMaxLength(64)
                        .HasColumnType("varbinary(64)");

                    b.Property<string>("Salt")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DepartementEmployee", b =>
                {
                    b.Property<int>("DepartementsId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("DepartementsId", "EmployeesId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("DepartementEmployee");
                });

            modelBuilder.Entity("CustomerEmployee", b =>
                {
                    b.HasOne("DataAccess.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("customersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.Address", b =>
                {
                    b.HasOne("DataAccess.Models.Employee", null)
                        .WithMany("Addresses")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("DataAccess.Models.Customer", b =>
                {
                    b.HasOne("DataAccess.Models.Users", "UserId")
                        .WithMany()
                        .HasForeignKey("UserIdId");

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("DataAccess.Models.Email", b =>
                {
                    b.HasOne("DataAccess.Models.Employee", null)
                        .WithMany("Emails")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("DataAccess.Models.Employee", b =>
                {
                    b.HasOne("DataAccess.Models.Users", "UserId")
                        .WithMany()
                        .HasForeignKey("UserIdId");

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("DataAccess.Models.Language", b =>
                {
                    b.HasOne("DataAccess.Models.Customer", null)
                        .WithMany("Languages")
                        .HasForeignKey("CustomerId");

                    b.HasOne("DataAccess.Models.Employee", null)
                        .WithMany("Languages")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("DataAccess.Models.PassageRound", b =>
                {
                    b.HasOne("DataAccess.Models.Rfid", "Rfid")
                        .WithMany()
                        .HasForeignKey("RfidNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Rounds", "Rounds")
                        .WithMany()
                        .HasForeignKey("RoundsRondsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rfid");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DataAccess.Models.Rfid", b =>
                {
                    b.HasOne("DataAccess.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DataAccess.Models.Rounds", b =>
                {
                    b.HasOne("DataAccess.Models.Customer", null)
                        .WithMany("Rounds")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("DataAccess.Models.ScheduledRound", b =>
                {
                    b.HasOne("DataAccess.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("DataAccess.Models.Rounds", "Rounds")
                        .WithMany()
                        .HasForeignKey("RoundsRondsId");

                    b.Navigation("Employee");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DepartementEmployee", b =>
                {
                    b.HasOne("DataAccess.Models.Departement", null)
                        .WithMany()
                        .HasForeignKey("DepartementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.Customer", b =>
                {
                    b.Navigation("Languages");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DataAccess.Models.Employee", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Emails");

                    b.Navigation("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}
