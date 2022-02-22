using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusalaGatewayProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gateways",
                columns: table => new
                {
                    SerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gateways", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "PeripheralDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    GatewaySerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeripheralDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeripheralDevices_Gateways_GatewaySerialNumber",
                        column: x => x.GatewaySerialNumber,
                        principalTable: "Gateways",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeripheralDevices_GatewaySerialNumber",
                table: "PeripheralDevices",
                column: "GatewaySerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeripheralDevices");

            migrationBuilder.DropTable(
                name: "Gateways");
        }
    }
}
