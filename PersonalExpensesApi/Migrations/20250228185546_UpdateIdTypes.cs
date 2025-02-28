using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalExpensesApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Accounts_AccountId1",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseKinds_ExpenseKindId1",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_PaymentKind_PaymentKindId1",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_AccountId1",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseKindId1",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PaymentKindId1",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseKindId1",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PaymentKindId1",
                table: "Expenses");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentKindId",
                table: "Expenses",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseKindId",
                table: "Expenses",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Expenses",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AccountId",
                table: "Expenses",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseKindId",
                table: "Expenses",
                column: "ExpenseKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaymentKindId",
                table: "Expenses",
                column: "PaymentKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Accounts_AccountId",
                table: "Expenses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseKinds_ExpenseKindId",
                table: "Expenses",
                column: "ExpenseKindId",
                principalTable: "ExpenseKinds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_PaymentKind_PaymentKindId",
                table: "Expenses",
                column: "PaymentKindId",
                principalTable: "PaymentKind",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Accounts_AccountId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseKinds_ExpenseKindId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_PaymentKind_PaymentKindId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_AccountId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseKindId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PaymentKindId",
                table: "Expenses");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentKindId",
                table: "Expenses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ExpenseKindId",
                table: "Expenses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Expenses",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "AccountId1",
                table: "Expenses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpenseKindId1",
                table: "Expenses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentKindId1",
                table: "Expenses",
                type: "text",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Accounts_AccountId1",
                table: "Expenses",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseKinds_ExpenseKindId1",
                table: "Expenses",
                column: "ExpenseKindId1",
                principalTable: "ExpenseKinds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_PaymentKind_PaymentKindId1",
                table: "Expenses",
                column: "PaymentKindId1",
                principalTable: "PaymentKind",
                principalColumn: "Id");
        }
    }
}
