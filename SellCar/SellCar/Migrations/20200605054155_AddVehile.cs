using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SellCar.Migrations
{
    public partial class AddVehile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(nullable: false),
                    CarModelId = table.Column<int>(nullable: true),
                    ContactName = table.Column<string>(maxLength: 255, nullable: false),
                    ConatactPhone = table.Column<int>(maxLength: 255, nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiles_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiles_CarModelId",
                table: "Vehiles",
                column: "CarModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiles");
        }
    }
}
