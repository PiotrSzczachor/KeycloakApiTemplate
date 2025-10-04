using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizationGuid",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizationGuid",
                table: "Events",
                column: "OrganizationGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizationGuid",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizationGuid",
                table: "Events",
                column: "OrganizationGuid",
                unique: true);
        }
    }
}
