using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class mapsTabelasNovas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPRODUTO_TBCATEGORIA_CategoriaCatId",
                table: "TBPRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_TBPRODUTO_CategoriaCatId",
                table: "TBPRODUTO");

            migrationBuilder.DropColumn(
                name: "CategoriaCatId",
                table: "TBPRODUTO");

            migrationBuilder.CreateIndex(
                name: "IX_TBPRODUTO_CatId",
                table: "TBPRODUTO",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPRODUTO_TBCATEGORIA_CatId",
                table: "TBPRODUTO",
                column: "CatId",
                principalTable: "TBCATEGORIA",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPRODUTO_TBCATEGORIA_CatId",
                table: "TBPRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_TBPRODUTO_CatId",
                table: "TBPRODUTO");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaCatId",
                table: "TBPRODUTO",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBPRODUTO_CategoriaCatId",
                table: "TBPRODUTO",
                column: "CategoriaCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPRODUTO_TBCATEGORIA_CategoriaCatId",
                table: "TBPRODUTO",
                column: "CategoriaCatId",
                principalTable: "TBCATEGORIA",
                principalColumn: "CatId");
        }
    }
}
