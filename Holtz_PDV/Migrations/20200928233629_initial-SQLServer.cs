﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Holtz_PDV.Migrations
{
    public partial class initialSQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADO",
                columns: table => new
                {
                    EstCod = table.Column<int>(type: "INT", nullable: false),
                    EstNom = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    EstUf = table.Column<string>(type: "VARCHAR(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO", x => x.EstCod);
                });

            migrationBuilder.CreateTable(
                name: "MARCA",
                columns: table => new
                {
                    MarCod = table.Column<int>(type: "INT", nullable: false),
                    MarNom = table.Column<string>(type: "VARCHAR(130)", nullable: true),
                    MarSts = table.Column<byte>(type: "TINYINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCA", x => x.MarCod);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProCod = table.Column<int>(type: "INT", nullable: false),
                    ProNom = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    ProObs = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    ProSts = table.Column<byte>(type: "TINYINT", nullable: true),
                    ProVlrVen = table.Column<decimal>(type: "DECIMAL(17,2)", nullable: false),
                    ProVlrCus = table.Column<decimal>(type: "DECIMAL(17,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProCod);
                });

            migrationBuilder.CreateTable(
                name: "CIDADE",
                columns: table => new
                {
                    CidCod = table.Column<int>(type: "INT", nullable: false),
                    CidNom = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    EstadoEstCod = table.Column<int>(nullable: true),
                    CidIBGE = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIDADE", x => x.CidCod);
                    table.ForeignKey(
                        name: "FK_CIDADE_ESTADO_EstadoEstCod",
                        column: x => x.EstadoEstCod,
                        principalTable: "ESTADO",
                        principalColumn: "EstCod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
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
                    CidadeCidCod = table.Column<int>(nullable: true),
                    CliTip = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.CliCod);
                    table.ForeignKey(
                        name: "FK_CLIENTE_CIDADE_CidadeCidCod",
                        column: x => x.CidadeCidCod,
                        principalTable: "CIDADE",
                        principalColumn: "CidCod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CIDADE_EstadoEstCod",
                table: "CIDADE",
                column: "EstadoEstCod");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_CidadeCidCod",
                table: "CLIENTE",
                column: "CidadeCidCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "MARCA");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "CIDADE");

            migrationBuilder.DropTable(
                name: "ESTADO");
        }
    }
}
