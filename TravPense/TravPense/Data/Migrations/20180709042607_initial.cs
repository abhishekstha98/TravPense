using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TravPense.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricePerDay",
                table: "hotels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Standard",
                table: "hotels",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PricePerHour",
                table: "activities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "Standard",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "activities");

            migrationBuilder.DropColumn(
                name: "PricePerHour",
                table: "activities");
        }
    }
}
