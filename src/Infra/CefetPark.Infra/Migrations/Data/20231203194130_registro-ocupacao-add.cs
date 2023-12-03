using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CefetPark.Infra.Migrations.Data
{
    public partial class registroocupacaoadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistroOcupacao_Id",
                table: "RegistrosEntradasSaidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RegistrosOcupacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuantidadeVagasLivresEntrada = table.Column<int>(type: "int", nullable: false),
                    QuantidadeVagasLivreSaida = table.Column<int>(type: "int", nullable: true),
                    RegistroEntradaSaida_Id = table.Column<int>(type: "int", nullable: false),
                    Estacionamento_Id = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_RegistrosOcupacoes_Estacionamentos_Estacionamento_Id",
                        column: x => x.Estacionamento_Id,
                        principalTable: "Estacionamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosEntradasSaidas_RegistroOcupacao_Id",
                table: "RegistrosEntradasSaidas",
                column: "RegistroOcupacao_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosOcupacoes_Estacionamento_Id",
                table: "RegistrosOcupacoes",
                column: "Estacionamento_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosEntradasSaidas_RegistrosOcupacoes_RegistroOcupacao_~",
                table: "RegistrosEntradasSaidas",
                column: "RegistroOcupacao_Id",
                principalTable: "RegistrosOcupacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosEntradasSaidas_RegistrosOcupacoes_RegistroOcupacao_~",
                table: "RegistrosEntradasSaidas");

            migrationBuilder.DropTable(
                name: "RegistrosOcupacoes");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosEntradasSaidas_RegistroOcupacao_Id",
                table: "RegistrosEntradasSaidas");

            migrationBuilder.DropColumn(
                name: "RegistroOcupacao_Id",
                table: "RegistrosEntradasSaidas");
        }
    }
}
