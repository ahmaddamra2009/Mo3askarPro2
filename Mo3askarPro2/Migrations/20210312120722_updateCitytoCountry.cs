using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3askarPro2.Migrations
{
    public partial class updateCitytoCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Employees",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Employees",
                newName: "City");
        }
    }
}
