using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updateMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Sites_SiteId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_SiteId",
                table: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Message",
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
                table: "Message",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SiteId",
                table: "Message",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Sites_SiteId",
                table: "Message",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "SiteId");
        }
    }
}
