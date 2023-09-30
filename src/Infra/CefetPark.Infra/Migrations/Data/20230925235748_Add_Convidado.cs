using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CefetPark.Infra.Migrations.Data
{
    public partial class Add_Convidado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosEntradasSaidas_Usuarios_Usuario_Id",
                table: "RegistrosEntradasSaidas");

            migrationBuilder.AlterColumn<int>(
                name: "Usuario_Id",
                table: "RegistrosEntradasSaidas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Convidado_Id",
                table: "RegistrosEntradasSaidas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Convidado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "int", nullable: true),
                    EstaAtivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convidado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CarroConvidado",
                columns: table => new
                {
                    CarrosId = table.Column<int>(type: "int", nullable: false),
                    ConvidadosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroConvidado", x => new { x.CarrosId, x.ConvidadosId });
                    table.ForeignKey(
                        name: "FK_CarroConvidado_Carros_CarrosId",
                        column: x => x.CarrosId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarroConvidado_Convidado_ConvidadosId",
                        column: x => x.ConvidadosId,
                        principalTable: "Convidado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosEntradasSaidas_Convidado_Id",
                table: "RegistrosEntradasSaidas",
                column: "Convidado_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarroConvidado_ConvidadosId",
                table: "CarroConvidado",
                column: "ConvidadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosEntradasSaidas_Convidado_Convidado_Id",
                table: "RegistrosEntradasSaidas",
                column: "Convidado_Id",
                principalTable: "Convidado",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosEntradasSaidas_Usuarios_Usuario_Id",
                table: "RegistrosEntradasSaidas",
                column: "Usuario_Id",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosEntradasSaidas_Convidado_Convidado_Id",
                table: "RegistrosEntradasSaidas");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosEntradasSaidas_Usuarios_Usuario_Id",
                table: "RegistrosEntradasSaidas");

            migrationBuilder.DropTable(
                name: "CarroConvidado");

            migrationBuilder.DropTable(
                name: "Convidado");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosEntradasSaidas_Convidado_Id",
                table: "RegistrosEntradasSaidas");

            migrationBuilder.DropColumn(
                name: "Convidado_Id",
                table: "RegistrosEntradasSaidas");

            migrationBuilder.AlterColumn<int>(
                name: "Usuario_Id",
                table: "RegistrosEntradasSaidas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosEntradasSaidas_Usuarios_Usuario_Id",
                table: "RegistrosEntradasSaidas",
                column: "Usuario_Id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
