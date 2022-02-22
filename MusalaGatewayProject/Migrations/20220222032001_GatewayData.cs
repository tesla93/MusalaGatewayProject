using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusalaGatewayProject.Migrations
{
    public partial class GatewayData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PeripheralDevices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PeripheralDevices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PeripheralDevices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Gateways",
                columns: new[] { "SerialNumber", "IpAddress", "Name" },
                values: new object[] { new Guid("d8835792-079d-4bf6-a92a-4c68d7ffcc3d"), "192.168.1.1", "Gateway-A" });

            migrationBuilder.InsertData(
                table: "Gateways",
                columns: new[] { "SerialNumber", "IpAddress", "Name" },
                values: new object[] { new Guid("028ab19b-ae63-4ec6-ba80-cb2719d3ebd9"), "192.168.2.1", "Gateway-B" });

            migrationBuilder.InsertData(
                table: "Gateways",
                columns: new[] { "SerialNumber", "IpAddress", "Name" },
                values: new object[] { new Guid("35bedc57-cbe4-4d8a-a266-99495a00af5b"), "192.168.3.1", "Gateway-C" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gateways",
                keyColumn: "SerialNumber",
                keyValue: new Guid("028ab19b-ae63-4ec6-ba80-cb2719d3ebd9"));

            migrationBuilder.DeleteData(
                table: "Gateways",
                keyColumn: "SerialNumber",
                keyValue: new Guid("35bedc57-cbe4-4d8a-a266-99495a00af5b"));

            migrationBuilder.DeleteData(
                table: "Gateways",
                keyColumn: "SerialNumber",
                keyValue: new Guid("d8835792-079d-4bf6-a92a-4c68d7ffcc3d"));

            migrationBuilder.InsertData(
                table: "PeripheralDevices",
                columns: new[] { "Id", "DateCreated", "GatewayId", "Status", "Vendor" },
                values: new object[] { 1, new DateTime(2022, 2, 21, 22, 17, 33, 651, DateTimeKind.Local).AddTicks(1895), new Guid("00000000-0000-0000-0000-000000000000"), true, "Nokia" });

            migrationBuilder.InsertData(
                table: "PeripheralDevices",
                columns: new[] { "Id", "DateCreated", "GatewayId", "Status", "Vendor" },
                values: new object[] { 2, new DateTime(2022, 2, 21, 22, 17, 33, 653, DateTimeKind.Local).AddTicks(3350), new Guid("00000000-0000-0000-0000-000000000000"), true, "Alcatel" });

            migrationBuilder.InsertData(
                table: "PeripheralDevices",
                columns: new[] { "Id", "DateCreated", "GatewayId", "Status", "Vendor" },
                values: new object[] { 3, new DateTime(2022, 2, 21, 22, 17, 33, 653, DateTimeKind.Local).AddTicks(3377), new Guid("00000000-0000-0000-0000-000000000000"), false, "Huawei" });
        }
    }
}
