using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CefetPark.Infra.Migrations.Data
{
    public partial class refactorconvidado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Cores_Cor_Id",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Modelos_Modelo_Id",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_Marca_Id",
                table: "Modelos");

            migrationBuilder.AlterColumn<int>(
                name: "Marca_Id",
                table: "Modelos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Sicap",
                table: "Convidado",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Modelo_Id",
                table: "Carros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Cor_Id",
                table: "Carros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Cores_Cor_Id",
                table: "Carros",
                column: "Cor_Id",
                principalTable: "Cores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Modelos_Modelo_Id",
                table: "Carros",
                column: "Modelo_Id",
                principalTable: "Modelos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_Marca_Id",
                table: "Modelos",
                column: "Marca_Id",
                principalTable: "Marcas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Cores_Cor_Id",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Modelos_Modelo_Id",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_Marca_Id",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "Sicap",
                table: "Convidado");

            migrationBuilder.AlterColumn<int>(
                name: "Marca_Id",
                table: "Modelos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Modelo_Id",
                table: "Carros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cor_Id",
                table: "Carros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Cores_Cor_Id",
                table: "Carros",
                column: "Cor_Id",
                principalTable: "Cores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Modelos_Modelo_Id",
                table: "Carros",
                column: "Modelo_Id",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_Marca_Id",
                table: "Modelos",
                column: "Marca_Id",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
