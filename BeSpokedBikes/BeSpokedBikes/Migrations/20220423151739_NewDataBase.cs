using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeSpokedBikes.Migrations
{
    public partial class NewDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discount_Products_productID",
                table: "Discount");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customer_CustomerID",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerID",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Discount_productID",
                table: "Discount");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "productID",
                table: "Discount");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "Discount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "Discount");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "productID",
                table: "Discount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerID",
                table: "Sales",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_productID",
                table: "Discount",
                column: "productID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discount_Products_productID",
                table: "Discount",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customer_CustomerID",
                table: "Sales",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID");
        }
    }
}
