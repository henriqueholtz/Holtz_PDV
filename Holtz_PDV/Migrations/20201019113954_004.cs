using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class _004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PedCliCod",
                table: "Pedido",
                column: "PedCliCod");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_PedCliCod",
                table: "Pedido",
                column: "PedCliCod",
                principalTable: "Cliente",
                principalColumn: "CliCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_PedCliCod",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_PedCliCod",
                table: "Pedido");
        }
    }
}
