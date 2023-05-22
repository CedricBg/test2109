using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addRfidPatrol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rfids");

            migrationBuilder.CreateTable(
                name: "RfidPatrol",
                columns: table => new
                {
                    RfidNr = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoundsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfidPatrol", x => x.RfidNr);
                    table.ForeignKey(
                        name: "FK_RfidPatrol_Rounds_RoundsId",
                        column: x => x.RoundsId,
                        principalTable: "Rounds",
                        principalColumn: "RoundsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfidPatrol_RoundsId",
                table: "RfidPatrol",
                column: "RoundsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfidPatrol");

            migrationBuilder.CreateTable(
                name: "Rfids",
                columns: table => new
                {
                    RfidNr = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Rfids_CustomerId",
                table: "Rfids",
                column: "CustomerId");
        }
    }
}
