using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace DesafioCasaDoCodigo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    LinkGithub = table.Column<string>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cupons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: false),
                    Expiracao = table.Column<DateTime>(nullable: false),
                    Desconto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AutorId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Livros_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    CupomId = table.Column<int>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Cupons_CupomId",
                        column: x => x.CupomId,
                        principalTable: "Cupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
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
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Itens_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagamentosPaypal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdTransacao = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentosPaypal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentosPaypal_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Nome",
                table: "Categorias",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CupomId",
                table: "Compras",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_CompraId",
                table: "Itens",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_LivroId",
                table: "Itens",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AutorId",
                table: "Livros",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Isbn",
                table: "Livros",
                column: "Isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Titulo",
                table: "Livros",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosPaypal_CompraId",
                table: "PagamentosPaypal",
                column: "CompraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosPaypal_IdTransacao",
                table: "PagamentosPaypal",
                column: "IdTransacao",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "PagamentosPaypal");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Cupons");
        }
    }
}
