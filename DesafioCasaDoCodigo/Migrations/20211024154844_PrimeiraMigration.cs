using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioCasaDoCodigo.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkGithub",
                table: "Autores",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Autores",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkGithub",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Autores");
        }
    }
}
