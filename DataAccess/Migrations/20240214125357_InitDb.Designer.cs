﻿// <auto-generated />
using System;
using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(SecurityCompanyContext))]
    [Migration("20240214125357_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AddRegisterForm");
                });

            modelBuilder.Entity("DataAccess.Models.Auth.ConnectedForm", b =>
                {
                    b.Property<string>("Dimin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
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

            modelBuilder.Entity("DataAccess.Models.Customer.ContactPerson", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"), 1L, 1);

                    b.Property<int?>("ContactSiteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("DayContact")
                        .HasColumnType("bit");

                    b.Property<bool?>("EmergencyContact")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("NightContact")
                        .HasColumnType("bit");

                    b.Property<bool?>("Responsible")
                        .HasColumnType("bit");

                    b.HasKey("ContactId");

                    b.HasIndex("ContactId")
                        .IsUnique();

                    b.HasIndex("ContactSiteId");

                    b.ToTable("ContactPersons");
                });

            modelBuilder.Entity("DataAccess.Models.Customer.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameCustomer")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("roleId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("ContactId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("roleId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataAccess.Models.Customer.Site", b =>
                {
                    b.Property<int?>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("SiteId"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomersId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.Property<string>("VatNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SiteId");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomersId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UsersId");

                    b.ToTable("Sites");
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

            modelBuilder.Entity("DataAccess.Models.Discussion.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.ToTable("Message");
                });

            modelBuilder.Entity("DataAccess.Models.Email", b =>
                {
                    b.Property<int?>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("EmailId"), 1L, 1);

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<int?>("DetailedEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("SenderContactId")
                        .HasColumnType("int");

                    b.HasKey("EmailId");

                    b.HasIndex("DetailedEmployeeId");

                    b.HasIndex("SenderContactId");

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

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserId");

                    b.HasIndex("roleId");

                    b.ToTable("DetailedEmployees");
                });

            modelBuilder.Entity("DataAccess.Models.Employees.FotoDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameFoto")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("idEmployee")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("DataAccess.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("DataAccess.Models.Pdf", b =>
                {
                    b.Property<int>("IdPdf")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPdf"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdPdf");

                    b.HasIndex("IdPdf")
                        .IsUnique();

                    b.ToTable("Pdf");
                });

            modelBuilder.Entity("DataAccess.Models.Phone", b =>
                {
                    b.Property<int?>("PhoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PhoneId"), 1L, 1);

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<int?>("DetailedEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("SenderContactId")
                        .HasColumnType("int");

                    b.HasKey("PhoneId");

                    b.HasIndex("DetailedEmployeeId");

                    b.HasIndex("SenderContactId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("DataAccess.Models.Planning.StartEndWorkTime", b =>
                {
                    b.Property<int>("StartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StartId"), 1L, 1);

                    b.Property<DateTime?>("ArrivingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("StartId");

                    b.HasIndex("StartId")
                        .IsUnique();

                    b.ToTable("StartEndWorkTime");
                });

            modelBuilder.Entity("DataAccess.Models.Planning.Working", b =>
                {
                    b.Property<int>("WorkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkingId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("WorkingId");

                    b.HasIndex("WorkingId")
                        .IsUnique();

                    b.ToTable("Working");
                });

            modelBuilder.Entity("DataAccess.Models.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleId"), 1L, 1);

                    b.Property<string>("DiminName")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("roleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DataAccess.Models.Rondes.RfidPatrol", b =>
                {
                    b.Property<int>("PatrolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatrolId"), 1L, 1);

                    b.Property<int>("IdSite")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RfidNr")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PatrolId");

                    b.HasIndex("PatrolId")
                        .IsUnique();

                    b.HasIndex("Location", "RfidNr")
                        .IsUnique();

                    b.ToTable("RfidPatrol");
                });

            modelBuilder.Entity("DataAccess.Models.Rondes.RfidRound", b =>
                {
                    b.Property<int>("RfidRoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RfidRoundId"), 1L, 1);

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("RfidId")
                        .HasColumnType("int");

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.HasKey("RfidRoundId");

                    b.HasIndex("RfidRoundId")
                        .IsUnique();

                    b.ToTable("RfidRound", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.Rondes.Rounds", b =>
                {
                    b.Property<int>("RoundsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoundsId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("RoundsId");

                    b.HasIndex("RoundsId")
                        .IsUnique();

                    b.ToTable("Rounds");
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

            modelBuilder.Entity("DataAccess.Models.Customer.ContactPerson", b =>
                {
                    b.HasOne("DataAccess.Models.Customer.Site", "ContactSite")
                        .WithMany("ContactSite")
                        .HasForeignKey("ContactSiteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ContactSite");
                });

            modelBuilder.Entity("DataAccess.Models.Customer.Customers", b =>
                {
                    b.HasOne("DataAccess.Models.Customer.ContactPerson", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("DataAccess.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Contact");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DataAccess.Models.Customer.Site", b =>
                {
                    b.HasOne("DataAccess.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("DataAccess.Models.Customer.Customers", "Customer")
                        .WithMany("Site")
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccess.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("DataAccess.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("Address");

                    b.Navigation("Customer");

                    b.Navigation("Language");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DataAccess.Models.Email", b =>
                {
                    b.HasOne("DataAccess.Models.Employees.DetailedEmployee", "employee")
                        .WithMany("Email")
                        .HasForeignKey("DetailedEmployeeId");

                    b.HasOne("DataAccess.Models.Customer.ContactPerson", "Sender")
                        .WithMany("Email")
                        .HasForeignKey("SenderContactId");

                    b.Navigation("Sender");

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

                    b.HasOne("DataAccess.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Address");

                    b.Navigation("Language");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Models.Phone", b =>
                {
                    b.HasOne("DataAccess.Models.Employees.DetailedEmployee", "employee")
                        .WithMany("Phone")
                        .HasForeignKey("DetailedEmployeeId");

                    b.HasOne("DataAccess.Models.Customer.ContactPerson", "Sender")
                        .WithMany("Phone")
                        .HasForeignKey("SenderContactId");

                    b.Navigation("Sender");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("DataAccess.Models.Customer.ContactPerson", b =>
                {
                    b.Navigation("Email");

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("DataAccess.Models.Customer.Customers", b =>
                {
                    b.Navigation("Site");
                });

            modelBuilder.Entity("DataAccess.Models.Customer.Site", b =>
                {
                    b.Navigation("ContactSite");
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
