using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CefetPark.Infra.Migrations.Data
{
    public partial class Implementacao_IndiceUnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoLogradouro",
                table: "Enderecos");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Cpf",
                table: "Usuarios",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Matricula",
                table: "Usuarios",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposUsuarios_Nome",
                table: "TiposUsuarios",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_Nome",
                table: "Modelos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_Nome",
                table: "Marcas",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamentos_Nome",
                table: "Estacionamentos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Nome",
                table: "Departamentos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cores_Nome",
                table: "Cores",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_Placa",
                table: "Carros",
                column: "Placa",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Cpf",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Matricula",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_TiposUsuarios_Nome",
                table: "TiposUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Modelos_Nome",
                table: "Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Marcas_Nome",
                table: "Marcas");

            migrationBuilder.DropIndex(
                name: "IX_Estacionamentos_Nome",
                table: "Estacionamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_Nome",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Cores_Nome",
                table: "Cores");

            migrationBuilder.DropIndex(
                name: "IX_Carros_Placa",
                table: "Carros");

            migrationBuilder.AddColumn<string>(
                name: "TipoLogradouro",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
