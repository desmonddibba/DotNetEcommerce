﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Webshop.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCouponTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CouponCode", "CreatedAt", "DiscountAmount", "LastUpdated", "MinAMount" },
                values: new object[,]
                {
                    { 1, "10OFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 2, "20OFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40 },
                    { 3, "50OFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
