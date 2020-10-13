using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Seq_UsuCod");

            migrationBuilder.AlterColumn<byte>(
                name: "PedSts",
                table: "Pedido",
                type: "TINYINT",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "Seq_UsuCod");

            migrationBuilder.AlterColumn<byte>(
                name: "PedSts",
                table: "Pedido",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "TINYINT",
                oldNullable: true);
        }
    }
}
