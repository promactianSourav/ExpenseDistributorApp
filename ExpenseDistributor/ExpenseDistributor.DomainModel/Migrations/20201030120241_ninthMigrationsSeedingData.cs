using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseDistributor.DomainModel.Migrations
{
    public partial class ninthMigrationsSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CurrencyName", "CurrencyValue" },
                values: new object[,]
                {
                    { 1L, "Rupees", 1m },
                    { 2L, "Dollar", 75m }
                });

            migrationBuilder.InsertData(
                table: "GroupTypes",
                columns: new[] { "GroupTypeId", "GroupTypeName" },
                values: new object[,]
                {
                    { 1L, "Apartment" },
                    { 2L, "House" },
                    { 3L, "Trip" },
                    { 4L, "Other" }
                });

            migrationBuilder.InsertData(
                table: "SplitTypes",
                columns: new[] { "SplitTypeId", "SplitTypeName", "Value" },
                values: new object[,]
                {
                    { 1L, "Split by Amount", 0L },
                    { 2L, "Split equally", 0L },
                    { 3L, "Split by %", 0L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencyId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencyId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "GroupTypes",
                keyColumn: "GroupTypeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "GroupTypes",
                keyColumn: "GroupTypeId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "GroupTypes",
                keyColumn: "GroupTypeId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "GroupTypes",
                keyColumn: "GroupTypeId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "SplitTypes",
                keyColumn: "SplitTypeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SplitTypes",
                keyColumn: "SplitTypeId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SplitTypes",
                keyColumn: "SplitTypeId",
                keyValue: 3L);
        }
    }
}
