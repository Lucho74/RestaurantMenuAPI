using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMenuAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordHashToRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Restaurants",
                newName: "PasswordHash");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_Email",
                table: "Restaurants",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Restaurants_Email",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Restaurants",
                newName: "Password");
        }
    }
}
