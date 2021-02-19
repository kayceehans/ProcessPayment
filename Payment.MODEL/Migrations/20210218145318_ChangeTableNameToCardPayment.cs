using Microsoft.EntityFrameworkCore.Migrations;

namespace Payment.MODEL.Migrations
{
    public partial class ChangeTableNameToCardPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "CardPayment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardPayment",
                table: "CardPayment",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CardPayment",
                table: "CardPayment");

            migrationBuilder.RenameTable(
                name: "CardPayment",
                newName: "Payment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");
        }
    }
}
