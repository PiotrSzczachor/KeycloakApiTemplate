using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabaseStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationGuid",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolGuid",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Organization_Address_AddressGuid",
                        column: x => x.AddressGuid,
                        principalTable: "Address",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Organization_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_School_Address_AddressGuid",
                        column: x => x.AddressGuid,
                        principalTable: "Address",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AddressGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Qualifications = table.Column<string>(type: "text", nullable: true),
                    Closed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Event_Address_AddressGuid",
                        column: x => x.AddressGuid,
                        principalTable: "Address",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Event_Organization_OrganizationGuid",
                        column: x => x.OrganizationGuid,
                        principalTable: "Organization",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserEvent",
                columns: table => new
                {
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    EventGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvent", x => new { x.UserGuid, x.EventGuid });
                    table.ForeignKey(
                        name: "FK_UserEvent_Event_EventGuid",
                        column: x => x.EventGuid,
                        principalTable: "Event",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvent_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationGuid",
                table: "Users",
                column: "OrganizationGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolGuid",
                table: "Users",
                column: "SchoolGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Event_AddressGuid",
                table: "Event",
                column: "AddressGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizationGuid",
                table: "Event",
                column: "OrganizationGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_AddressGuid",
                table: "Organization",
                column: "AddressGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_UserGuid",
                table: "Organization",
                column: "UserGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_AddressGuid",
                table: "School",
                column: "AddressGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_EventGuid",
                table: "UserEvent",
                column: "EventGuid");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organization_OrganizationGuid",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_School_SchoolGuid",
                table: "Users");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "UserEvent");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrganizationGuid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SchoolGuid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrganizationGuid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SchoolGuid",
                table: "Users");
        }
    }
}
