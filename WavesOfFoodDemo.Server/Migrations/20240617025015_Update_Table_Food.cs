using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WavesOfFoodDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table_Food : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoodQuantity",
                table: "FoodInfo",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodQuantity",
                table: "FoodInfo");
        }
    }
}
