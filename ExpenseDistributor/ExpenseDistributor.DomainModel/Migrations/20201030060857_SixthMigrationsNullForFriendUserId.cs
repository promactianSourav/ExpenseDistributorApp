using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseDistributor.DomainModel.Migrations
{
    public partial class SixthMigrationsNullForFriendUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_FriendUserId",
                table: "Friends");

            migrationBuilder.AlterColumn<long>(
                name: "FriendUserId",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_FriendUserId",
                table: "Friends",
                column: "FriendUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_FriendUserId",
                table: "Friends");

            migrationBuilder.AlterColumn<long>(
                name: "FriendUserId",
                table: "Friends",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_FriendUserId",
                table: "Friends",
                column: "FriendUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
