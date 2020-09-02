using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class Add_Tables_Cidades_and_Estados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CliBai",
                table: "Clientes",
                type: "VARCHAR(130)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstCod = table.Column<int>(maxLength: 8, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstNom = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    EstUf = table.Column<string>(type: "VARCHAR(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstCod);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    CidCod = table.Column<int>(maxLength: 8, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CidNom = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CidIBGE = table.Column<int>(maxLength: 8, nullable: false),
                    EstadoEstCod = table.Column<int>(nullable: true),
                    EstCod = table.Column<int>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.CidCod);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_EstadoEstCod",
                        column: x => x.EstadoEstCod,
                        principalTable: "Estados",
                        principalColumn: "EstCod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoEstCod",
                table: "Cidades",
                column: "EstadoEstCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropColumn(
                name: "CliBai",
                table: "Clientes");
        }
    }
}
