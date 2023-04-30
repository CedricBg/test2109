using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddWorking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Working",
                columns: table => new
                {
                    WorkingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomrId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Working", x => x.WorkingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_ContactId",
                table: "ContactPersons",
                column: "ContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Working_WorkingId",
                table: "Working",
                column: "WorkingId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Working");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_ContactPersons_ContactId",
                table: "ContactPersons");
        }
    }
}
