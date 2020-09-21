using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class Cliente_Cidade_virtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "CLIENTE",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_CidCod",
                table: "CLIENTE",
                column: "CidCod");

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
                name: "FK_CLIENTE_CIDADE_CidCod",
                table: "CLIENTE");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTE_CidCod",
                table: "CLIENTE");

            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "CLIENTE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CidadeCidCod",
                table: "CLIENTE",
                type: "INT",
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
    }
}
