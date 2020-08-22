using Microsoft.EntityFrameworkCore.Migrations;

namespace HardShop_API.Migrations
{
    public partial class AddedProductOptionsCollectionForProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductOptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_ProductId",
                table: "ProductOptions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOptions_Products_ProductId",
                table: "ProductOptions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOptions_Products_ProductId",
                table: "ProductOptions");

            migrationBuilder.DropIndex(
                name: "IX_ProductOptions_ProductId",
                table: "ProductOptions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductOptions");
        }
    }
}
