using Microsoft.EntityFrameworkCore.Migrations;

namespace HardShop_API.Migrations
{
    public partial class AddedIdForJoinedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CustomerPhones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CustomerCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CustomerAddresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AdminCards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CustomerPhones");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CustomerCards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdminCards");
        }
    }
}
