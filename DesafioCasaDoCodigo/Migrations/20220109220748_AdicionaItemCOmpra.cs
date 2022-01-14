using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioCasaDoCodigo.Migrations
{
    public partial class AdicionaItemCOmpra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompra_Compras_CompraId",
                table: "ItemCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompra_Livros_LivroId",
                table: "ItemCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCompra",
                table: "ItemCompra");

            migrationBuilder.RenameTable(
                name: "ItemCompra",
                newName: "Itens");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCompra_LivroId",
                table: "Itens",
                newName: "IX_Itens_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCompra_CompraId",
                table: "Itens",
                newName: "IX_Itens_CompraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Itens",
                table: "Itens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Compras_CompraId",
                table: "Itens",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Livros_LivroId",
                table: "Itens",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Compras_CompraId",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Livros_LivroId",
                table: "Itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Itens",
                table: "Itens");

            migrationBuilder.RenameTable(
                name: "Itens",
                newName: "ItemCompra");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_LivroId",
                table: "ItemCompra",
                newName: "IX_ItemCompra_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_CompraId",
                table: "ItemCompra",
                newName: "IX_ItemCompra_CompraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCompra",
                table: "ItemCompra",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompra_Compras_CompraId",
                table: "ItemCompra",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompra_Livros_LivroId",
                table: "ItemCompra",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
