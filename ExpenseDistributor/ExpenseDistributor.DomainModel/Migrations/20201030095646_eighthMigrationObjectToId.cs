using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseDistributor.DomainModel.Migrations
{
    public partial class eighthMigrationObjectToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Currencies_CurrencyId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupedUsers_Users_GroupsUserUserId",
                table: "GroupedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_CreatorUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatorUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_GroupedUsers_GroupsUserUserId",
                table: "GroupedUsers");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupsUserUserId",
                table: "GroupedUsers");

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GroupsUserId",
                table: "GroupedUsers",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CurrencyId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatorId",
                table: "Groups",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupedUsers_GroupsUserId",
                table: "GroupedUsers",
                column: "GroupsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Currencies_CurrencyId",
                table: "Expenses",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupedUsers_Users_GroupsUserId",
                table: "GroupedUsers",
                column: "GroupsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_CreatorId",
                table: "Groups",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Currencies_CurrencyId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupedUsers_Users_GroupsUserId",
                table: "GroupedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_CreatorId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatorId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_GroupedUsers_GroupsUserId",
                table: "GroupedUsers");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupsUserId",
                table: "GroupedUsers");

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Groups",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GroupsUserUserId",
                table: "GroupedUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CurrencyId",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatorUserId",
                table: "Groups",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupedUsers_GroupsUserUserId",
                table: "GroupedUsers",
                column: "GroupsUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Currencies_CurrencyId",
                table: "Expenses",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupedUsers_Users_GroupsUserUserId",
                table: "GroupedUsers",
                column: "GroupsUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_CreatorUserId",
                table: "Groups",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
