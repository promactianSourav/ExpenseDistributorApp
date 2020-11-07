using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseDistributor.DomainModel.Migrations
{
    public partial class tenthMigrationsGroupedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupedUsers_Users_GroupsUserId",
                table: "GroupedUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupedUsers_GroupsUserId",
                table: "GroupedUsers");

            migrationBuilder.DropColumn(
                name: "GroupsUserId",
                table: "GroupedUsers");

            migrationBuilder.AddColumn<long>(
                name: "GroupsFriendId",
                table: "GroupedUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupedUsers_GroupsFriendId",
                table: "GroupedUsers",
                column: "GroupsFriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupedUsers_Friends_GroupsFriendId",
                table: "GroupedUsers",
                column: "GroupsFriendId",
                principalTable: "Friends",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupedUsers_Friends_GroupsFriendId",
                table: "GroupedUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupedUsers_GroupsFriendId",
                table: "GroupedUsers");

            migrationBuilder.DropColumn(
                name: "GroupsFriendId",
                table: "GroupedUsers");

            migrationBuilder.AddColumn<long>(
                name: "GroupsUserId",
                table: "GroupedUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupedUsers_GroupsUserId",
                table: "GroupedUsers",
                column: "GroupsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupedUsers_Users_GroupsUserId",
                table: "GroupedUsers",
                column: "GroupsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
