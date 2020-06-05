using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SellCar.Migrations
{
    public partial class AddVehiles : Migration
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
                    ContactEmail = table.Column<string>(maxLength: 255, nullable: true),
                    ContactPhone = table.Column<int>(maxLength: 255, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "VehileFeature",
                columns: table => new
                {
                    VehileId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehileFeature", x => new { x.VehileId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_VehileFeature_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehileFeature_Vehiles_VehileId",
                        column: x => x.VehileId,
                        principalTable: "Vehiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehileFeature_FeatureId",
                table: "VehileFeature",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiles_CarModelId",
                table: "Vehiles",
                column: "CarModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehileFeature");

            migrationBuilder.DropTable(
                name: "Vehiles");
        }
    }
}
