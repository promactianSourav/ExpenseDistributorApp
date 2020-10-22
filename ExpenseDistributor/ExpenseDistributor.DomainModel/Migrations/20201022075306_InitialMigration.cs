using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseDistributor.DomainModel.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    GroupTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.GroupTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SplitTypes",
                columns: table => new
                {
                    SplitTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SplitTypeName = table.Column<string>(nullable: false),
                    Value = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SplitTypes", x => x.SplitTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: false),
                    GroupTypeId = table.Column<long>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_GroupTypes_GroupTypeId",
                        column: x => x.GroupTypeId,
                        principalTable: "GroupTypes",
                        principalColumn: "GroupTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TotalExpensesPerRelationships",
                columns: table => new
                {
                    TotalExpensesPerRelationshipId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayerUserId = table.Column<long>(nullable: false),
                    DebtUserId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalExpensesPerRelationships", x => x.TotalExpensesPerRelationshipId);
                    table.ForeignKey(
                        name: "FK_TotalExpensesPerRelationships_Users_DebtUserId",
                        column: x => x.DebtUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_TotalExpensesPerRelationships_Users_PayerUserId",
                        column: x => x.PayerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseName = table.Column<string>(nullable: false),
                    GroupId = table.Column<long>(nullable: false),
                    PayerUserId = table.Column<long>(nullable: false),
                    DebtUserId = table.Column<long>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: false),
                    SplitTypeId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_DebtUserId",
                        column: x => x.DebtUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Expenses_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_Expenses_Users_PayerUserId",
                        column: x => x.PayerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Expenses_SplitTypes_SplitTypeId",
                        column: x => x.SplitTypeId,
                        principalTable: "SplitTypes",
                        principalColumn: "SplitTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupedUsers",
                columns: table => new
                {
                    GroupedUserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(nullable: true),
                    GroupsUserUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupedUsers", x => x.GroupedUserId);
                    table.ForeignKey(
                        name: "FK_GroupedUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupedUsers_Users_GroupsUserUserId",
                        column: x => x.GroupsUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    SettlementId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalExpensePerRelationshipId = table.Column<long>(nullable: false),
                    PayerUserId = table.Column<long>(nullable: false),
                    DebtUserId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.SettlementId);
                    table.ForeignKey(
                        name: "FK_Settlements_Users_DebtUserId",
                        column: x => x.DebtUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Settlements_Users_PayerUserId",
                        column: x => x.PayerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Settlements_TotalExpensesPerRelationships_TotalExpensePerRelationshipId",
                        column: x => x.TotalExpensePerRelationshipId,
                        principalTable: "TotalExpensesPerRelationships",
                        principalColumn: "TotalExpensesPerRelationshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettlementPerExpenses",
                columns: table => new
                {
                    SettlementPerExpenseId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<long>(nullable: false),
                    PayerUserId = table.Column<long>(nullable: false),
                    DebtUserId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementPerExpenses", x => x.SettlementPerExpenseId);
                    table.ForeignKey(
                        name: "FK_SettlementPerExpenses_Users_DebtUserId",
                        column: x => x.DebtUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_SettlementPerExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettlementPerExpenses_Users_PayerUserId",
                        column: x => x.PayerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CreatorUserId",
                table: "Expenses",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DebtUserId",
                table: "Expenses",
                column: "DebtUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_GroupId",
                table: "Expenses",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PayerUserId",
                table: "Expenses",
                column: "PayerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_SplitTypeId",
                table: "Expenses",
                column: "SplitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupedUsers_GroupId",
                table: "GroupedUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupedUsers_GroupsUserUserId",
                table: "GroupedUsers",
                column: "GroupsUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatorUserId",
                table: "Groups",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupTypeId",
                table: "Groups",
                column: "GroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPerExpenses_DebtUserId",
                table: "SettlementPerExpenses",
                column: "DebtUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPerExpenses_ExpenseId",
                table: "SettlementPerExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPerExpenses_PayerUserId",
                table: "SettlementPerExpenses",
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
                name: "IX_Settlements_TotalExpensePerRelationshipId",
                table: "Settlements",
                column: "TotalExpensePerRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalExpensesPerRelationships_DebtUserId",
                table: "TotalExpensesPerRelationships",
                column: "DebtUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalExpensesPerRelationships_PayerUserId",
                table: "TotalExpensesPerRelationships",
                column: "PayerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupedUsers");

            migrationBuilder.DropTable(
                name: "SettlementPerExpenses");

            migrationBuilder.DropTable(
                name: "Settlements");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "TotalExpensesPerRelationships");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "SplitTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GroupTypes");
        }
    }
}
