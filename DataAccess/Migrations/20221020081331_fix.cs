using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GeneralPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmergencyEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmergencyPhoneNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vehicle = table.Column<bool>(type: "bit", nullable: false),
                    SecurityCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntryService = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeCardNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegistreNational = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Actif = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rfids",
                columns: table => new
                {
                    RfidNr = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rfids", x => x.RfidNr);
                    table.ForeignKey(
                        name: "FK_Rfids_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RondsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RondsId);
                    table.ForeignKey(
                        name: "FK_Rounds_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerEmployee",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    customersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEmployee", x => new { x.EmployeesId, x.customersId });
                    table.ForeignKey(
                        name: "FK_CustomerEmployee_Customers_customersId",
                        column: x => x.customersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartementEmployee",
                columns: table => new
                {
                    DepartementsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartementEmployee", x => new { x.DepartementsId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_DepartementEmployee_Departements_DepartementsId",
                        column: x => x.DepartementsId,
                        principalTable: "Departements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartementEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Languages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PassagesRounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfidNr = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    RoundsRondsId = table.Column<int>(type: "int", nullable: false),
                    OrderPAssage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassagesRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassagesRounds_Rfids_RfidNr",
                        column: x => x.RfidNr,
                        principalTable: "Rfids",
                        principalColumn: "RfidNr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassagesRounds_Rounds_RoundsRondsId",
                        column: x => x.RoundsRondsId,
                        principalTable: "Rounds",
                        principalColumn: "RondsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledRounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoundsRondsId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledRounds_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledRounds_Rounds_RoundsRondsId",
                        column: x => x.RoundsRondsId,
                        principalTable: "Rounds",
                        principalColumn: "RondsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEmployee_customersId",
                table: "CustomerEmployee",
                column: "customersId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserIdId",
                table: "Customers",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartementEmployee_EmployeesId",
                table: "DepartementEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_EmployeeId",
                table: "EmailAddresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CustomerId",
                table: "Languages",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_EmployeeId",
                table: "Languages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PassagesRounds_RfidNr",
                table: "PassagesRounds",
                column: "RfidNr");

            migrationBuilder.CreateIndex(
                name: "IX_PassagesRounds_RoundsRondsId",
                table: "PassagesRounds",
                column: "RoundsRondsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rfids_CustomerId",
                table: "Rfids",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_CustomerId",
                table: "Rounds",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledRounds_EmployeeId",
                table: "ScheduledRounds",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledRounds_RoundsRondsId",
                table: "ScheduledRounds",
                column: "RoundsRondsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "CustomerEmployee");

            migrationBuilder.DropTable(
                name: "DepartementEmployee");

            migrationBuilder.DropTable(
                name: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PassagesRounds");

            migrationBuilder.DropTable(
                name: "ScheduledRounds");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Rfids");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
