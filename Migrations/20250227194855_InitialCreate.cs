using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalExpensesApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    KeycloakId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseKinds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentKind",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentKind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Value = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    InstallmentsTotal = table.Column<int>(type: "integer", nullable: true),
                    InstallmentValue = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CurrentInstallment = table.Column<int>(type: "integer", nullable: true),
                    ExpenseKindId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExpenseKindId1 = table.Column<string>(type: "text", nullable: true),
                    PaymentKindId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentKindId1 = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId1 = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Accounts_AccountId1",
                        column: x => x.AccountId1,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseKinds_ExpenseKindId1",
                        column: x => x.ExpenseKindId1,
                        principalTable: "ExpenseKinds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_PaymentKind_PaymentKindId1",
                        column: x => x.PaymentKindId1,
                        principalTable: "PaymentKind",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_KeycloakId",
                table: "Accounts",
                column: "KeycloakId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AccountId1",
                table: "Expenses",
                column: "AccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseKindId1",
                table: "Expenses",
                column: "ExpenseKindId1");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaymentKindId1",
                table: "Expenses",
                column: "PaymentKindId1");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentKind_Code",
                table: "PaymentKind",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ExpenseKinds");

            migrationBuilder.DropTable(
                name: "PaymentKind");
        }
    }
}
