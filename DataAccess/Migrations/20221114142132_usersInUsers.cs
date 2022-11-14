using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class usersInUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_User_UserIdId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailedEmployees_User_UserId",
                table: "DetailedEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserIdId",
                table: "Customers",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailedEmployees_Users_UserId",
                table: "DetailedEmployees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserIdId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailedEmployees_Users_UserId",
                table: "DetailedEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_User_UserIdId",
                table: "Customers",
                column: "UserIdId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailedEmployees_User_UserId",
                table: "DetailedEmployees",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
