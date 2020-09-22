using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class AddTableProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CIDADE_ESTADO_EstadoEstCod",
                table: "CIDADE");

            migrationBuilder.DropIndex(
                name: "IX_CIDADE_EstadoEstCod",
                table: "CIDADE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "EstadoEstCod",
                table: "CIDADE");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "EstCod",
                table: "CIDADE",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProCod",
                table: "Produto",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "ProCod");

            migrationBuilder.CreateIndex(
                name: "IX_CIDADE_EstCod",
                table: "CIDADE",
                column: "EstCod");

            migrationBuilder.AddForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE",
                column: "EstCod",
                principalTable: "ESTADO",
                principalColumn: "EstCod",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE");

            migrationBuilder.DropIndex(
                name: "IX_CIDADE_EstCod",
                table: "CIDADE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "EstCod",
                table: "CIDADE",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoEstCod",
                table: "CIDADE",
                type: "INT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProCod",
                table: "Produtos",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "ProCod");

            migrationBuilder.CreateIndex(
                name: "IX_CIDADE_EstadoEstCod",
                table: "CIDADE",
                column: "EstadoEstCod");

            migrationBuilder.AddForeignKey(
                name: "FK_CIDADE_ESTADO_EstadoEstCod",
                table: "CIDADE",
                column: "EstadoEstCod",
                principalTable: "ESTADO",
                principalColumn: "EstCod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
