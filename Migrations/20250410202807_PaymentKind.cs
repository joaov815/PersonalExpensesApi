using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalExpensesApi.Migrations
{
    /// <inheritdoc />
    public partial class PaymentKind : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentKind_Code",
                table: "PaymentKind");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PaymentKind");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PaymentKind",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentKind_Code",
                table: "PaymentKind",
                column: "Code",
                unique: true);
        }
    }
}
