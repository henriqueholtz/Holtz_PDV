using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class AlterNameTableCidd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_ESTADO_EstadoEstCod",
                table: "Cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Cidades_CidadeCidCod",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidades",
                table: "Cidades");

            migrationBuilder.RenameTable(
                name: "Cidades",
                newName: "CIDADE");

            migrationBuilder.RenameIndex(
                name: "IX_Cidades_EstadoEstCod",
                table: "CIDADE",
                newName: "IX_CIDADE_EstadoEstCod");

            migrationBuilder.AlterColumn<int>(
                name: "CidadeCidCod",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "CIDADE",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CIDADE",
                table: "CIDADE",
                column: "CidCod");

            migrationBuilder.AddForeignKey(
                name: "FK_CIDADE_ESTADO_EstadoEstCod",
                table: "CIDADE",
                column: "EstadoEstCod",
                principalTable: "ESTADO",
                principalColumn: "EstCod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_CIDADE_CidadeCidCod",
                table: "Clientes",
                column: "CidadeCidCod",
                principalTable: "CIDADE",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CIDADE_ESTADO_EstadoEstCod",
                table: "CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_CIDADE_CidadeCidCod",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CIDADE",
                table: "CIDADE");

            migrationBuilder.RenameTable(
                name: "CIDADE",
                newName: "Cidades");

            migrationBuilder.RenameIndex(
                name: "IX_CIDADE_EstadoEstCod",
                table: "Cidades",
                newName: "IX_Cidades_EstadoEstCod");

            migrationBuilder.AlterColumn<int>(
                name: "CidadeCidCod",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "Cidades",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cidades",
                table: "Cidades",
                column: "CidCod");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_ESTADO_EstadoEstCod",
                table: "Cidades",
                column: "EstadoEstCod",
                principalTable: "ESTADO",
                principalColumn: "EstCod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Cidades_CidadeCidCod",
                table: "Clientes",
                column: "CidadeCidCod",
                principalTable: "Cidades",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
