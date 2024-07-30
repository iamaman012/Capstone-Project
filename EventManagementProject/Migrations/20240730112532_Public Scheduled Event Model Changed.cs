using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementProject.Migrations
{
    public partial class PublicScheduledEventModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "Host",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "Timing",
                table: "ScheduledPublicEvents");

            migrationBuilder.DropColumn(
                name: "TotalSeats",
                table: "ScheduledPublicEvents");

            migrationBuilder.RenameColumn(
                name: "Venue",
                table: "ScheduledPublicEvents",
                newName: "UserEventName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEventName",
                table: "ScheduledPublicEvents",
                newName: "Venue");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ScheduledPublicEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ScheduledPublicEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ScheduledPublicEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ScheduledPublicEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ScheduledPublicEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "ScheduledPublicEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Host",
                table: "ScheduledPublicEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "ScheduledPublicEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "ScheduledPublicEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "TicketPrice",
                table: "ScheduledPublicEvents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Timing",
                table: "ScheduledPublicEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalSeats",
                table: "ScheduledPublicEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
