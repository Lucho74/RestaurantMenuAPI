using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenuAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAtributesToRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HappyHourPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "DiscountPercent",
                table: "Products",
                newName: "DiscountPercentage");

            migrationBuilder.RenameColumn(
                name: "DiscountPercent",
                table: "HappyHours",
                newName: "DiscountPercentage");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ClosingTime",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "OpeningDays",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "OpeningTime",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsFeatured",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsFeatured",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsFeatured",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsFeatured",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningDays", "OpeningTime" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), "1,2,3,4,5,6", new TimeSpan(0, 8, 0, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingTime",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "OpeningDays",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "DiscountPercentage",
                table: "Products",
                newName: "DiscountPercent");

            migrationBuilder.RenameColumn(
                name: "DiscountPercentage",
                table: "HappyHours",
                newName: "DiscountPercent");

            migrationBuilder.AddColumn<decimal>(
                name: "HappyHourPrice",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "HappyHourPrice",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "HappyHourPrice",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "HappyHourPrice",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "HappyHourPrice",
                value: null);
        }
    }
}
