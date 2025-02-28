using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi5._0.Migrations
{
    public partial class EditUsertoOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailOrder_User",
                table: "DetailOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User",
                table: "Order");

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
                name: "dbuseruserId",
                table: "DetailOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "DetailOrder",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User",
                table: "Order",
                column: "userId",
                principalTable: "dbUsers",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_userId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "DetailOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "dbuseruserId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "dbuseruserId",
                table: "DetailOrder",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
