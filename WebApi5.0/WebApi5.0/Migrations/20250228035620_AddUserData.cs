using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi5._0.Migrations
{
    public partial class AddUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "dbuseruserId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "dbuseruserId",
                table: "DetailOrder",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dbUsers",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    decentralization = table.Column<int>(type: "int", nullable: false),
                    userNameCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUsers", x => x.userId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_dbuseruserId",
                table: "Order",
                column: "dbuseruserId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrder_dbuseruserId",
                table: "DetailOrder",
                column: "dbuseruserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailOrder_User",
                table: "DetailOrder",
                column: "dbuseruserId",
                principalTable: "dbUsers",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User",
                table: "Order",
                column: "dbuseruserId",
                principalTable: "dbUsers",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailOrder_User",
                table: "DetailOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User",
                table: "Order");

            migrationBuilder.DropTable(
                name: "dbUsers");

            migrationBuilder.DropIndex(
                name: "IX_Order_dbuseruserId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_DetailOrder_dbuseruserId",
                table: "DetailOrder");

            migrationBuilder.DropColumn(
                name: "dbuseruserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "dbuseruserId",
                table: "DetailOrder");
        }
    }
}
