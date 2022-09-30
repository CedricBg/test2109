using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartementEmployee_departements_DepartementsId",
                table: "DepartementEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_PassagesRounds_rfids_RfidNr",
                table: "PassagesRounds");

            migrationBuilder.DropForeignKey(
                name: "FK_rfids_Customers_CustomerId",
                table: "rfids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rfids",
                table: "rfids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departements",
                table: "departements");

            migrationBuilder.RenameTable(
                name: "rfids",
                newName: "Rfids");

            migrationBuilder.RenameTable(
                name: "departements",
                newName: "Departements");

            migrationBuilder.RenameIndex(
                name: "IX_rfids_CustomerId",
                table: "Rfids",
                newName: "IX_Rfids_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rfids",
                table: "Rfids",
                column: "RfidNr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departements",
                table: "Departements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartementEmployee_Departements_DepartementsId",
                table: "DepartementEmployee",
                column: "DepartementsId",
                principalTable: "Departements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassagesRounds_Rfids_RfidNr",
                table: "PassagesRounds",
                column: "RfidNr",
                principalTable: "Rfids",
                principalColumn: "RfidNr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rfids_Customers_CustomerId",
                table: "Rfids",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartementEmployee_Departements_DepartementsId",
                table: "DepartementEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_PassagesRounds_Rfids_RfidNr",
                table: "PassagesRounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rfids_Customers_CustomerId",
                table: "Rfids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rfids",
                table: "Rfids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departements",
                table: "Departements");

            migrationBuilder.RenameTable(
                name: "Rfids",
                newName: "rfids");

            migrationBuilder.RenameTable(
                name: "Departements",
                newName: "departements");

            migrationBuilder.RenameIndex(
                name: "IX_Rfids_CustomerId",
                table: "rfids",
                newName: "IX_rfids_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rfids",
                table: "rfids",
                column: "RfidNr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departements",
                table: "departements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartementEmployee_departements_DepartementsId",
                table: "DepartementEmployee",
                column: "DepartementsId",
                principalTable: "departements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassagesRounds_rfids_RfidNr",
                table: "PassagesRounds",
                column: "RfidNr",
                principalTable: "rfids",
                principalColumn: "RfidNr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rfids_Customers_CustomerId",
                table: "rfids",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
