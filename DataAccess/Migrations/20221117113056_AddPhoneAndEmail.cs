using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddPhoneAndEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetailedEmployeeId",
                table: "EmailAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DetailedEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_DetailedEmployees_DetailedEmployeeId",
                        column: x => x.DetailedEmployeeId,
                        principalTable: "DetailedEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_DetailedEmployeeId",
                table: "EmailAddresses",
                column: "DetailedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_DetailedEmployeeId",
                table: "Phones",
                column: "DetailedEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddresses_DetailedEmployees_DetailedEmployeeId",
                table: "EmailAddresses",
                column: "DetailedEmployeeId",
                principalTable: "DetailedEmployees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailAddresses_DetailedEmployees_DetailedEmployeeId",
                table: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_EmailAddresses_DetailedEmployeeId",
                table: "EmailAddresses");

            migrationBuilder.DropColumn(
                name: "DetailedEmployeeId",
                table: "EmailAddresses");
        }
    }
}
