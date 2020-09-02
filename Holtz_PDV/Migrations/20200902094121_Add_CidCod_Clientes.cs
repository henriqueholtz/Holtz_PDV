using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class Add_CidCod_Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CidCod",
                table: "Clientes",
                maxLength: 8,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CidadeCidCod",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CidadeCidCod",
                table: "Clientes",
                column: "CidadeCidCod");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Cidades_CidadeCidCod",
                table: "Clientes",
                column: "CidadeCidCod",
                principalTable: "Cidades",
                principalColumn: "CidCod",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Cidades_CidadeCidCod",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CidadeCidCod",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CidCod",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CidadeCidCod",
                table: "Clientes");
        }
    }
}
