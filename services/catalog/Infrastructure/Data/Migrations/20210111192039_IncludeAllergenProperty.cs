using Microsoft.EntityFrameworkCore.Migrations;

namespace Backerei.Catalog.Infrastructure.Data.Migrations
{
    public partial class IncludeAllergenProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAllergen",
                table: "Ingredient",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAllergen",
                table: "Ingredient");
        }
    }
}
