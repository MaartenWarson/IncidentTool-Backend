using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeviceTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Printer" },
                    { 2, "Koffiemachine" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "maarten", "pxl" },
                    { 2, "chelsea", "pxl" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CurrentDeviceTypeId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Lokaal B11", "HP Printer" },
                    { 2, 1, "Lokaal B19", "Canon Printer" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "CurrentDeviceTypeId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Papier is op" },
                    { 2, 1, "Inkt is op" },
                    { 3, 2, "Koffie is op" },
                    { 4, 2, "Koffie is niet warm" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
