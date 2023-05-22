using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfidPatrol_Rounds_RoundsId",
                table: "RfidPatrol");

            migrationBuilder.DropIndex(
                name: "IX_RfidPatrol_RoundsId",
                table: "RfidPatrol");

            migrationBuilder.DropColumn(
                name: "RoundsId",
                table: "RfidPatrol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundsId",
                table: "RfidPatrol",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfidPatrol_RoundsId",
                table: "RfidPatrol",
                column: "RoundsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfidPatrol_Rounds_RoundsId",
                table: "RfidPatrol",
                column: "RoundsId",
                principalTable: "Rounds",
                principalColumn: "RoundsId");
        }
    }
}
