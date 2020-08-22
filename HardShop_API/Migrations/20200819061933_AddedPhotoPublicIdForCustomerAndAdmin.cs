using Microsoft.EntityFrameworkCore.Migrations;

namespace HardShop_API.Migrations
{
    public partial class AddedPhotoPublicIdForCustomerAndAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPublicId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPublicId",
                table: "Admins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPublicId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhotoPublicId",
                table: "Admins");
        }
    }
}
