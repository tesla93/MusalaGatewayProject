using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusalaGatewayProject.Migrations
{
    public partial class FixedRelationshipBetweenModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeripheralDevices_Gateways_GatewaySerialNumber",
                table: "PeripheralDevices");

            migrationBuilder.DropIndex(
                name: "IX_PeripheralDevices_GatewaySerialNumber",
                table: "PeripheralDevices");

            migrationBuilder.DropColumn(
                name: "GatewaySerialNumber",
                table: "PeripheralDevices");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Gateways",
                newName: "IpAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "GatewayId",
                table: "PeripheralDevices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PeripheralDevices_GatewayId",
                table: "PeripheralDevices",
                column: "GatewayId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeripheralDevices_Gateways_GatewayId",
                table: "PeripheralDevices",
                column: "GatewayId",
                principalTable: "Gateways",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeripheralDevices_Gateways_GatewayId",
                table: "PeripheralDevices");

            migrationBuilder.DropIndex(
                name: "IX_PeripheralDevices_GatewayId",
                table: "PeripheralDevices");

            migrationBuilder.DropColumn(
                name: "GatewayId",
                table: "PeripheralDevices");

            migrationBuilder.RenameColumn(
                name: "IpAddress",
                table: "Gateways",
                newName: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "GatewaySerialNumber",
                table: "PeripheralDevices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeripheralDevices_GatewaySerialNumber",
                table: "PeripheralDevices",
                column: "GatewaySerialNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PeripheralDevices_Gateways_GatewaySerialNumber",
                table: "PeripheralDevices",
                column: "GatewaySerialNumber",
                principalTable: "Gateways",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
