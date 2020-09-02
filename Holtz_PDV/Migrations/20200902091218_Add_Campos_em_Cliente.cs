using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class Add_Campos_em_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliEnd",
                table: "Clientes");

            migrationBuilder.AlterColumn<sbyte>(
                name: "CliSts",
                table: "Clientes",
                type: "TINYINT",
                nullable: true,
                oldClrType: typeof(sbyte),
                oldType: "TINYINT");

            migrationBuilder.AddColumn<string>(
                name: "CliRua",
                table: "Clientes",
                type: "VARCHAR(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliRua",
                table: "Clientes");

            migrationBuilder.AlterColumn<sbyte>(
                name: "CliSts",
                table: "Clientes",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "TINYINT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CliEnd",
                table: "Clientes",
                type: "VARCHAR(150)",
                nullable: true);
        }
    }
}
