using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi5._0.Migrations
{
    public partial class AddTableCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "dbGoods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoriesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbGoods_CategoriesId",
                table: "dbGoods",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbGoods_Category_CategoriesId",
                table: "dbGoods",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbGoods_Category_CategoriesId",
                table: "dbGoods");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_dbGoods_CategoriesId",
                table: "dbGoods");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "dbGoods");
        }
    }
}
