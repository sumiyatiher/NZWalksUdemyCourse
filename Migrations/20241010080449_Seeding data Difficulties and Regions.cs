﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalkz.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "DifficultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("c777a7cf-8028-456e-98d9-562cd8ed2bb7"), "Medium" },
                    { new Guid("e89b600a-4896-49ef-9dcd-9a091b27d28f"), "Easy" },
                    { new Guid("f0222f83-eb65-408c-b8a6-809d017b8c29"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "BOP", "Bay Of Plenty", null },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "NTL", "Northland", null },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", "Southland", null },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "DifficultyId",
                keyValue: new Guid("c777a7cf-8028-456e-98d9-562cd8ed2bb7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "DifficultyId",
                keyValue: new Guid("e89b600a-4896-49ef-9dcd-9a091b27d28f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "DifficultyId",
                keyValue: new Guid("f0222f83-eb65-408c-b8a6-809d017b8c29"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));
        }
    }
}