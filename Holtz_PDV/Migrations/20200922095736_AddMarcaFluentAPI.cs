using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class AddMarcaFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Marcas",
                table: "Marcas");

            migrationBuilder.RenameTable(
                name: "Marcas",
                newName: "MARCA");

            migrationBuilder.AlterColumn<int>(
                name: "MarCod",
                table: "MARCA",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MARCA",
                table: "MARCA",
                column: "MarCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MARCA",
                table: "MARCA");

            migrationBuilder.RenameTable(
                name: "MARCA",
                newName: "Marcas");

            migrationBuilder.AlterColumn<int>(
                name: "MarCod",
                table: "Marcas",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marcas",
                table: "Marcas",
                column: "MarCod");
        }
    }
}
