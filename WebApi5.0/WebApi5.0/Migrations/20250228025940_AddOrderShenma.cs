using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi5._0.Migrations
{
    public partial class AddOrderShenma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    deliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    consignee = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    orStatus = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderId);
                });

            migrationBuilder.CreateTable(
                name: "DetailOrder",
                columns: table => new
                {
                    goodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderNumber = table.Column<int>(type: "int", nullable: false),
                    goodsPrice = table.Column<double>(type: "float", nullable: false),
                    goodsSaleOff = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOrder", x => new { x.goodsId, x.orderId });
                    table.ForeignKey(
                        name: "FK_DetailOrder_Goods",
                        column: x => x.goodsId,
                        principalTable: "dbGoods",
                        principalColumn: "goodsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOrder_Order",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrder_orderId",
                table: "DetailOrder",
                column: "orderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailOrder");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
