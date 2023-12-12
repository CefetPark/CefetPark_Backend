using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CefetPark.Infra.Migrations.Data
{
    public partial class addRegistroOcupacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrosOcupacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuantidadeVagasLivres = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RegistroEntradaSaida_Id = table.Column<int>(type: "int", nullable: false),
                    EstacionamentoId = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "int", nullable: true),
                    EstaAtivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosOcupacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosOcupacoes_Estacionamentos_EstacionamentoId",
                        column: x => x.EstacionamentoId,
                        principalTable: "Estacionamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrosOcupacoes_RegistrosEntradasSaidas_RegistroEntradaSa~",
                        column: x => x.RegistroEntradaSaida_Id,
                        principalTable: "RegistrosEntradasSaidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosOcupacoes_EstacionamentoId",
                table: "RegistrosOcupacoes",
                column: "EstacionamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosOcupacoes_RegistroEntradaSaida_Id",
                table: "RegistrosOcupacoes",
                column: "RegistroEntradaSaida_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosOcupacoes");
        }
    }
}
