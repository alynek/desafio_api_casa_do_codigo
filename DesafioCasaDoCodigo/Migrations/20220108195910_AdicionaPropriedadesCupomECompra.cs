using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioCasaDoCodigo.Migrations
{
    public partial class AdicionaPropriedadesCupomECompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CupomId",
                table: "Compras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CupomId",
                table: "Compras",
                column: "CupomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Cupons_CupomId",
                table: "Compras",
                column: "CupomId",
                principalTable: "Cupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Cupons_CupomId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_CupomId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "CupomId",
                table: "Compras");
        }
    }
}
