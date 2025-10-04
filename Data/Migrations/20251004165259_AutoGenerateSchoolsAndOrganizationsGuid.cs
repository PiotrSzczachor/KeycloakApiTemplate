using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AutoGenerateSchoolsAndOrganizationsGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Address_AddressGuid",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Organization_OrganizationGuid",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Address_AddressGuid",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Users_UserGuid",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_School_Address_AddressGuid",
                table: "School");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Event_EventGuid",
                table: "UserEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Users_UserGuid",
                table: "UserEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organization_OrganizationGuid",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_School_SchoolGuid",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "UserEvent",
                newName: "UsersEvents");

            migrationBuilder.RenameTable(
                name: "School",
                newName: "Schools");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_UserEvent_EventGuid",
                table: "UsersEvents",
                newName: "IX_UsersEvents_EventGuid");

            migrationBuilder.RenameIndex(
                name: "IX_School_AddressGuid",
                table: "Schools",
                newName: "IX_Schools_AddressGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_UserGuid",
                table: "Organizations",
                newName: "IX_Organizations_UserGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_AddressGuid",
                table: "Organizations",
                newName: "IX_Organizations_AddressGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Event_OrganizationGuid",
                table: "Events",
                newName: "IX_Events_OrganizationGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Event_AddressGuid",
                table: "Events",
                newName: "IX_Events_AddressGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersEvents",
                table: "UsersEvents",
                columns: new[] { "UserGuid", "EventGuid" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Addresses_AddressGuid",
                table: "Events",
                column: "AddressGuid",
                principalTable: "Addresses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizations_OrganizationGuid",
                table: "Events",
                column: "OrganizationGuid",
                principalTable: "Organizations",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Addresses_AddressGuid",
                table: "Organizations",
                column: "AddressGuid",
                principalTable: "Addresses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_UserGuid",
                table: "Organizations",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Addresses_AddressGuid",
                table: "Schools",
                column: "AddressGuid",
                principalTable: "Addresses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationGuid",
                table: "Users",
                column: "OrganizationGuid",
                principalTable: "Organizations",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Schools_SchoolGuid",
                table: "Users",
                column: "SchoolGuid",
                principalTable: "Schools",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersEvents_Events_EventGuid",
                table: "UsersEvents",
                column: "EventGuid",
                principalTable: "Events",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersEvents_Users_UserGuid",
                table: "UsersEvents",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Addresses_AddressGuid",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizations_OrganizationGuid",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Addresses_AddressGuid",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_UserGuid",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Addresses_AddressGuid",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationGuid",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Schools_SchoolGuid",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersEvents_Events_EventGuid",
                table: "UsersEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersEvents_Users_UserGuid",
                table: "UsersEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersEvents",
                table: "UsersEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "UsersEvents",
                newName: "UserEvent");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "School");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_UsersEvents_EventGuid",
                table: "UserEvent",
                newName: "IX_UserEvent_EventGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Schools_AddressGuid",
                table: "School",
                newName: "IX_School_AddressGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_UserGuid",
                table: "Organization",
                newName: "IX_Organization_UserGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_AddressGuid",
                table: "Organization",
                newName: "IX_Organization_AddressGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Events_OrganizationGuid",
                table: "Event",
                newName: "IX_Event_OrganizationGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Events_AddressGuid",
                table: "Event",
                newName: "IX_Event_AddressGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent",
                columns: new[] { "UserGuid", "EventGuid" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_School",
                table: "School",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Address_AddressGuid",
                table: "Event",
                column: "AddressGuid",
                principalTable: "Address",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Organization_OrganizationGuid",
                table: "Event",
                column: "OrganizationGuid",
                principalTable: "Organization",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Address_AddressGuid",
                table: "Organization",
                column: "AddressGuid",
                principalTable: "Address",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Users_UserGuid",
                table: "Organization",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Address_AddressGuid",
                table: "School",
                column: "AddressGuid",
                principalTable: "Address",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Event_EventGuid",
                table: "UserEvent",
                column: "EventGuid",
                principalTable: "Event",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Users_UserGuid",
                table: "UserEvent",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organization_OrganizationGuid",
                table: "Users",
                column: "OrganizationGuid",
                principalTable: "Organization",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_School_SchoolGuid",
                table: "Users",
                column: "SchoolGuid",
                principalTable: "School",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
