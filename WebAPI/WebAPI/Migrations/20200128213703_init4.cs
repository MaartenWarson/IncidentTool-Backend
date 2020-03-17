using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CurrentDeviceTypeId", "Location", "Name" },
                values: new object[] { 3, 2, "Leraarslokaal", "Pelican Koffiemachine" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CurrentDeviceTypeId", "Location", "Name" },
                values: new object[] { 4, 2, "Coördinatorenlokaal", "Nespresso Koffiemachine" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
