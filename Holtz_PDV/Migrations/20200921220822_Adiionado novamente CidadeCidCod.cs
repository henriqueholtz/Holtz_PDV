using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class AdiionadonovamenteCidadeCidCod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CidadeCidCod",
                table: "CLIENTE",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_CidadeCidCod",
                table: "CLIENTE",
                column: "CidadeCidCod");

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

            migrationBuilder.DropIndex(
                name: "IX_CLIENTE_CidadeCidCod",
                table: "CLIENTE");

            migrationBuilder.DropColumn(
                name: "CidadeCidCod",
                table: "CLIENTE");
        }
    }
}
