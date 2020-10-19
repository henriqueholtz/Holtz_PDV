using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Seq_CliEmlCod");

            migrationBuilder.CreateTable(
                name: "ClienteEmails",
                columns: table => new
                {
                    CliEmlCod = table.Column<int>(type: "INT", nullable: false),
                    CliCod = table.Column<int>(type: "INT", nullable: false),
                    CliEml = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CliEmlCon = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ClienteCliCod = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEmails", x => x.CliEmlCod);
                    table.ForeignKey(
                        name: "FK_ClienteEmails_Cliente_ClienteCliCod",
                        column: x => x.ClienteCliCod,
                        principalTable: "Cliente",
                        principalColumn: "CliCod");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEmails_ClienteCliCod",
                table: "ClienteEmails",
                column: "ClienteCliCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteEmails");

            migrationBuilder.DropSequence(
                name: "Seq_CliEmlCod");
        }
    }
}
