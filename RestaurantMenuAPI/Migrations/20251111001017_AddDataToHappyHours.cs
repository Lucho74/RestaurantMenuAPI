using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenuAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToHappyHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HappyHours",
                columns: new[] { "RestaurantId", "DiscountPercentage", "EndTime", "IsActive", "StartTime" },
                values: new object[] { 1, 50, new TimeSpan(0, 20, 0, 0, 0), true, new TimeSpan(0, 18, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "a@mail.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HappyHours",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "a@gmail.com");
        }
    }
}
