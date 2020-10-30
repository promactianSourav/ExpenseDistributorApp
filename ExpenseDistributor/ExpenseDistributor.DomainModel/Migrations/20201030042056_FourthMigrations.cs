using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseDistributor.DomainModel.Migrations
{
    public partial class FourthMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_CreatorUserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_DebtUserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_PayerUserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Users_DebtUserId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Users_PayerUserId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Users_DebtUserId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Users_PayerUserId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalExpensesPerRelationships_Users_DebtUserId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalExpensesPerRelationships_Users_PayerUserId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropIndex(
                name: "IX_TotalExpensesPerRelationships_DebtUserId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropIndex(
                name: "IX_TotalExpensesPerRelationships_PayerUserId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_DebtUserId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_PayerUserId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_SettlementPerExpenses_DebtUserId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropIndex(
                name: "IX_SettlementPerExpenses_PayerUserId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CreatorUserId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_DebtUserId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PayerUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DebtUserId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropColumn(
                name: "PayerUserId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropColumn(
                name: "DebtUserId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "PayerUserId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "DebtUserId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropColumn(
                name: "PayerUserId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "DebtUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PayerUserId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "TotalExpensesPerRelationships",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DebtFriendId",
                table: "TotalExpensesPerRelationships",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayerFriendId",
                table: "TotalExpensesPerRelationships",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DebtFriendId",
                table: "Settlements",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayerFriendId",
                table: "Settlements",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DebtFriendId",
                table: "SettlementPerExpenses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayerFriendId",
                table: "SettlementPerExpenses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatorFriendId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DebtFriendId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayerFriendId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TotalExpensesPerRelationships_CurrencyId",
                table: "TotalExpensesPerRelationships",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalExpensesPerRelationships_DebtFriendId",
                table: "TotalExpensesPerRelationships",
                column: "DebtFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalExpensesPerRelationships_PayerFriendId",
                table: "TotalExpensesPerRelationships",
                column: "PayerFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_DebtFriendId",
                table: "Settlements",
                column: "DebtFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_PayerFriendId",
                table: "Settlements",
                column: "PayerFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPerExpenses_DebtFriendId",
                table: "SettlementPerExpenses",
                column: "DebtFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPerExpenses_PayerFriendId",
                table: "SettlementPerExpenses",
                column: "PayerFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CreatorFriendId",
                table: "Expenses",
                column: "CreatorFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DebtFriendId",
                table: "Expenses",
                column: "DebtFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PayerFriendId",
                table: "Expenses",
                column: "PayerFriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Friends_CreatorFriendId",
                table: "Expenses",
                column: "CreatorFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Friends_DebtFriendId",
                table: "Expenses",
                column: "DebtFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Friends_PayerFriendId",
                table: "Expenses",
                column: "PayerFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Friends_DebtFriendId",
                table: "SettlementPerExpenses",
                column: "DebtFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Friends_PayerFriendId",
                table: "SettlementPerExpenses",
                column: "PayerFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Friends_DebtFriendId",
                table: "Settlements",
                column: "DebtFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Friends_PayerFriendId",
                table: "Settlements",
                column: "PayerFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalExpensesPerRelationships_Currencies_CurrencyId",
                table: "TotalExpensesPerRelationships",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_DebtFriendId",
                table: "TotalExpensesPerRelationships",
                column: "DebtFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_PayerFriendId",
                table: "TotalExpensesPerRelationships",
                column: "PayerFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Friends_CreatorFriendId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Friends_DebtFriendId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Friends_PayerFriendId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Friends_DebtFriendId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Friends_PayerFriendId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Friends_DebtFriendId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Friends_PayerFriendId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalExpensesPerRelationships_Currencies_CurrencyId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_DebtFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_PayerFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropIndex(
                name: "IX_TotalExpensesPerRelationships_CurrencyId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropIndex(
                name: "IX_TotalExpensesPerRelationships_DebtFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropIndex(
                name: "IX_TotalExpensesPerRelationships_PayerFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_DebtFriendId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_PayerFriendId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_SettlementPerExpenses_DebtFriendId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropIndex(
                name: "IX_SettlementPerExpenses_PayerFriendId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CreatorFriendId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_DebtFriendId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PayerFriendId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropColumn(
                name: "DebtFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropColumn(
                name: "PayerFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropColumn(
                name: "DebtFriendId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "PayerFriendId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "DebtFriendId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropColumn(
                name: "PayerFriendId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropColumn(
                name: "CreatorFriendId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "DebtFriendId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PayerFriendId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DebtUserId",
                table: "TotalExpensesPerRelationships",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayerUserId",
                table: "TotalExpensesPerRelationships",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DebtUserId",
                table: "Settlements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayerUserId",
                table: "Settlements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DebtUserId",
                table: "SettlementPerExpenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayerUserId",
                table: "SettlementPerExpenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DebtUserId",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayerUserId",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TotalExpensesPerRelationships_DebtUserId",
                table: "TotalExpensesPerRelationships",
                column: "DebtUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalExpensesPerRelationships_PayerUserId",
                table: "TotalExpensesPerRelationships",
                column: "PayerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_DebtUserId",
                table: "Settlements",
                column: "DebtUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_PayerUserId",
                table: "Settlements",
                column: "PayerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPerExpenses_DebtUserId",
                table: "SettlementPerExpenses",
                column: "DebtUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPerExpenses_PayerUserId",
                table: "SettlementPerExpenses",
                column: "PayerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CreatorUserId",
                table: "Expenses",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DebtUserId",
                table: "Expenses",
                column: "DebtUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PayerUserId",
                table: "Expenses",
                column: "PayerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_CreatorUserId",
                table: "Expenses",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_DebtUserId",
                table: "Expenses",
                column: "DebtUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_PayerUserId",
                table: "Expenses",
                column: "PayerUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Users_DebtUserId",
                table: "SettlementPerExpenses",
                column: "DebtUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Users_PayerUserId",
                table: "SettlementPerExpenses",
                column: "PayerUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Users_DebtUserId",
                table: "Settlements",
                column: "DebtUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Users_PayerUserId",
                table: "Settlements",
                column: "PayerUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalExpensesPerRelationships_Users_DebtUserId",
                table: "TotalExpensesPerRelationships",
                column: "DebtUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalExpensesPerRelationships_Users_PayerUserId",
                table: "TotalExpensesPerRelationships",
                column: "PayerUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
