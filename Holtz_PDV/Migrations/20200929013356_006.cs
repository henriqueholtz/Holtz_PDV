using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class _006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CidCod",
                table: "CLIENTE");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CidCod",
                table: "CLIENTE");

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
    }
}
