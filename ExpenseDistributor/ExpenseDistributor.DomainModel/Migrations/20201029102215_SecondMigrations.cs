using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseDistributor.DomainModel.Migrations
{
    public partial class SecondMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Settlements",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "SettlementPerExpenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "SettlementPerExpenses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Expenses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(nullable: false),
                    CurrencyValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    FriendId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    FriendUserId = table.Column<long>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: false),
                    Date = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.FriendId);
                    table.ForeignKey(
                        name: "FK_Friend_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Friend_Users_FriendUserId",
                        column: x => x.FriendUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_CurrencyId",
                table: "Settlements",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPerExpenses_CurrencyId",
                table: "SettlementPerExpenses",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CurrencyId",
                table: "Expenses",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_CreatorUserId",
                table: "Friend",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_FriendUserId",
                table: "Friend",
                column: "FriendUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Currency_CurrencyId",
                table: "Expenses",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Currency_CurrencyId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_SettlementPerExpenses_Currency_CurrencyId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Currency_CurrencyId",
                table: "Settlements");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_CurrencyId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_SettlementPerExpenses_CurrencyId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CurrencyId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "SettlementPerExpenses");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SettlementPerExpenses");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Expenses");
        }
    }
}
