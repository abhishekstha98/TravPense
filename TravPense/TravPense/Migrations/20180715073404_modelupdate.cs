using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TravPense.Migrations
{
    public partial class modelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationName",
                table: "location");

            migrationBuilder.DropColumn(
                name: "DestinationName",
                table: "hotel");

            migrationBuilder.DropColumn(
                name: "LocationType",
                table: "activityy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationName",
                table: "location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinationName",
                table: "hotel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationType",
                table: "activityy",
                nullable: true);
        }
    }
}
