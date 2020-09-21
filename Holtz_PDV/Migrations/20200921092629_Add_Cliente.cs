using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class Add_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_CIDADE_CidadeCidCod",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "CLIENTE");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_CidadeCidCod",
                table: "CLIENTE",
                newName: "IX_CLIENTE_CidadeCidCod");

            migrationBuilder.AlterColumn<int>(
                name: "CliCod",
                table: "CLIENTE",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CLIENTE",
                table: "CLIENTE",
                column: "CliCod");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CIDADE_CidadeCidCod",
                table: "CLIENTE",
                column: "CidadeCidCod",
                principalTable: "CIDADE",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CidadeCidCod",
                table: "CLIENTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTE",
                table: "CLIENTE");

            migrationBuilder.RenameTable(
                name: "CLIENTE",
                newName: "Clientes");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTE_CidadeCidCod",
                table: "Clientes",
                newName: "IX_Clientes_CidadeCidCod");

            migrationBuilder.AlterColumn<int>(
                name: "CliCod",
                table: "Clientes",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "CliCod");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_CIDADE_CidadeCidCod",
                table: "Clientes",
                column: "CidadeCidCod",
                principalTable: "CIDADE",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
