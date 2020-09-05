using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class Add_Table_Produtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "Clientes",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<int>(
                name: "CidIBGE",
                table: "Cidades",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8);

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProCod = table.Column<int>(maxLength: 8, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProNom = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    ProObs = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    ProSts = table.Column<sbyte>(type: "TINYINT", nullable: true),
                    ProVlrVen = table.Column<decimal>(type: "DECIMAL(17,2)", nullable: false),
                    ProVlrCus = table.Column<decimal>(type: "DECIMAL(17,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProCod);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "CidCod",
                table: "Clientes",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CidIBGE",
                table: "Cidades",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 8,
                oldNullable: true);
        }
    }
}
