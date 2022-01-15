using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioCasaDoCodigo.Migrations
{
    public partial class TransformaIdTransacaoUnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdTransacao",
                table: "PagamentosPaypal",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosPaypal_IdTransacao",
                table: "PagamentosPaypal",
                column: "IdTransacao",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PagamentosPaypal_IdTransacao",
                table: "PagamentosPaypal");

            migrationBuilder.AlterColumn<string>(
                name: "IdTransacao",
                table: "PagamentosPaypal",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
