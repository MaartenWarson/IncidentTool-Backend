using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_DeviceType_CurrentDeviceTypeId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Incident_DeviceType_CurrentDeviceTypeId",
                table: "Incident");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurredIncident_User_CurrentUserId",
                table: "OccurredIncident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OccurredIncident",
                table: "OccurredIncident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incident",
                table: "Incident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceType",
                table: "DeviceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "OccurredIncident",
                newName: "OccurredIncidents");

            migrationBuilder.RenameTable(
                name: "Incident",
                newName: "Incidents");

            migrationBuilder.RenameTable(
                name: "DeviceType",
                newName: "DeviceTypes");

            migrationBuilder.RenameTable(
                name: "Device",
                newName: "Devices");

            migrationBuilder.RenameIndex(
                name: "IX_OccurredIncident_CurrentUserId",
                table: "OccurredIncidents",
                newName: "IX_OccurredIncidents_CurrentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Incident_CurrentDeviceTypeId",
                table: "Incidents",
                newName: "IX_Incidents_CurrentDeviceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Device_CurrentDeviceTypeId",
                table: "Devices",
                newName: "IX_Devices_CurrentDeviceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OccurredIncidents",
                table: "OccurredIncidents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incidents",
                table: "Incidents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceTypes",
                table: "DeviceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceTypes_CurrentDeviceTypeId",
                table: "Devices",
                column: "CurrentDeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_DeviceTypes_CurrentDeviceTypeId",
                table: "Incidents",
                column: "CurrentDeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurredIncidents_Users_CurrentUserId",
                table: "OccurredIncidents",
                column: "CurrentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceTypes_CurrentDeviceTypeId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_DeviceTypes_CurrentDeviceTypeId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurredIncidents_Users_CurrentUserId",
                table: "OccurredIncidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OccurredIncidents",
                table: "OccurredIncidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incidents",
                table: "Incidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceTypes",
                table: "DeviceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "OccurredIncidents",
                newName: "OccurredIncident");

            migrationBuilder.RenameTable(
                name: "Incidents",
                newName: "Incident");

            migrationBuilder.RenameTable(
                name: "DeviceTypes",
                newName: "DeviceType");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Device");

            migrationBuilder.RenameIndex(
                name: "IX_OccurredIncidents_CurrentUserId",
                table: "OccurredIncident",
                newName: "IX_OccurredIncident_CurrentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Incidents_CurrentDeviceTypeId",
                table: "Incident",
                newName: "IX_Incident_CurrentDeviceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_CurrentDeviceTypeId",
                table: "Device",
                newName: "IX_Device_CurrentDeviceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OccurredIncident",
                table: "OccurredIncident",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incident",
                table: "Incident",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceType",
                table: "DeviceType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_DeviceType_CurrentDeviceTypeId",
                table: "Device",
                column: "CurrentDeviceTypeId",
                principalTable: "DeviceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_DeviceType_CurrentDeviceTypeId",
                table: "Incident",
                column: "CurrentDeviceTypeId",
                principalTable: "DeviceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurredIncident_User_CurrentUserId",
                table: "OccurredIncident",
                column: "CurrentUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
