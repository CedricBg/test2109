using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class delListrounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfidPatrolRounds");

            migrationBuilder.AlterColumn<string>(
                name: "RfidNr",
                table: "RfidPatrol",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RfidNr",
                table: "RfidPatrol",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateTable(
                name: "RfidPatrolRounds",
                columns: table => new
                {
                    PatrolId = table.Column<int>(type: "int", nullable: false),
                    RoundsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfidPatrolRounds", x => new { x.PatrolId, x.RoundsId });
                    table.ForeignKey(
                        name: "FK_RfidPatrolRounds_RfidPatrol_PatrolId",
                        column: x => x.PatrolId,
                        principalTable: "RfidPatrol",
                        principalColumn: "PatrolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RfidPatrolRounds_Rounds_RoundsId",
                        column: x => x.RoundsId,
                        principalTable: "Rounds",
                        principalColumn: "RoundsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfidPatrolRounds_RoundsId",
                table: "RfidPatrolRounds",
                column: "RoundsId");
        }
    }
}
