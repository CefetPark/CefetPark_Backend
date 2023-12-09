using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CefetPark.Infra.Migrations.Data
{
    public partial class addregistroocupacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrosOcupacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuantidadeVagasLivresEntrada = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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
                name: "IX_RegistrosOcupacoes_Estacionamento_Id",
                table: "RegistrosOcupacoes",
                column: "Estacionamento_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosOcupacoes");
        }
    }
}
