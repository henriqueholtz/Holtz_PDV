using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CidCod",
                table: "CLIENTE");

            migrationBuilder.AlterColumn<int>(
                name: "EstCod",
                table: "ESTADO",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "CLIENTE",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "EstCod",
                table: "CIDADE",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "CIDADE",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE",
                column: "EstCod",
                principalTable: "ESTADO",
                principalColumn: "EstCod",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CIDADE_CidCod",
                table: "CLIENTE",
                column: "CidCod",
                principalTable: "CIDADE",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CidCod",
                table: "CLIENTE");

            migrationBuilder.AlterColumn<int>(
                name: "EstCod",
                table: "ESTADO",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "CLIENTE",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstCod",
                table: "CIDADE",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "CIDADE",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE",
                column: "EstCod",
                principalTable: "ESTADO",
                principalColumn: "EstCod");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CIDADE_CidCod",
                table: "CLIENTE",
                column: "CidCod",
                principalTable: "CIDADE",
                principalColumn: "CidCod");
        }
    }
}
