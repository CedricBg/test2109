using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class changecotnrolToRfidRound2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Control_RfidPatrol_PatrolId",
                table: "Control");

            migrationBuilder.DropForeignKey(
                name: "FK_Control_Rounds_RoundsId",
                table: "Control");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Control",
                table: "Control");

            migrationBuilder.RenameTable(
                name: "Control",
                newName: "RfidRound");

            migrationBuilder.RenameIndex(
                name: "IX_Control_RoundsId",
                table: "RfidRound",
                newName: "IX_RfidRound_RoundsId");

            migrationBuilder.RenameIndex(
                name: "IX_Control_RfidRoundId",
                table: "RfidRound",
                newName: "IX_RfidRound_RfidRoundId");

            migrationBuilder.RenameIndex(
                name: "IX_Control_PatrolId",
                table: "RfidRound",
                newName: "IX_RfidRound_PatrolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfidRound",
                table: "RfidRound",
                column: "RfidRoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfidRound_RfidPatrol_PatrolId",
                table: "RfidRound",
                column: "PatrolId",
                principalTable: "RfidPatrol",
                principalColumn: "PatrolId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfidRound_Rounds_RoundsId",
                table: "RfidRound",
                column: "RoundsId",
                principalTable: "Rounds",
                principalColumn: "RoundsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfidRound_RfidPatrol_PatrolId",
                table: "RfidRound");

            migrationBuilder.DropForeignKey(
                name: "FK_RfidRound_Rounds_RoundsId",
                table: "RfidRound");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfidRound",
                table: "RfidRound");

            migrationBuilder.RenameTable(
                name: "RfidRound",
                newName: "Control");

            migrationBuilder.RenameIndex(
                name: "IX_RfidRound_RoundsId",
                table: "Control",
                newName: "IX_Control_RoundsId");

            migrationBuilder.RenameIndex(
                name: "IX_RfidRound_RfidRoundId",
                table: "Control",
                newName: "IX_Control_RfidRoundId");

            migrationBuilder.RenameIndex(
                name: "IX_RfidRound_PatrolId",
                table: "Control",
                newName: "IX_Control_PatrolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Control",
                table: "Control",
                column: "RfidRoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Control_RfidPatrol_PatrolId",
                table: "Control",
                column: "PatrolId",
                principalTable: "RfidPatrol",
                principalColumn: "PatrolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Control_Rounds_RoundsId",
                table: "Control",
                column: "RoundsId",
                principalTable: "Rounds",
                principalColumn: "RoundsId");
        }
    }
}
