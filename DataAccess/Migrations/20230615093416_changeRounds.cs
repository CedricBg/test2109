using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class changeRounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Sites_SiteId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_SiteId",
                table: "Rounds");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Rounds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
