using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addControl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Control",
                columns: table => new
                {
                    ControlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundsId = table.Column<int>(type: "int", nullable: true),
                    PatrolRfidNr = table.Column<string>(type: "nvarchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Control", x => x.ControlId);
                    table.ForeignKey(
                        name: "FK_Control_RfidPatrol_PatrolRfidNr",
                        column: x => x.PatrolRfidNr,
                        principalTable: "RfidPatrol",
                        principalColumn: "RfidNr");
                    table.ForeignKey(
                        name: "FK_Control_Rounds_RoundsId",
                        column: x => x.RoundsId,
                        principalTable: "Rounds",
                        principalColumn: "RoundsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfidPatrol_RfidNr",
                table: "RfidPatrol",
                column: "RfidNr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Control_ControlId",
                table: "Control",
                column: "ControlId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Control_PatrolRfidNr",
                table: "Control",
                column: "PatrolRfidNr");

            migrationBuilder.CreateIndex(
                name: "IX_Control_RoundsId",
                table: "Control",
                column: "RoundsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Control");

            migrationBuilder.DropIndex(
                name: "IX_RfidPatrol_RfidNr",
                table: "RfidPatrol");
        }
    }
}
