using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    public partial class Criacaotabelaprodutomapeamentoorcamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Orcamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeEmEstoque = table.Column<int>(type: "int", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutoIncPor = table.Column<int>(type: "int", nullable: false),
                    ProdutoIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutoAltPor = table.Column<int>(type: "int", nullable: true),
                    ProdutoAltEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_ProdutoId",
                table: "Orcamento",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Produtos_ProdutoId",
                table: "Orcamento",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Produtos_ProdutoId",
                table: "Orcamento");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Orcamento_ProdutoId",
                table: "Orcamento");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Orcamento");
        }
    }
}
