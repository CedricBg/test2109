using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class changecotnrolToRfidRound3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfidRound_RfidPatrol_PatrolId",
                table: "RfidRound");

            migrationBuilder.DropForeignKey(
                name: "FK_RfidRound_Rounds_RoundsId",
                table: "RfidRound");

            migrationBuilder.DropIndex(
                name: "IX_RfidRound_PatrolId",
                table: "RfidRound");

            migrationBuilder.DropColumn(
                name: "PatrolId",
                table: "RfidRound");

            migrationBuilder.AlterColumn<int>(
                name: "RoundsId",
                table: "RfidRound",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RfidPatrolId",
                table: "RfidRound",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RfidRound_RfidPatrolId",
                table: "RfidRound",
                column: "RfidPatrolId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RfidPatrolId",
                table: "RfidRound");

            migrationBuilder.AlterColumn<int>(
                name: "RoundsId",
                table: "RfidRound",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PatrolId",
                table: "RfidRound",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfidRound_PatrolId",
                table: "RfidRound",
                column: "PatrolId");

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
    }
}
