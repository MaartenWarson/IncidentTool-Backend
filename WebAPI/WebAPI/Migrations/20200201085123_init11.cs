using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "OccurredIncidents");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "OccurredIncidents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OccurredIncidents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeviceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OccurredIncidents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeviceId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "OccurredIncidents");

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "OccurredIncidents",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OccurredIncidents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeviceName",
                value: "HP Printer");

            migrationBuilder.UpdateData(
                table: "OccurredIncidents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeviceName",
                value: "Pelican Koffiemachine");
        }
    }
}
