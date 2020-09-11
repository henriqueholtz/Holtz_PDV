using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class FluentApi_Estado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_EstadoEstCod",
                table: "Cidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estados",
                table: "Estados");

            migrationBuilder.RenameTable(
                name: "Estados",
                newName: "ESTADO");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoEstCod",
                table: "Cidades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstNom",
                table: "ESTADO",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstCod",
                table: "ESTADO",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESTADO",
                table: "ESTADO",
                column: "EstCod");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_ESTADO_EstadoEstCod",
                table: "Cidades",
                column: "EstadoEstCod",
                principalTable: "ESTADO",
                principalColumn: "EstCod",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_ESTADO_EstadoEstCod",
                table: "Cidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESTADO",
                table: "ESTADO");

            migrationBuilder.RenameTable(
                name: "ESTADO",
                newName: "Estados");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoEstCod",
                table: "Cidades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstNom",
                table: "Estados",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AlterColumn<int>(
                name: "EstCod",
                table: "Estados",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estados",
                table: "Estados",
                column: "EstCod");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_EstadoEstCod",
                table: "Cidades",
                column: "EstadoEstCod",
                principalTable: "Estados",
                principalColumn: "EstCod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
