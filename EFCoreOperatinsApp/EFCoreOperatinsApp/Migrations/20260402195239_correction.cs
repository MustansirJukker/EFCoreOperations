using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreOperatinsApp.Migrations
{
    /// <inheritdoc />
    public partial class correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_CurrencyTypes_CurrencyId",
                table: "BookPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyTypes",
                table: "CurrencyTypes");

            migrationBuilder.RenameTable(
                name: "CurrencyTypes",
                newName: "Currencies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_Currencies_CurrencyId",
                table: "BookPrices",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_Currencies_CurrencyId",
                table: "BookPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "CurrencyTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyTypes",
                table: "CurrencyTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_CurrencyTypes_CurrencyId",
                table: "BookPrices",
                column: "CurrencyId",
                principalTable: "CurrencyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
