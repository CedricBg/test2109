using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class uniqueRfidAndLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RfidPatrol_RfidNr",
                table: "RfidPatrol");

            migrationBuilder.AlterColumn<string>(
                name: "RfidNr",
                table: "RfidPatrol",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateIndex(
                name: "IX_RfidPatrol_Location_RfidNr",
                table: "RfidPatrol",
                columns: new[] { "Location", "RfidNr" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RfidPatrol_Location_RfidNr",
                table: "RfidPatrol");

            migrationBuilder.AlterColumn<string>(
                name: "RfidNr",
                table: "RfidPatrol",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_RfidPatrol_RfidNr",
                table: "RfidPatrol",
                column: "RfidNr",
                unique: true);
        }
    }
}
