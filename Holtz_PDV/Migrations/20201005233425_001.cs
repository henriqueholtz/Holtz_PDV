using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Seq_MarCod");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_PedCod");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_ProCod");

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstCod = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstNom = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    EstUf = table.Column<string>(type: "VARCHAR(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstCod);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    MarCod = table.Column<int>(type: "INT", nullable: false, defaultValueSql: "NEXT VALUE FOR Seq_MarCod"),
                    MarNom = table.Column<string>(type: "VARCHAR(130)", nullable: true),
                    MarSts = table.Column<byte>(type: "TINYINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.MarCod);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedCod = table.Column<int>(type: "INT", nullable: false, defaultValueSql: "NEXT VALUE FOR Seq_PedCod"),
                    PedCliCod = table.Column<int>(type: "INT", nullable: true),
                    PedDtaEms = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    PedDtaFat = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    PedSts = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedCod);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    CidCod = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidNom = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    EstCod = table.Column<int>(type: "INT", nullable: true),
                    CidIBGE = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.CidCod);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_EstCod",
                        column: x => x.EstCod,
                        principalTable: "Estado",
                        principalColumn: "EstCod");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProCod = table.Column<int>(type: "INT", nullable: false, defaultValueSql: "NEXT VALUE FOR Seq_ProCod"),
                    ProNom = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    ProObs = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    ProSts = table.Column<byte>(type: "TINYINT", nullable: true),
                    ProVlrVen = table.Column<decimal>(type: "DECIMAL(17,2)", nullable: false),
                    ProVlrCus = table.Column<decimal>(type: "DECIMAL(17,2)", nullable: false),
                    MarCod = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProCod);
                    table.ForeignKey(
                        name: "FK_Produto_Marca_MarCod",
                        column: x => x.MarCod,
                        principalTable: "Marca",
                        principalColumn: "MarCod");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CliCod = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CliRaz = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    CliNomFan = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    CliBai = table.Column<string>(type: "VARCHAR(130)", nullable: true),
                    CliRua = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CliSts = table.Column<byte>(type: "TINYINT", nullable: true),
                    CliCpfCnpj = table.Column<string>(type: "VARCHAR(18)", nullable: true),
                    CidCod = table.Column<int>(type: "INT", nullable: true),
                    CliTip = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CliCod);
                    table.ForeignKey(
                        name: "FK_Cliente_Cidade_CidCod",
                        column: x => x.CidCod,
                        principalTable: "Cidade",
                        principalColumn: "CidCod");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstCod",
                table: "Cidade",
                column: "EstCod");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CidCod",
                table: "Cliente",
                column: "CidCod");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_MarCod",
                table: "Produto",
                column: "MarCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropSequence(
                name: "Seq_MarCod");

            migrationBuilder.DropSequence(
                name: "Seq_PedCod");

            migrationBuilder.DropSequence(
                name: "Seq_ProCod");
        }
    }
}
