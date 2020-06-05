using Microsoft.EntityFrameworkCore.Migrations;

namespace SellCar.Migrations
{
    public partial class ChangeColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConatactPhone",
                table: "Vehiles");

            migrationBuilder.AddColumn<int>(
                name: "ContactPhone",
                table: "Vehiles",
                maxLength: 255,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Vehiles");

            migrationBuilder.AddColumn<int>(
                name: "ConatactPhone",
                table: "Vehiles",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0);
        }
    }
}
