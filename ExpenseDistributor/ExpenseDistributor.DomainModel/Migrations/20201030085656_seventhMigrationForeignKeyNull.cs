using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseDistributor.DomainModel.Migrations
{
    public partial class seventhMigrationForeignKeyNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Friends_CreatorFriendId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Friends_DebtFriendId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Groups_GroupId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Friends_PayerFriendId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_CreatorUserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Friends_DebtFriendId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Expenses_ExpenseId",
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
                name: "FK_Settlements_TotalExpensesPerRelationships_TotalExpensePerRelationshipId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_DebtFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_PayerFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.AlterColumn<long>(
                name: "PayerFriendId",
                table: "TotalExpensesPerRelationships",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DebtFriendId",
                table: "TotalExpensesPerRelationships",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TotalExpensePerRelationshipId",
                table: "Settlements",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PayerFriendId",
                table: "Settlements",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DebtFriendId",
                table: "Settlements",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PayerFriendId",
                table: "SettlementPerExpenses",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ExpenseId",
                table: "SettlementPerExpenses",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DebtFriendId",
                table: "SettlementPerExpenses",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatorUserId",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PayerFriendId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "GroupId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DebtFriendId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatorFriendId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Friends_CreatorFriendId",
                table: "Expenses",
                column: "CreatorFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Friends_DebtFriendId",
                table: "Expenses",
                column: "DebtFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Groups_GroupId",
                table: "Expenses",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Friends_PayerFriendId",
                table: "Expenses",
                column: "PayerFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_CreatorUserId",
                table: "Friends",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Friends_DebtFriendId",
                table: "SettlementPerExpenses",
                column: "DebtFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Expenses_ExpenseId",
                table: "SettlementPerExpenses",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "ExpenseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Friends_PayerFriendId",
                table: "SettlementPerExpenses",
                column: "PayerFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Friends_DebtFriendId",
                table: "Settlements",
                column: "DebtFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Friends_PayerFriendId",
                table: "Settlements",
                column: "PayerFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_TotalExpensesPerRelationships_TotalExpensePerRelationshipId",
                table: "Settlements",
                column: "TotalExpensePerRelationshipId",
                principalTable: "TotalExpensesPerRelationships",
                principalColumn: "TotalExpensesPerRelationshipId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_DebtFriendId",
                table: "TotalExpensesPerRelationships",
                column: "DebtFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_PayerFriendId",
                table: "TotalExpensesPerRelationships",
                column: "PayerFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_Expenses_Groups_GroupId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Friends_PayerFriendId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_CreatorUserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Friends_DebtFriendId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Expenses_ExpenseId",
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
                name: "FK_Settlements_TotalExpensesPerRelationships_TotalExpensePerRelationshipId",
                table: "Settlements");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_DebtFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalExpensesPerRelationships_Friends_PayerFriendId",
                table: "TotalExpensesPerRelationships");

            migrationBuilder.AlterColumn<long>(
                name: "PayerFriendId",
                table: "TotalExpensesPerRelationships",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DebtFriendId",
                table: "TotalExpensesPerRelationships",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TotalExpensePerRelationshipId",
                table: "Settlements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PayerFriendId",
                table: "Settlements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DebtFriendId",
                table: "Settlements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PayerFriendId",
                table: "SettlementPerExpenses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ExpenseId",
                table: "SettlementPerExpenses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DebtFriendId",
                table: "SettlementPerExpenses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatorUserId",
                table: "Friends",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PayerFriendId",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GroupId",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DebtFriendId",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatorFriendId",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

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
                name: "FK_Expenses_Groups_GroupId",
                table: "Expenses",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Friends_PayerFriendId",
                table: "Expenses",
                column: "PayerFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_CreatorUserId",
                table: "Friends",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Friends_DebtFriendId",
                table: "SettlementPerExpenses",
                column: "DebtFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettlementPerExpenses_Expenses_ExpenseId",
                table: "SettlementPerExpenses",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "ExpenseId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Settlements_TotalExpensesPerRelationships_TotalExpensePerRelationshipId",
                table: "Settlements",
                column: "TotalExpensePerRelationshipId",
                principalTable: "TotalExpensesPerRelationships",
                principalColumn: "TotalExpensesPerRelationshipId",
                onDelete: ReferentialAction.Cascade);

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
    }
}
