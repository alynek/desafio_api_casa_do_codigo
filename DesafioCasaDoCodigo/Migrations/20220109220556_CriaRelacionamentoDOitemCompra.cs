using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace DesafioCasaDoCodigo.Migrations
{
    public partial class CriaRelacionamentoDOitemCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCompra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LivroId = table.Column<int>(nullable: false),
                    CompraId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCompra_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCompra_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_CompraId",
                table: "ItemCompra",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_LivroId",
                table: "ItemCompra",
                column: "LivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCompra");
        }
    }
}
