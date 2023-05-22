using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addRounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassagesRounds");

            migrationBuilder.DropTable(
                name: "ScheduledRounds");

            migrationBuilder.RenameColumn(
                name: "RondsId",
                table: "Rounds",
                newName: "RoundsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rounds",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "Rounds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_RoundsId",
                table: "Rounds",
                column: "RoundsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_SiteId",
                table: "Rounds",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Sites_SiteId",
                table: "Rounds",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Sites_SiteId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_RoundsId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_SiteId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Rounds");

            migrationBuilder.RenameColumn(
                name: "RoundsId",
                table: "Rounds",
                newName: "RondsId");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Rounds",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "PassagesRounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfidNr = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    RoundsRondsId = table.Column<int>(type: "int", nullable: true),
                    OrderPAssage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassagesRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassagesRounds_Rfids_RfidNr",
                        column: x => x.RfidNr,
                        principalTable: "Rfids",
                        principalColumn: "RfidNr");
                    table.ForeignKey(
                        name: "FK_PassagesRounds_Rounds_RoundsRondsId",
                        column: x => x.RoundsRondsId,
                        principalTable: "Rounds",
                        principalColumn: "RondsId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledRounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundsRondsId = table.Column<int>(type: "int", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledRounds_Rounds_RoundsRondsId",
                        column: x => x.RoundsRondsId,
                        principalTable: "Rounds",
                        principalColumn: "RondsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassagesRounds_RfidNr",
                table: "PassagesRounds",
                column: "RfidNr");

            migrationBuilder.CreateIndex(
                name: "IX_PassagesRounds_RoundsRondsId",
                table: "PassagesRounds",
                column: "RoundsRondsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledRounds_RoundsRondsId",
                table: "ScheduledRounds",
                column: "RoundsRondsId");
        }
    }
}
