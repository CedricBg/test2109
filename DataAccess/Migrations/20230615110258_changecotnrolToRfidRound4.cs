using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class changecotnrolToRfidRound4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfidRound_RfidPatrol_RfidPatrolId",
                table: "RfidRound");

            migrationBuilder.DropForeignKey(
                name: "FK_RfidRound_Rounds_RoundsId",
                table: "RfidRound");

            migrationBuilder.DropIndex(
                name: "IX_RfidRound_RfidPatrolId",
                table: "RfidRound");

            migrationBuilder.DropIndex(
                name: "IX_RfidRound_RoundsId",
                table: "RfidRound");

            migrationBuilder.RenameColumn(
                name: "RoundsId",
                table: "RfidRound",
                newName: "RoundId");

            migrationBuilder.RenameColumn(
                name: "RfidPatrolId",
                table: "RfidRound",
                newName: "RfidId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoundId",
                table: "RfidRound",
                newName: "RoundsId");

            migrationBuilder.RenameColumn(
                name: "RfidId",
                table: "RfidRound",
                newName: "RfidPatrolId");

            migrationBuilder.CreateIndex(
                name: "IX_RfidRound_RfidPatrolId",
                table: "RfidRound",
                column: "RfidPatrolId");

            migrationBuilder.CreateIndex(
                name: "IX_RfidRound_RoundsId",
                table: "RfidRound",
                column: "RoundsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfidRound_RfidPatrol_RfidPatrolId",
                table: "RfidRound",
                column: "RfidPatrolId",
                principalTable: "RfidPatrol",
                principalColumn: "PatrolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RfidRound_Rounds_RoundsId",
                table: "RfidRound",
                column: "RoundsId",
                principalTable: "Rounds",
                principalColumn: "RoundsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
