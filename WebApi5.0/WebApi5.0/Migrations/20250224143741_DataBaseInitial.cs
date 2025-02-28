using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi5._0.Migrations
{
    public partial class DataBaseInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbGoods",
                columns: table => new
                {
                    goodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    goodsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    goodsDescribe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    goodsCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    goodsPrice = table.Column<double>(type: "float", nullable: false),
                    goodsSaleOff = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbGoods", x => x.goodsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbGoods");
        }
    }
}
