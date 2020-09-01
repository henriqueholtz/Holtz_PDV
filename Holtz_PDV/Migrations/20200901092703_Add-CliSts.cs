using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class AddCliSts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<sbyte>(
                name: "CliSts",
                table: "Clientes",
                type: "TINYINT",
                nullable: false,
                defaultValue: (sbyte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliSts",
                table: "Clientes");
        }
    }
}
