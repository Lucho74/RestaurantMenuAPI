using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenuAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHappyHourTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DiscountEnd",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DiscountStart",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HappyHourPrice",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasDiscount",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasHappyHour",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "HappyHours",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscountPercent = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HappyHours", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_HappyHours_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DiscountEnd", "DiscountPercent", "DiscountPrice", "DiscountStart", "HappyHourPrice", "HasDiscount", "HasHappyHour" },
                values: new object[] { null, null, null, null, null, false, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DiscountEnd", "DiscountPercent", "DiscountPrice", "DiscountStart", "HappyHourPrice", "HasDiscount", "HasHappyHour" },
                values: new object[] { null, null, null, null, null, false, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DiscountEnd", "DiscountPercent", "DiscountPrice", "DiscountStart", "HappyHourPrice", "HasDiscount", "HasHappyHour" },
                values: new object[] { null, null, null, null, null, false, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DiscountEnd", "DiscountPercent", "DiscountPrice", "DiscountStart", "HappyHourPrice", "HasDiscount", "HasHappyHour" },
                values: new object[] { null, null, null, null, null, false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HappyHours");

            migrationBuilder.DropColumn(
                name: "DiscountEnd",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountStart",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HappyHourPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasHappyHour",
                table: "Products");
        }
    }
}
