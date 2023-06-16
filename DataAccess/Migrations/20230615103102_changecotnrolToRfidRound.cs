using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class changecotnrolToRfidRound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ControlId",
                table: "Control",
                newName: "RfidRoundId");

            migrationBuilder.RenameIndex(
                name: "IX_Control_ControlId",
                table: "Control",
                newName: "IX_Control_RfidRoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RfidRoundId",
                table: "Control",
                newName: "ControlId");

            migrationBuilder.RenameIndex(
                name: "IX_Control_RfidRoundId",
                table: "Control",
                newName: "IX_Control_ControlId");
        }
    }
}
