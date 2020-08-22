using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HardShop_API.Migrations
{
    public partial class EditedAdminJoinTablesandCustomerJoinTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "CustomerPhones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "CustomerCards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "CustomerAddresses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AdminCards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AdminAddresses",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAddresses", x => new { x.AdminId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_AdminAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminAddresses_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminPhones",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false),
                    PhoneId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminPhones", x => new { x.AdminId, x.PhoneId });
                    table.ForeignKey(
                        name: "FK_AdminPhones_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminPhones_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminAddresses_AddressId",
                table: "AdminAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminPhones_PhoneId",
                table: "AdminPhones",
                column: "PhoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminAddresses");

            migrationBuilder.DropTable(
                name: "AdminPhones");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "CustomerPhones");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "CustomerCards");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AdminCards");

            migrationBuilder.CreateTable(
                name: "AdminDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminDetails_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdminDetails_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdminDetails_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminDetails_AddressId",
                table: "AdminDetails",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminDetails_AdminId",
                table: "AdminDetails",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminDetails_PhoneId",
                table: "AdminDetails",
                column: "PhoneId");
        }
    }
}
