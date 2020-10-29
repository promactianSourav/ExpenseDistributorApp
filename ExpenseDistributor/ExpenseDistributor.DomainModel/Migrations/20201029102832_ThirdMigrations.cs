using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseDistributor.DomainModel.Migrations
{
    public partial class ThirdMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Currency_CurrencyId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Users_CreatorUserId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Users_FriendUserId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Currency_CurrencyId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Currency_CurrencyId",
                table: "Settlements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friend",
                table: "Friend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                table: "Currency");

            migrationBuilder.RenameTable(
                name: "Friend",
                newName: "Friends");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currencies");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_FriendUserId",
                table: "Friends",
                newName: "IX_Friends_FriendUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_CreatorUserId",
                table: "Friends",
                newName: "IX_Friends_CreatorUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "FriendId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Currencies_CurrencyId",
                table: "Expenses",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_CreatorUserId",
                table: "Friends",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_FriendUserId",
                table: "Friends",
                column: "FriendUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Currencies_CurrencyId",
                table: "SettlementPerExpenses",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Currencies_CurrencyId",
                table: "Settlements",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Currencies_CurrencyId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_CreatorUserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_FriendUserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Currencies_CurrencyId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Currencies_CurrencyId",
                table: "Settlements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "Friend");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currency");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_FriendUserId",
                table: "Friend",
                newName: "IX_Friend_FriendUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_CreatorUserId",
                table: "Friend",
                newName: "IX_Friend_CreatorUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friend",
                table: "Friend",
                column: "FriendId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                table: "Currency",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Currency_CurrencyId",
                table: "Expenses",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Users_CreatorUserId",
                table: "Friend",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Users_FriendUserId",
                table: "Friend",
                column: "FriendUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Currency_CurrencyId",
                table: "SettlementPerExpenses",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Currency_CurrencyId",
                table: "Settlements",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
