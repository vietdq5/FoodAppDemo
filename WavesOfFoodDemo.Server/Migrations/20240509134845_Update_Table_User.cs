using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WavesOfFoodDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "UserInfo",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFullName",
                table: "UserInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserPhone",
                table: "UserInfo",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "UserFullName",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "UserPhone",
                table: "UserInfo");
        }
    }
}
