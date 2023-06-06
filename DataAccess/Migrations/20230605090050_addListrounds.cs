using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addListrounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfidPatrolRounds");
        }
    }
}
