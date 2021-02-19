using Microsoft.EntityFrameworkCore.Migrations;

namespace Payment.MODEL.Migrations
{
    public partial class AddPaymentState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentModels",
                table: "PaymentModels");

            migrationBuilder.RenameTable(
                name: "PaymentModels",
                newName: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "PaymentState",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentState",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "PaymentModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentModels",
                table: "PaymentModels",
                column: "Id");
        }
    }
}
