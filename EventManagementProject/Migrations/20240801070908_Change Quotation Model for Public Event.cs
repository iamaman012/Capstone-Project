using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementProject.Migrations
{
    public partial class ChangeQuotationModelforPublicEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationDetails",
                table: "PublicQuotationRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationDetails",
                table: "PublicQuotationRequests");
        }
    }
}
