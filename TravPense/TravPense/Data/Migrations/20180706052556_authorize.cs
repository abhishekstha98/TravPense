using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TravPense.Data.Migrations
{
    public partial class authorize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelModel",
                table: "HotelModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitiesModel",
                table: "ActivitiesModel");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "locations");

            migrationBuilder.RenameTable(
                name: "HotelModel",
                newName: "hotelModels");

            migrationBuilder.RenameTable(
                name: "ActivitiesModel",
                newName: "activitiesModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locations",
                table: "locations",
                column: "locid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotelModels",
                table: "hotelModels",
                column: "Hotelid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_activitiesModels",
                table: "activitiesModels",
                column: "ActivityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_locations",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotelModels",
                table: "hotelModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_activitiesModels",
                table: "activitiesModels");

            migrationBuilder.RenameTable(
                name: "locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "hotelModels",
                newName: "HotelModel");

            migrationBuilder.RenameTable(
                name: "activitiesModels",
                newName: "ActivitiesModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "locid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelModel",
                table: "HotelModel",
                column: "Hotelid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitiesModel",
                table: "ActivitiesModel",
                column: "ActivityID");
        }
    }
}
