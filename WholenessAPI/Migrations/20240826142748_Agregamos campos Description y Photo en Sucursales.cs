using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholenessAPI.Migrations
{
    public partial class AgregamoscamposDescriptionyPhotoenSucursales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sucursales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Sucursales",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sucursales");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Sucursales");
        }
    }
}
