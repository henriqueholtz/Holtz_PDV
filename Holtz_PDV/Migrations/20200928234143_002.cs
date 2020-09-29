using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CIDADE_ESTADO_EstadoEstCod",
                table: "CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CliCidCod",
                table: "CLIENTE");

            migrationBuilder.RenameColumn(
                name: "CliCidCod",
                table: "CLIENTE",
                newName: "CidCod");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTE_CliCidCod",
                table: "CLIENTE",
                newName: "IX_CLIENTE_CidCod");

            migrationBuilder.RenameColumn(
                name: "EstadoEstCod",
                table: "CIDADE",
                newName: "EstCod");

            migrationBuilder.RenameIndex(
                name: "IX_CIDADE_EstadoEstCod",
                table: "CIDADE",
                newName: "IX_CIDADE_EstCod");

            migrationBuilder.AddForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE",
                column: "EstCod",
                principalTable: "ESTADO",
                principalColumn: "EstCod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CIDADE_CidCod",
                table: "CLIENTE",
                column: "CidCod",
                principalTable: "CIDADE",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CIDADE_ESTADO_EstCod",
                table: "CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CidCod",
                table: "CLIENTE");

            migrationBuilder.RenameColumn(
                name: "CidCod",
                table: "CLIENTE",
                newName: "CliCidCod");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTE_CidCod",
                table: "CLIENTE",
                newName: "IX_CLIENTE_CliCidCod");

            migrationBuilder.RenameColumn(
                name: "EstCod",
                table: "CIDADE",
                newName: "EstadoEstCod");

            migrationBuilder.RenameIndex(
                name: "IX_CIDADE_EstCod",
                table: "CIDADE",
                newName: "IX_CIDADE_EstadoEstCod");

            migrationBuilder.AddForeignKey(
                name: "FK_CIDADE_ESTADO_EstadoEstCod",
                table: "CIDADE",
                column: "EstadoEstCod",
                principalTable: "ESTADO",
                principalColumn: "EstCod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CIDADE_CliCidCod",
                table: "CLIENTE",
                column: "CliCidCod",
                principalTable: "CIDADE",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
