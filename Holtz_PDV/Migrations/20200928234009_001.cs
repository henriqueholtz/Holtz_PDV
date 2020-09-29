using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CidadeCidCod",
                table: "CLIENTE");

            migrationBuilder.RenameColumn(
                name: "CidadeCidCod",
                table: "CLIENTE",
                newName: "CliCidCod");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTE_CidadeCidCod",
                table: "CLIENTE",
                newName: "IX_CLIENTE_CliCidCod");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CIDADE_CliCidCod",
                table: "CLIENTE",
                column: "CliCidCod",
                principalTable: "CIDADE",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CIDADE_CliCidCod",
                table: "CLIENTE");

            migrationBuilder.RenameColumn(
                name: "CliCidCod",
                table: "CLIENTE",
                newName: "CidadeCidCod");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTE_CliCidCod",
                table: "CLIENTE",
                newName: "IX_CLIENTE_CidadeCidCod");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CIDADE_CidadeCidCod",
                table: "CLIENTE",
                column: "CidadeCidCod",
                principalTable: "CIDADE",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
