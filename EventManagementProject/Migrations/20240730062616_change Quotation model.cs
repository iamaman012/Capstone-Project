using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementProject.Migrations
{
    public partial class changeQuotationmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuotationStatus",
                table: "PublicQuotationRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotationStatus",
                table: "PublicQuotationRequests");
        }
    }
}
