using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OccurredIncidents",
                columns: new[] { "Id", "CurrentUserId", "DeviceName", "IncidentDescription", "Solved" },
                values: new object[] { 1, 1, "HP Printer", "Papier is op", false });

            migrationBuilder.InsertData(
                table: "OccurredIncidents",
                columns: new[] { "Id", "CurrentUserId", "DeviceName", "IncidentDescription", "Solved" },
                values: new object[] { 2, 2, "Pelican Koffiemachine", "Koffie is op", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OccurredIncidents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OccurredIncidents",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
