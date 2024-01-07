using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class TBCategoriaTBProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCATEGORIA",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatIncPor = table.Column<int>(type: "int", nullable: false),
                    CatIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CatAltPor = table.Column<int>(type: "int", nullable: true),
                    CatAltEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCATEGORIA", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "TBPRODUTO",
                columns: table => new
                {
                    ProId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProPreco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProQuantidadeEmEstoque = table.Column<int>(type: "int", nullable: false),
                    ProImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatId = table.Column<int>(type: "int", nullable: false),
                    ProIncPor = table.Column<int>(type: "int", nullable: false),
                    ProIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProAltPor = table.Column<int>(type: "int", nullable: true),
                    ProAltEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoriaCatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPRODUTO", x => x.ProId);
                    table.ForeignKey(
                        name: "FK_TBPRODUTO_TBCATEGORIA_CategoriaCatId",
                        column: x => x.CategoriaCatId,
                        principalTable: "TBCATEGORIA",
                        principalColumn: "CatId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPRODUTO_CategoriaCatId",
                table: "TBPRODUTO",
                column: "CategoriaCatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPRODUTO");

            migrationBuilder.DropTable(
                name: "TBCATEGORIA");
        }
    }
}
