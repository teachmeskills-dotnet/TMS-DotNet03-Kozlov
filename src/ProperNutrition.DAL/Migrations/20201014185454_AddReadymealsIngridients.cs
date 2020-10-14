using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProperNutrition.DAL.Migrations
{
    public partial class AddReadymealsIngridients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReadyMeal",
                schema: "food",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMeal = table.Column<string>(maxLength: 100, nullable: false),
                    VegMeat = table.Column<bool>(nullable: false),
                    ChildReacrion = table.Column<string>(maxLength: 200, nullable: false),
                    TeastyMeal = table.Column<string>(maxLength: 100, nullable: false),
                    Comments = table.Column<string>(maxLength: 100, nullable: true),
                    ReadyTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadyMeal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReadyMealIngridients",
                schema: "food",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<decimal>(nullable: false),
                    ReadyMealId = table.Column<int>(nullable: false),
                    IngridientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadyMealIngridients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadyMealIngridients_Ingridient_IngridientId",
                        column: x => x.IngridientId,
                        principalSchema: "food",
                        principalTable: "Ingridient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReadyMealIngridients_ReadyMeal_ReadyMealId",
                        column: x => x.ReadyMealId,
                        principalSchema: "food",
                        principalTable: "ReadyMeal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadyMealIngridients_IngridientId",
                schema: "food",
                table: "ReadyMealIngridients",
                column: "IngridientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadyMealIngridients_ReadyMealId",
                schema: "food",
                table: "ReadyMealIngridients",
                column: "ReadyMealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadyMealIngridients",
                schema: "food");

            migrationBuilder.DropTable(
                name: "ReadyMeal",
                schema: "food");
        }
    }
}
