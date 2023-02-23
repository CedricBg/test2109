using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddAddressToDetailedEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "DetailedEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailedEmployees_AddressId",
                table: "DetailedEmployees",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailedEmployees_Address_AddressId",
                table: "DetailedEmployees",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailedEmployees_Address_AddressId",
                table: "DetailedEmployees");

            migrationBuilder.DropIndex(
                name: "IX_DetailedEmployees_AddressId",
                table: "DetailedEmployees");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "DetailedEmployees");
        }
    }
}
