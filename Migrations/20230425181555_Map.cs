using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    public partial class Map : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Pessoa_PessoaModelID",
                table: "Orcamento");

            migrationBuilder.DropIndex(
                name: "IX_Orcamento_PessoaModelID",
                table: "Orcamento");

            migrationBuilder.DropColumn(
                name: "PessoaModelID",
                table: "Orcamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaModelID",
                table: "Orcamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_PessoaModelID",
                table: "Orcamento",
                column: "PessoaModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Pessoa_PessoaModelID",
                table: "Orcamento",
                column: "PessoaModelID",
                principalTable: "Pessoa",
                principalColumn: "ID");
        }
    }
}
