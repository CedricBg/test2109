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

            modelBuilder.Entity("DataAccess.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"), 1L, 1);

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SreetAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DataAccess.Models.Auth.AddRegisterForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AddRegisterForm");
                });

            modelBuilder.Entity("DataAccess.Models.Auth.ConnectedForm", b =>
                {
                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ConnectedForm");
                });

            modelBuilder.Entity("DataAccess.Models.Countrys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countrys");
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
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

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
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("DataAccess.Models.Email", b =>
                {
                    b.Property<int?>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("EmailId"), 1L, 1);

                    b.Property<int>("DetailedEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmailId");

                    b.HasIndex("DetailedEmployeeId");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("DataAccess.Models.Employees.DetailedEmployee", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeCardNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("Vehicle")
                        .HasColumnType("bit");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("roleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("DepartementId");

                    b.HasIndex("UserId");

                    b.HasIndex("roleId");

                    b.ToTable("DetailedEmployees");
                });

            modelBuilder.Entity("DataAccess.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

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
                        .HasColumnType("nvarchar(80)");

                    b.Property<int?>("RoundsRondsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RfidNr");

                    b.HasIndex("RoundsRondsId");

                    b.ToTable("PassagesRounds");
                });

            modelBuilder.Entity("DataAccess.Models.Phone", b =>
                {
                    b.Property<int>("PhoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneId"), 1L, 1);

                    b.Property<int>("DetailedEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PhoneId");

                    b.HasIndex("DetailedEmployeeId");

                    b.ToTable("Phones");
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

            modelBuilder.Entity("DataAccess.Models.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleId"), 1L, 1);

                    b.Property<string>("DiminName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("Roles");
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

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoundsRondsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

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

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasFilter("[Login] IS NOT NULL");

                    b.ToTable("Users");
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
                    b.HasOne("DataAccess.Models.Employees.DetailedEmployee", "employee")
                        .WithMany("Email")
                        .HasForeignKey("DetailedEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("DataAccess.Models.Employees.DetailedEmployee", b =>
                {
                    b.HasOne("DataAccess.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.Departement", null)
                        .WithMany("Employees")
                        .HasForeignKey("DepartementId");

                    b.HasOne("DataAccess.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Address");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Models.PassageRound", b =>
                {
                    b.HasOne("DataAccess.Models.Rfid", "Rfid")
                        .WithMany()
                        .HasForeignKey("RfidNr");

                    b.HasOne("DataAccess.Models.Rounds", "Rounds")
                        .WithMany()
                        .HasForeignKey("RoundsRondsId");

                    b.Navigation("Rfid");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DataAccess.Models.Phone", b =>
                {
                    b.HasOne("DataAccess.Models.Employees.DetailedEmployee", "employee")
                        .WithMany("Phone")
                        .HasForeignKey("DetailedEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
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
                    b.HasOne("DataAccess.Models.Rounds", "Rounds")
                        .WithMany()
                        .HasForeignKey("RoundsRondsId");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DataAccess.Models.Customer", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DataAccess.Models.Departement", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DataAccess.Models.Employees.DetailedEmployee", b =>
                {
                    b.Navigation("Email");

                    b.Navigation("Phone");
                });
#pragma warning restore 612, 618
        }
    }
}
