using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class tablesv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Seller_sell_id",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_id = table.Column<int>(type: "int", nullable: false),
                    prod_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_cust_id",
                        column: x => x.cust_id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cart_Product_prod_id",
                        column: x => x.prod_id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConfermCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_id = table.Column<int>(type: "int", nullable: false),
                    prod_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfermCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfermCart_Customer_cust_id",
                        column: x => x.cust_id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConfermCart_Product_prod_id",
                        column: x => x.prod_id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_cust_id",
                table: "Cart",
                column: "cust_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_prod_id",
                table: "Cart",
                column: "prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_ConfermCart_cust_id",
                table: "ConfermCart",
                column: "cust_id");

            migrationBuilder.CreateIndex(
                name: "IX_ConfermCart_prod_id",
                table: "ConfermCart",
                column: "prod_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Seller_sell_id",
                table: "Product",
                column: "sell_id",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Seller_sell_id",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "ConfermCart");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Seller_sell_id",
                table: "Product",
                column: "sell_id",
                principalTable: "Seller",
                principalColumn: "Id");
        }
    }
}
