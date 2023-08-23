using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class tablesv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customer_cust_id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Product_prod_id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfermCart_Customer_cust_id",
                table: "ConfermCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfermCart_Product_prod_id",
                table: "ConfermCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Seller_sell_id",
                table: "Product");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customer_cust_id",
                table: "Cart",
                column: "cust_id",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Product_prod_id",
                table: "Cart",
                column: "prod_id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfermCart_Customer_cust_id",
                table: "ConfermCart",
                column: "cust_id",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfermCart_Product_prod_id",
                table: "ConfermCart",
                column: "prod_id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Seller_sell_id",
                table: "Product",
                column: "sell_id",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customer_cust_id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Product_prod_id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfermCart_Customer_cust_id",
                table: "ConfermCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfermCart_Product_prod_id",
                table: "ConfermCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Seller_sell_id",
                table: "Product");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customer_cust_id",
                table: "Cart",
                column: "cust_id",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Product_prod_id",
                table: "Cart",
                column: "prod_id",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfermCart_Customer_cust_id",
                table: "ConfermCart",
                column: "cust_id",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfermCart_Product_prod_id",
                table: "ConfermCart",
                column: "prod_id",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Seller_sell_id",
                table: "Product",
                column: "sell_id",
                principalTable: "Seller",
                principalColumn: "Id");
        }
    }
}
