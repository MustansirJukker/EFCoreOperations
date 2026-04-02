using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreOperatinsApp.Migrations
{
    /// <inheritdoc />
    public partial class addedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_CurrencyTypes_CurrencyTypeId",
                table: "BookPrices");

            migrationBuilder.DropIndex(
                name: "IX_BookPrices_CurrencyTypeId",
                table: "BookPrices");

            migrationBuilder.DropColumn(
                name: "CurrencyTypeId",
                table: "BookPrices");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "CurrencyTypes",
                newName: "Title");

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Indian Rupee", "INR" },
                    { 2, "United States Dollar", "USD" },
                    { 3, "Euro", "EUR" },
                    { 4, "British Pound Sterling", "GBP" },
                    { 5, "Japanese Yen", "JPY" },
                    { 6, "Australian Dollar", "AUD" },
                    { 7, "Canadian Dollar", "CAD" },
                    { 8, "Chinese Yuan", "CNY" },
                    { 9, "United Arab Emirates Dirham", "AED" },
                    { 10, "Saudi Riyal", "SAR" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Hindi Language", "Hindi" },
                    { 2, "English Language", "English" },
                    { 3, "French Language", "French" },
                    { 4, "Spanish Language", "Spanish" },
                    { 5, "German Language", "German" },
                    { 6, "Chinese (Mandarin)", "Chinese" },
                    { 7, "Arabic Language", "Arabic" },
                    { 8, "Portuguese Language", "Portuguese" },
                    { 9, "Russian Language", "Russian" },
                    { 10, "Japanese Language", "Japanese" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPrices_CurrencyId",
                table: "BookPrices",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_CurrencyTypes_CurrencyId",
                table: "BookPrices",
                column: "CurrencyId",
                principalTable: "CurrencyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_CurrencyTypes_CurrencyId",
                table: "BookPrices");

            migrationBuilder.DropIndex(
                name: "IX_BookPrices_CurrencyId",
                table: "BookPrices");

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CurrencyTypes",
                newName: "Currency");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyTypeId",
                table: "BookPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookPrices_CurrencyTypeId",
                table: "BookPrices",
                column: "CurrencyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_CurrencyTypes_CurrencyTypeId",
                table: "BookPrices",
                column: "CurrencyTypeId",
                principalTable: "CurrencyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
