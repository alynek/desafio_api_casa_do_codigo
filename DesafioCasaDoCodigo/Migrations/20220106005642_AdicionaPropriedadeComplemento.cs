using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioCasaDoCodigo.Migrations
{
    public partial class AdicionaPropriedadeComplemento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Compras",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Compras");
        }
    }
}
