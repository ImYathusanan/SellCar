using Microsoft.EntityFrameworkCore.Migrations;

namespace SellCar.Migrations
{
    public partial class AddISRegisteredToVehile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Vehiles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Vehiles");
        }
    }
}
