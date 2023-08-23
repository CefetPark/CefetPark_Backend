using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CefetPark.Infra.Migrations.Data
{
    public partial class Mudanca_Many_to_many_DataContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarroUsuario",
                columns: table => new
                {
                    CarrosId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroUsuario", x => new { x.CarrosId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_CarroUsuario_Carros_CarrosId",
                        column: x => x.CarrosId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarroUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CarroUsuario_UsuariosId",
                table: "CarroUsuario",
                column: "UsuariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroUsuario");

            migrationBuilder.CreateTable(
                name: "UsuariosCarros",
                columns: table => new
                {
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Carro_Id = table.Column<int>(type: "int", nullable: false),
                    AtualizadoPor = table.Column<int>(type: "int", nullable: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstaAtivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosCarros", x => new { x.Usuario_Id, x.Carro_Id });
                    table.ForeignKey(
                        name: "FK_UsuariosCarros_Carros_Carro_Id",
                        column: x => x.Carro_Id,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosCarros_Usuarios_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCarros_Carro_Id",
                table: "UsuariosCarros",
                column: "Carro_Id");
        }
    }
}
