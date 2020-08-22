using Microsoft.EntityFrameworkCore.Migrations;

namespace HardShop_API.Migrations
{
    public partial class AddedAdminAdminDetailRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Admins",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "AdminDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminDetails_AdminId",
                table: "AdminDetails",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminDetails_Admins_AdminId",
                table: "AdminDetails",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminDetails_Admins_AdminId",
                table: "AdminDetails");

            migrationBuilder.DropIndex(
                name: "IX_AdminDetails_AdminId",
                table: "AdminDetails");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AdminDetails");
        }
    }
}
