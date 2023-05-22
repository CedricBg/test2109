using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addControl3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Control_RfidPatrol_PatrolRfidNr",
                table: "Control");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfidPatrol",
                table: "RfidPatrol");

            migrationBuilder.DropIndex(
                name: "IX_RfidPatrol_RfidNr",
                table: "RfidPatrol");

            migrationBuilder.DropIndex(
                name: "IX_Control_PatrolRfidNr",
                table: "Control");

            migrationBuilder.DropColumn(
                name: "PatrolRfidNr",
                table: "Control");

            migrationBuilder.AddColumn<int>(
                name: "PatrolId",
                table: "RfidPatrol",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PatrolId",
                table: "Control",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfidPatrol",
                table: "RfidPatrol",
                column: "PatrolId");

            migrationBuilder.CreateIndex(
                name: "IX_RfidPatrol_PatrolId",
                table: "RfidPatrol",
                column: "PatrolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Control_PatrolId",
                table: "Control",
                column: "PatrolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Control_RfidPatrol_PatrolId",
                table: "Control",
                column: "PatrolId",
                principalTable: "RfidPatrol",
                principalColumn: "PatrolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Control_RfidPatrol_PatrolId",
                table: "Control");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfidPatrol",
                table: "RfidPatrol");

            migrationBuilder.DropIndex(
                name: "IX_RfidPatrol_PatrolId",
                table: "RfidPatrol");

            migrationBuilder.DropIndex(
                name: "IX_Control_PatrolId",
                table: "Control");

            migrationBuilder.DropColumn(
                name: "PatrolId",
                table: "RfidPatrol");

            migrationBuilder.DropColumn(
                name: "PatrolId",
                table: "Control");

            migrationBuilder.AddColumn<string>(
                name: "PatrolRfidNr",
                table: "Control",
                type: "nvarchar(80)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfidPatrol",
                table: "RfidPatrol",
                column: "RfidNr");

            migrationBuilder.CreateIndex(
                name: "IX_RfidPatrol_RfidNr",
                table: "RfidPatrol",
                column: "RfidNr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Control_PatrolRfidNr",
                table: "Control",
                column: "PatrolRfidNr");

            migrationBuilder.AddForeignKey(
                name: "FK_Control_RfidPatrol_PatrolRfidNr",
                table: "Control",
                column: "PatrolRfidNr",
                principalTable: "RfidPatrol",
                principalColumn: "RfidNr");
        }
    }
}
