using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CliCod = table.Column<int>(maxLength: 8, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CliRaz = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    CliNomFan = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    CliEnd = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    CliCpfCnpj = table.Column<string>(type: "VARCHAR(18)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CliCod);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
