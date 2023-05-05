using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddRegisterForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddRegisterForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "ConnectedForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Countrys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiminName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RondsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RondsId);
                });

            migrationBuilder.CreateTable(
                name: "StartEndWorkTime",
                columns: table => new
                {
                    StartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartEndWorkTime", x => x.StartId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password_hash = table.Column<byte[]>(type: "varbinary(64)", maxLength: 64, nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Working",
                columns: table => new
                {
                    WorkingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Working", x => x.WorkingId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledRounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoundsRondsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledRounds_Rounds_RoundsRondsId",
                        column: x => x.RoundsRondsId,
                        principalTable: "Rounds",
                        principalColumn: "RondsId");
                });

            migrationBuilder.CreateTable(
                name: "DetailedEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vehicle = table.Column<bool>(type: "bit", nullable: false),
                    SecurityCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmployeeCardNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegistreNational = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    PhotoId = table.Column<int>(type: "int", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailedEmployees_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailedEmployees_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetailedEmployees_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailedEmployees_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailedEmployees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersons",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Responsible = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmergencyContact = table.Column<bool>(type: "bit", nullable: true),
                    NightContact = table.Column<bool>(type: "bit", nullable: true),
                    ContactSiteId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersons", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCustomer = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_ContactPersons_ContactId",
                        column: x => x.ContactId,
                        principalTable: "ContactPersons",
                        principalColumn: "ContactId");
                    table.ForeignKey(
                        name: "FK_Customers_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    EmailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DetailedEmployeeId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    SenderContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_EmailAddresses_ContactPersons_SenderContactId",
                        column: x => x.SenderContactId,
                        principalTable: "ContactPersons",
                        principalColumn: "ContactId");
                    table.ForeignKey(
                        name: "FK_EmailAddresses_DetailedEmployees_DetailedEmployeeId",
                        column: x => x.DetailedEmployeeId,
                        principalTable: "DetailedEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    PhoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DetailedEmployeeId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    SenderContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phones_ContactPersons_SenderContactId",
                        column: x => x.SenderContactId,
                        principalTable: "ContactPersons",
                        principalColumn: "ContactId");
                    table.ForeignKey(
                        name: "FK_Phones_DetailedEmployees_DetailedEmployeeId",
                        column: x => x.DetailedEmployeeId,
                        principalTable: "DetailedEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rfids",
                columns: table => new
                {
                    RfidNr = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rfids", x => x.RfidNr);
                    table.ForeignKey(
                        name: "FK_Rfids_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    UsersId = table.Column<int>(type: "int", nullable: true),
                    CustomersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteId);
                    table.ForeignKey(
                        name: "FK_Sites_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Sites_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sites_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sites_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PassagesRounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfidNr = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    RoundsRondsId = table.Column<int>(type: "int", nullable: true),
                    OrderPAssage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassagesRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassagesRounds_Rfids_RfidNr",
                        column: x => x.RfidNr,
                        principalTable: "Rfids",
                        principalColumn: "RfidNr");
                    table.ForeignKey(
                        name: "FK_PassagesRounds_Rounds_RoundsRondsId",
                        column: x => x.RoundsRondsId,
                        principalTable: "Rounds",
                        principalColumn: "RondsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_ContactId",
                table: "ContactPersons",
                column: "ContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_ContactSiteId",
                table: "ContactPersons",
                column: "ContactSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactId",
                table: "Customers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_roleId",
                table: "Customers",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedEmployees_AddressId",
                table: "DetailedEmployees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedEmployees_DepartementId",
                table: "DetailedEmployees",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedEmployees_LanguageId",
                table: "DetailedEmployees",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedEmployees_roleId",
                table: "DetailedEmployees",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedEmployees_UserId",
                table: "DetailedEmployees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_DetailedEmployeeId",
                table: "EmailAddresses",
                column: "DetailedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_SenderContactId",
                table: "EmailAddresses",
                column: "SenderContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PassagesRounds_RfidNr",
                table: "PassagesRounds",
                column: "RfidNr");

            migrationBuilder.CreateIndex(
                name: "IX_PassagesRounds_RoundsRondsId",
                table: "PassagesRounds",
                column: "RoundsRondsId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_DetailedEmployeeId",
                table: "Phones",
                column: "DetailedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_SenderContactId",
                table: "Phones",
                column: "SenderContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Rfids_CustomerId",
                table: "Rfids",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledRounds_RoundsRondsId",
                table: "ScheduledRounds",
                column: "RoundsRondsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_AddressId",
                table: "Sites",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_CustomersId",
                table: "Sites",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_LanguageId",
                table: "Sites",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_Name",
                table: "Sites",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sites_UsersId",
                table: "Sites",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_StartEndWorkTime_StartId",
                table: "StartEndWorkTime",
                column: "StartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true,
                filter: "[Login] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Working_WorkingId",
                table: "Working",
                column: "WorkingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_Sites_ContactSiteId",
                table: "ContactPersons",
                column: "ContactSiteId",
                principalTable: "Sites",
                principalColumn: "SiteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_Sites_ContactSiteId",
                table: "ContactPersons");

            migrationBuilder.DropTable(
                name: "AddRegisterForm");

            migrationBuilder.DropTable(
                name: "ConnectedForm");

            migrationBuilder.DropTable(
                name: "Countrys");

            migrationBuilder.DropTable(
                name: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "PassagesRounds");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "ScheduledRounds");

            migrationBuilder.DropTable(
                name: "StartEndWorkTime");

            migrationBuilder.DropTable(
                name: "Working");

            migrationBuilder.DropTable(
                name: "Rfids");

            migrationBuilder.DropTable(
                name: "DetailedEmployees");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ContactPersons");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
