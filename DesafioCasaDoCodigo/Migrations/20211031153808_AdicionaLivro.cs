using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace DesafioCasaDoCodigo.Migrations
{
    public partial class AdicionaLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 100, nullable: false),
                    Subtitulo = table.Column<string>(maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Conteudo = table.Column<string>(nullable: false),
                    Sumario = table.Column<string>(nullable: false),
                    NumeroPaginas = table.Column<int>(nullable: false),
                    Isbn = table.Column<string>(nullable: false),
                    LinkCapaLivro = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
